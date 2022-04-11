import React, { useContext, useEffect, useState } from "react";
import { Link, NavLink, Outlet } from "react-router-dom";
import "./NavBar.scss";
import { useLocation } from "react-router-dom";
import Context from "../../context/Context";

const NavBar = () => {
  const { User } = useContext(Context);
  const [Peeps, setPeeps] = useState(20);
  let location = useLocation();

  useEffect(() => {
    if (User.User) {
      let Nickname = User.User.username;
      let counter = 0;
      for (let index = 0; index < Nickname.length; index++) {
        let ascii = Nickname[index].charCodeAt(0);
        counter += ascii;
      }
      let PeepsNumb = (counter % 94) + 1;
      setPeeps(PeepsNumb);
      // for (let index = 0; index < User.User.username.length; index++) {
      //   const element = array[index];
      //   console.log(User.User.username);
      // }
    }

    // const RandomPeep = Math.floor(Math.random() * 94) + 1;
    // setPeeps(RandomPeep);
    return () => {};
  }, []);

  return (
    <div className="NavBar">
      <div className="nav">
        <Link className="itmo-h1" to={"/subject"}>
          ITMO UNIVERSITY
        </Link>
        <br />

        <h1 className="person">
          {User.User &&
            `${User.User.lastName} ${User.User.firstName} ${User.User.middleName}`}
        </h1>
        <div className="avatar-wrapper">
          <img
            src={`${process.env.PUBLIC_URL}/peeps/peep-${Peeps}.png`}
            alt="avatar"
            className="avatar"
          />
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
        <NavLink
          className={({ isActive }) => (isActive ? "nav-link-active" : "nav-link")}
          to={"/academicPerformance"}
        >
          Ведомость
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
