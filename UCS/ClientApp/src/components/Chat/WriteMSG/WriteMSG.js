import React, { useContext, useState } from "react";
import "./WriteMSG.scss";
import { LoadingOutlined, SendOutlined } from "@ant-design/icons";
import { SendMessange } from "../../api/messages";
import Context from "../../Context/Context";

const WriteMSG = ({ id, AddInChatmsg }) => {
  const { User } = useContext(Context);

  const [ChatMsg, setChatMsg] = useState("");
  const [Loading, setLoading] = useState(false);

  const SendMsg = async () => {
    setLoading(true);
    const res = await SendMessange(User.token, id, ChatMsg);
    await AddInChatmsg(res);
    setChatMsg("");
    setLoading(false);
    console.log("send!");
    // if (ChatMsg) {
    // SendMessange(User.token, id, ChatMsg)
    //   .then(() => setChatMsg(""))
    //   .then(() => setLoading(false))
    //   .then(() => console.log("send!"));
    // AddInChatmsg("TEST TEST TEST");
    // }
  };

  return (
    <div className="msg-writter-wrapper">
      <textarea
        className="text-msg"
        name="text"
        onChange={(e) => setChatMsg(e.target.value)}
        value={ChatMsg}
      ></textarea>
      <button onClick={() => SendMsg()}>
        {Loading ? <LoadingOutlined spin /> : <SendOutlined />}
      </button>
    </div>
  );
};

export default WriteMSG;
