import React, { useEffect, useState } from "react";
import { Outlet, useLocation } from "react-router";
import { NavLink } from "react-router-dom";

import "./Header.scss";

const Header = () => {
  const [Linker, setLinker] = useState([]);
  let location = useLocation();
  
  useEffect(() => {
    const currentToken = localStorage.getItem("token");
    if (currentToken === null ||currentToken === "" ) {
      setLinker([
        {
          url: "/",
          name: "Авторизация",
        },
        {
          url: "/registration",
          name: "Регистрация",
        },
      ]);
    } else {
      setLinker([
        {
          url: "/chat",
          name: "Чат",
        },
        {
          url: "/account",
          name: "Личный Кабинет",
        },
        {
          url: "/logout",
          name: "Выйти",
        },
      ]);
    }
  }, [location.pathname]);

  return (
    <>
      <nav className="head">
        {Linker.map((link, index) => {
          return (
            <NavLink
              className={({ isActive }) =>
                isActive ? "activeLink" : "nonActiveLink"
              }
              key={index}
              to={link.url}
            >
              {link.name}
            </NavLink>
          );
        })}
      </nav>
      <Outlet />
    </>
  );
};

export default Header;
