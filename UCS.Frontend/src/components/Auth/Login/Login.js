import React, { useContext, useEffect, useState } from "react";
import { Link, useLocation, useNavigate } from "react-router-dom";
import { getUserByToken, sendLogin } from "../../../api/api";
import Context from "../../../context/Context";
import "./Login.scss";

const Login = () => {
  let navigate = useNavigate();
  let location = useLocation();
  const { setUser } = useContext(Context);
  const [isError, setIsError] = useState(null);
  let from = location.state?.from?.pathname || "/";

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      getUserByToken(token)
        .then((res) => {
          if (!res.message) {
            setUser({ user: res, token: token });
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
    const UserData = await sendLogin(e.target[0].value, e.target[1].value);
    if (UserData.message) {
      setIsError(UserData.message);
    } else {
      setUser(UserData);
      localStorage.setItem("token", UserData.token);
      navigate(from, { replace: true });
    }
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
        <input placeholder="Логин" type="login" required name="login" />

        <input
          placeholder="Пароль"
          type="password"
          name="password"
          autoComplete="on"
          required
        />

        <input className="form-submit" type="submit" value="Войти" />
        <h2 style={{ color: "red", textAlign: "center" }}>{isError}</h2>
      </form>
    </div>
  );
};

export default Login;

//  <hr style={{width: '100%'}} />
// <div className="btn-wrapper">
//   <Link to={"/forgetPass"} className="btn-forget">
//     Забыл/а пароль
//   </Link>
//   <Link to={"/newUser"} className="btn-new">
//     Новый пользователь
//   </Link>
//  </div>
