import React, { useContext, useEffect, useRef, useState } from "react";
import { useParams } from "react-router";
import { GetChatByID } from "../../api/messages";
import Context from "../../Context/Context";
import WriteMSG from "../WriteMSG/WriteMSG";
import "./SelectedChat.scss";

const SelectedChat = () => {
  const { User } = useContext(Context);

  const [MSGWrapper, setMSGWrapper] = useState(<h1>loading...</h1>);
  const [Allmsg, setAllmsg] = useState([
    {
      id: -1,
      senderName: null,
      body: null,
      sentiment: 0,
      datetime: null,
    },
  ]);
  const AddInChatmsg = (res) => {
    setAllmsg((allMessages) => [...allMessages, res]);
  };

  const reff = useRef(null);
  let { id } = useParams();

  useEffect(() => {
    GetChatByID(User.token, id)
      .then((res) => {
        setAllmsg(res);
      })
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id]);

  const AlwaysScrollToBottom = () => {
    const elementRef = useRef();
    useEffect(() => elementRef.current.scrollIntoView());
    return <div ref={elementRef} />;
  };

  useEffect(() => {
    console.log('Allmsg.length changed');
    const MapMsg = Allmsg.map((msg, idx) => {
      return (
        <div
          key={idx}
          className={`msg ${
            User.user.username === msg.senderName ? "right" : "left"
          }`}
        >
          <span className="msg-user">{msg.senderName}</span>
          <p>{msg.body}</p>
          <span className="msg-date">{msg.datetime}</span>
        </div>
      );
    });
    setMSGWrapper(MapMsg);
  }, [Allmsg.length]);

  return (
    <>
      <div ref={reff} className="selectedChat">
        {MSGWrapper}
        <AlwaysScrollToBottom />
      </div>
      <WriteMSG AddInChatmsg={AddInChatmsg} id={id} />
    </>
  );
};

export default SelectedChat;
