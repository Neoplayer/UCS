import React, { useEffect } from "react";
import { useNavigate } from "react-router";

const LogOut = () => {
  const navigate = useNavigate();
  useEffect(() => {
    localStorage.removeItem("token");
    navigate("/");
    return () => {
      console.log("returned to home page");
    };
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  return <h1>Please wait ...</h1>;
};

export default LogOut;
