import React, { useContext, useEffect } from "react";
import { useNavigate } from "react-router";
import { Auth, GetUser } from "../../api/user";
import Context from "../../Context/Context";
import styles from "./login.module.scss";

const Login = () => {
  let navigate = useNavigate();
  const { setUser } = useContext(Context);

  useEffect(() => {
    const currentToken = localStorage.getItem("token");
    console.log(currentToken);
    if (currentToken !== null && currentToken !== "") {
      GetUser(currentToken).then((UserData) => {
        // console.log(UserData);
      });
    }
    // if (
    //   currentToken !== null && currentToken !== ""
    // ) {
    //   navigate("/chat");
    // }
    return () => {};
  }, []);

  const SubmitUser = async (e) => {
    e.preventDefault();
    let email = e.currentTarget.elements.email.value;
    let password = e.currentTarget.elements.password.value;
    const res = await Auth(email, password);
    console.log(res);
    if (res.message === undefined && res.token !== "") {
      localStorage.setItem("token", res.token);
      setUser(res);
      navigate("/chat");
    } else {
      console.log("error");
    }
  };

  return (
    <div className={styles.AuthformWrapper}>
      <form onSubmit={SubmitUser}>
        <h1>Введите логин и пароль</h1>
        <div className={styles.mailpassWrapper}>
          <div>
            <label>Login:</label>
            <input
              type="text"
              placeholder="email@gmail.com"
              autoComplete="email"
              id="email"
            />
          </div>
          <div>
            <label>Password:</label>
            <input
              type="password"
              placeholder="*****"
              autoComplete="current-password"
              id="password"
            />
          </div>
        </div>
        <button className={styles.btnsubmit} type="submit">
          Отправить
        </button>
        <button
          onClick={() => navigate("registration")}
          type="button"
          className={styles.registerRedirect}
        >
          Новый пользователь?
        </button>
      </form>
    </div>
  );
};

export default Login;
