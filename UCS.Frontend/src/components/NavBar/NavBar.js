import React, { useContext, useEffect, useState } from "react";
import { Link, NavLink, Outlet } from "react-router-dom";
import "./NavBar.scss";
import { useLocation } from "react-router-dom";
import Context from "../../context/Context";
import itmo_logo from "./itmo_logo.png";
import navbarImg from "./navbar.svg";

const NavBar = () => {
  const { User } = useContext(Context);
  const [Peeps, setPeeps] = useState(null);
  const [UserNavBar, setUserNavBar] = useState({
    lastName: "",
    firstName: "",
    middleName: "",
    userHaveAccess: false,
  });
  const [NavBarVisible, setNavBarVisible] = useState(true);

  let location = useLocation();

  useEffect(() => {
    if (User.user && User.token) {
      let min = null;
      if (User.user.roles) min = Math.min(...User.user.roles.map((item) => item.id));

      setUserNavBar({
        lastName: User.user.lastName,
        firstName: User.user.firstName,
        middleName: User.user.middleName,
        userHaveAccess: min < 3,
      });
      let Nickname = User.user.username;
      let counter = 0;
      for (let index = 0; index < Nickname.length; index++) {
        let ascii = Nickname[index].charCodeAt(0);
        counter += ascii;
      }
      let PeepsNumb = (counter % 94) + 1;
      setPeeps(PeepsNumb);
      if (window.screen.width <= 1000) {
        setNavBarVisible(false);
      }
    }
    return () => {};
  }, [User.user, User.token]);

  const moveNav = () => {
    setNavBarVisible((prev) => !prev);
  };

  const ArrowToRight = <p>&#10097;</p>;
  const ArrowToLeft = <p>&#10096;</p>;

  return (
    <div className="NavBar">
      <button onClick={moveNav} className="nav-visible-btn">
        {NavBarVisible ? ArrowToLeft : ArrowToRight}
        <img src={navbarImg} alt="show/hiden" />
      </button>
      <div className={`nav ${NavBarVisible ? "active" : "non-active"}`}>
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
          // onClick={() => setNavBarVisible((prev) => !prev)}
          className={({ isActive }) => (isActive ? "nav-link-active" : "nav-link")}
          to={"/subject"}
        >
          ????????????????????
        </NavLink>
        <NavLink
          // onClick={() => setNavBarVisible((prev) => !prev)}
          className={({ isActive }) => {
            if (isActive) return "nav-link-active";
            else {
              if (location.pathname.includes("/testerConfirm/")) return "nav-link-active";
              else return "nav-link";
            }
          }}
          to={"/tester"}
        >
          ?????????????? ????
        </NavLink>

        {UserNavBar.userHaveAccess ? (
          <NavLink
            // onClick={() => setNavBarVisible((prev) => !prev)}
            className={({ isActive }) => (isActive ? "nav-link-active" : "nav-link")}
            to={"/checkStudents"}
          >
            ???????????????? ????
          </NavLink>
        ) : null}
        <NavLink
          // onClick={() => setNavBarVisible((prev) => !prev)}
          className={({ isActive }) => (isActive ? "nav-link-active" : "nav-link")}
          to={"/academicPerformance"}
        >
          ??????????????????
        </NavLink>

        <NavLink
          // onClick={() => setNavBarVisible((prev) => !prev)}
          className={({ isActive }) => (isActive ? "nav-link-active" : "nav-link")}
          to={"/logout"}
        >
          ??????????
        </NavLink>
      </div>
      <main className="content">
        <Outlet />
      </main>
    </div>
  );
};

export default NavBar;
