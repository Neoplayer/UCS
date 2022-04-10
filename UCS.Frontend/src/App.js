import { Navigate, Route, Routes, useLocation, useNavigate } from "react-router-dom";
import "./App.css";
import ForgetPassword from "./components/Auth/ForgetPassword/ForgetPassword";
import Login from "./components/Auth/Login/Login";
import NavBar from "./components/NavBar/NavBar";
import LogOut from "./components/Auth/LogOut/LogOut";
import Subject from "./components/Subject/Subject";
import AcademicPerformance from "./components/AcademicPerformance/AcademicPerformance";
import Context from "./context/Context";
import { useEffect, useState } from "react";
import RequireAuth from "./components/Auth/RequireAuth/RequireAuth";
import Test from "./components/Tester/Test/Test";
import TestConfirmation from "./components/Tester/Confirmation/TestConfirmation";

const App = () => {
  const navigate = useNavigate();
  let location = useLocation();
  const [User, setUser] = useState({
    user: {
      id: null,
      imageId: null,
      image: null,
      groupId: null,
      group: null,
      email: null,
      username: null,
      firstName: null,
      lastName: null,
      middleName: null,
      ages: null,
      registrationDate: null,
    },
    token: null,
  });

  useEffect(() => {
    if (location.pathname === "/") navigate("/subject");
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [location.pathname]);



  const contx = { User, setUser };

  return (
    <Context.Provider value={contx}>
      <Routes>
        <Route index path="/login" element={<Login />} />
        <Route path="/forgetPass" element={<ForgetPassword />} />
        <Route path="/logout" element={<LogOut />} />
        <Route path="/" element={<NavBar />}>
          <Route
            path="subject"
            element={
              <RequireAuth>
                <Subject />
              </RequireAuth>
            }
          />
          <Route
            path="tester"
            element={
              <RequireAuth>
                <Test />
              </RequireAuth>
            }
          ></Route>
          {/* <Route path="/tester" element={<Test />} /> */}
          <Route path="/testerConfirm/:id" element={<TestConfirmation />} />
          <Route path="academicPerformance" element={<AcademicPerformance />} />
        </Route>
        <Route path="*" element={<Navigate to="/login" replace />} />
      </Routes>
    </Context.Provider>
  );
};

export default App;
