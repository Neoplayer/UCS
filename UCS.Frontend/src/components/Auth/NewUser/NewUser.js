import React, { useState } from "react";
import { Link } from "react-router-dom";
import "./NewUser.scss";
const NewUser = () => {
  const [isError, setisError] = useState(null);
  const onSubmit = (e) => {
    setisError(null);
    e.preventDefault();
    const _login = e.target[0];
    const _password_1 = e.target[1].value;
    const _password_2 = e.target[2].value;
    if (_password_1 !== _password_2) {
      setisError("Пароли отличаются. Повторите попытку снова.");
      return;
    }

    console.log("submited");
  };

  return (
    <div className="NewUser">
      <form className="form-newUser" onSubmit={onSubmit}>
        <Link to={"/login"} className="link-back">
          Вернуться назад
        </Link>

        <h1>Новый пользователь</h1>
        <input placeholder="Логин от ису" type="login" required name="login" />
        <input
          placeholder="Пароль"
          type="password"
          name="password"
          autoComplete="on"
          required
        />
        <input
          placeholder="Пароль еще раз"
          type="password"
          name="password"
          autoComplete="on"
          required
        />
        <input className="form-submit" type="submit" value="Зарегистрироваться" />
        <p className="error">{isError}</p>
      </form>
    </div>
  );
};

export default NewUser;
