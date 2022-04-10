import React from "react";
import { Link } from "react-router-dom";
import "./ForgetPassword.scss";
const ForgetPassword = () => {

  const SubmitForm = (e) => {
    e.preventDefault();
  };

  return (
    <div className="ForgetPassword">
      <form
        className="form"
        onSubmit={(event) => {
          SubmitForm(event);
        }}
      >
        <Link to={"/login"} className="link-back" >Вернуться назад</Link>
        <h1>Восстановление пароля</h1>
        <label className="form-label">
          <input placeholder="Логин" type="login" required name="login" />
        </label>
        <input className="form-input" type="submit" value="Отправить" />
      </form>
    </div>
  );
};

export default ForgetPassword;
