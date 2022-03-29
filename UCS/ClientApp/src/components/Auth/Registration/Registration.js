import React, { useContext, useEffect } from "react";
import { useNavigate } from "react-router";
import { RegistrationNewUser } from "../../api/user";
import Context from "../../Context/Context";
import styles from "./Registration.module.scss";

const Registration = () => {
  const navigate = useNavigate();
  const { setUser } = useContext(Context);

  useEffect(() => {
    const currentToken = localStorage.getItem("token");
    if (currentToken !== null && currentToken !== "") {
      console.log("it user already logIn in system");
      navigate("/chat");
    }
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const SubmitNewUser = async (e) => {
    e.preventDefault();
    const email = e.currentTarget.elements.email.value;
    const login = e.currentTarget.elements.login.value;
    const password = e.currentTarget.elements.password.value;
    const res = await RegistrationNewUser(email, login, password);
    console.log(res);
    if (res.message === undefined && res.status === true) {
      localStorage.setItem("token", res.user.token);
      setUser(res.user)
      navigate("/chat");
    } else {
      console.log("error with registration");
    }
  };

  return (
    <div className={styles.regContainer}>
      <form onSubmit={SubmitNewUser}>
        <h1>Регистрация</h1>
        <div className={styles.dataWrapper}>
          <div>
            <label>Email:</label>
            <input
              type="email"
              placeholder="email@gmail.com"
              autoComplete="email"
              id="email"
            />
          </div>
          <div>
            <label>Login:</label>
            <input
              type="text"
              placeholder="user123"
              autoComplete="login"
              id="login"
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
          onClick={() => navigate("/")}
          type="button"
          className={styles.loginRedirect}
        >
          Вернусть на страницу <br /> авторизации
        </button>
      </form>
    </div>
  );
};

export default Registration;
