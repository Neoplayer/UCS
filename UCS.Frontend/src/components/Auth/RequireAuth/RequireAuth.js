import React, { useContext } from "react";
import { Navigate, useLocation } from "react-router-dom";
import Context from "../../../context/Context";

const RequireAuth = ({ children }) => {
  let location = useLocation();
  const { User } = useContext(Context);
  if (!User.token) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }
  return children;
};

export default RequireAuth;
