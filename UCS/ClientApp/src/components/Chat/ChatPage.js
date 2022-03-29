import React, { useContext, useEffect, useState } from "react";
import { Link, Outlet } from "react-router-dom";
import { GetAllChat } from "../api/chat";
import Context from "../Context/Context";
import styles from "./ChatPage.module.scss";

const ChatPage = () => {
  const { User } = useContext(Context);
  
  const [AllChat, setAllChat] = useState([
    {
      id: -1,
      name: "",
      chatType: -1,
      datetime: "1000-10-10T00:00:00.0000",
    },
  ]);

  useEffect(() => {
    GetAllChat(User.token).then((res) => {
      setAllChat(res);
    });
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <div className={styles.chatpageContainer}>
      <div className={styles.fullChatWrapper}>
        <div className={styles.header}>Выберите Чат!</div>
        <div className={styles.chatWrapper}>
          <div className={styles.ChatSelector}>
            {AllChat.map((chat, idx) => {
              if (chat.id === -1) return <h1 key={idx}>Please Wait</h1>;
              return (
                <Link
                  key={idx}
                  to={`/chat/${chat.id}`}
                  className={styles.ChatLink}
                >
                  {chat.name}
                </Link>
              );
            })}
          </div>
          <div className={styles.ChatCurrent}>
            <Outlet />
          </div>
        </div>
      </div>
    </div>
  );
};

export default ChatPage;
