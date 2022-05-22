import React, { useContext, useEffect, useState } from "react";
import { Link, NavLink, Outlet } from "react-router-dom";
import "./NavBar.scss";
import { useLocation } from "react-router-dom";
import Context from "../../context/Context";
import itmo_logo from './itmo_logo.png';
const NavBar = () => {
  const { User } = useContext(Context);
  const [Peeps, setPeeps] = useState(null);
  const [UserNavBar, setUserNavBar] = useState({
    lastName: "",
    firstName: "",
    middleName: "",
  });
  let location = useLocation();

  useEffect(() => {
    if (User.user && User.token) {
      setUserNavBar({
        lastName: User.user.lastName,
        firstName: User.user.firstName,
        middleName: User.user.middleName,
      });
      let Nickname = User.user.username;
      let counter = 0;
      for (let index = 0; index < Nickname.length; index++) {
        let ascii = Nickname[index].charCodeAt(0);
        counter += ascii;
      }
      let PeepsNumb = (counter % 94) + 1;
      setPeeps(PeepsNumb);
    }
    return () => {};
  }, [User.user, User.token]);

  return (
    <div className="NavBar">
      <div className="nav">
        <Link className="itmo-logo" to={"/subject"}>
          <img src={itmo_logo} alt="ITMO" />
        </Link>
        <br />

        <h1 className="person">
          {`${UserNavBar.lastName} ${UserNavBar.firstName} ${UserNavBar.middleName}`}
        </h1>
        <div className="avatar-wrapper">
          {Peeps && (
            <img
              src={`${process.env.PUBLIC_URL}/peeps/peep-${Peeps}.png`}
              alt="avatar"
              className="avatar"
            />
          )}
        </div>

        <NavLink
          className={({ isActive }) => (isActive ? "nav-link-active" : "nav-link")}
          to={"/subject"}
        >
          Дисциплины
        </NavLink>
        <NavLink
          className={({ isActive }) => {
            if (isActive) return "nav-link-active";
            else {
              if (location.pathname.includes("/testerConfirm/")) return "nav-link-active";
              else return "nav-link";
            }
          }}
          to={"/tester"}
        >
          Тестирование
        </NavLink>
        {/* <NavLink
          className={({ isActive }) => (isActive ? "nav-link-active" : "nav-link")}
          to={"/academicPerformance"}
        >
          Ведомость
        </NavLink> */}
        <NavLink
          className={({ isActive }) => (isActive ? "nav-link-active" : "nav-link")}
          to={"/checkStudents"}
        >
          Проверка работ
        </NavLink>
        <NavLink
          className={({ isActive }) => (isActive ? "nav-link-active" : "nav-link")}
          to={"/logout"}
        >
          Выход
        </NavLink>
      </div>
      <main className="content">
        <Outlet />
      </main>
    </div>
  );
};

export default NavBar;
