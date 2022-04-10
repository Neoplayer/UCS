import React, { useContext, useEffect } from "react";
import { Link, useLocation, useNavigate } from "react-router-dom";
import { getUserByToken, sendLogin } from "../../../api/api";
import Context from "../../../context/Context";
import "./Login.scss";

const Login = () => {
  let navigate = useNavigate();
  let location = useLocation();
  const { setUser } = useContext(Context);
  let from = location.state?.from?.pathname || "/";

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      getUserByToken(token)
        .then((res) => {
          if (!res.message) {
            setUser({ User: res, token: token });
            return true;
          }
          return false;
        })
        .then((bool) => {
          if (bool) navigate(from, { replace: true });
        });
    }
    return () => {};
  }, []);

  const SubmitForm = async (e) => {
    e.preventDefault();
    console.log(e.target[0].value, e.target[1].value);
    const UserData = await sendLogin(e.target[0].value, e.target[1].value);
    setUser(UserData);
    localStorage.setItem("token", UserData.token);
    navigate(from, { replace: true });
  };

  return (
    <div className="Login">
      <form
        className="form"
        onSubmit={(event) => {
          SubmitForm(event);
        }}
      >
        <h1 className="form-header">Авторизация</h1>
        <label className="form-label">
          <input placeholder="Логин" type="login" required name="login" />
        </label>
        <label className="form-label">
          <input placeholder="Пароль" type="password" name="password" autoComplete="on" required />
        </label>
        <input className="form-input" type="submit" value="Войти" />
        <hr />
        <Link to={"/forgetPass"} className="btn-forget">
          Забыл/а пароль
        </Link>
      </form>
    </div>
  );
};

export default Login;
