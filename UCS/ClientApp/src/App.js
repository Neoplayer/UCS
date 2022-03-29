import { useEffect, useState } from "react";
import { Route, Routes, useLocation } from "react-router";
import "./App.css";
import Login from "./components/Auth/Login/Login";
import LogOut from "./components/Auth/LogOut/LogOut";
import Registration from "./components/Auth/Registration/Registration";
import ChatPage from "./components/Chat/ChatPage";
import SelectedChat from "./components/Chat/SelectedChat/SelectedChat";
import Context from "./components/Context/Context";
import Header from "./components/Header/Header";
import PersonalAccountPape from "./components/Personal Account/PersonalAccountPape";
import "./fonts/Roboto/Roboto.css";

const App = () => {
  let location = useLocation();

  const [User, setUser] = useState({
    user: {
      id: -1,
      email: null,
      username: null,
      firstName: null,
      lastName: null,
      middleName: null,
      ages: null,
      registrationDate: "0001-01-01T00:00:00",
      avgSentiment: 0,
    },
    token: null,
  });
  console.log("User", User);

  useEffect(() => {
    const currentToken = localStorage.getItem("token");

    if (currentToken == null || currentToken === "") {
      localStorage.removeItem("token");
      // navigate("/");
    }
  }, [location.pathname]);

  const contx = { User, setUser };

  return (
    <Context.Provider value={contx}>
      <Routes>
        <Route path="/" element={<Header />}>
          <Route index element={<Login />} />
          <Route path="registration" element={<Registration />} />
          <Route path="chat" element={<ChatPage />}>
            <Route path=":id" element={<SelectedChat />} />
          </Route>
          <Route path="account" element={<PersonalAccountPape />} />
          <Route path="logout" element={<LogOut />} />
          <Route path="account" element={<PersonalAccountPape />} />
        </Route>
      </Routes>
    </Context.Provider>
  );
};

export default App;
