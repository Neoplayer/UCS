import React, { useContext, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import "./Test.scss";
import { GetActiveSession, SendFinishSession } from "../../../api/api";
import Context from "../../../context/Context";
import Question from "./Question/Question";

const Test = () => {
  const { User } = useContext(Context);

  const navigate = useNavigate();

  const [ActiveSession, setActiveSession] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [IsReadyToCloseSession, setIsReadyToCloseSession] = useState(false);
  useEffect(() => {
    GetActiveSession(User.token).then((res) => {
      console.log(res);
      setActiveSession(res);
      setIsLoading(false);
    });

    return () => {};
  }, []);

  if (isLoading) return <h1>Загрузка...</h1>;

  if (!ActiveSession.success) {
    return <h1>Нет активных тестов</h1>;
  }

  const onFinishTest = () => {
    setIsReadyToCloseSession(true);
  };

  const ReadyFinishTest = async () => {
    SendFinishSession(User.token).then((res) => {
      console.log("res", res);
      if (res.success) navigate("/subject");
      else alert("Возникла ошибка с сервером");
    });
  };

  const AbortFinishTest = () => {
    setIsReadyToCloseSession(false);
  };

  return (
    <div className="Test">
      <h1 className="header-text">{ActiveSession.topicInfo.topicName}</h1>
      <Question quest={ActiveSession.questions} token={User.token} />
      <div className="finish-btn-wrapper">
        <button className="finish-btn" onClick={onFinishTest}>
          Завершить выполнение
        </button>
      </div>
      <div className={`fullpage-sure-wrapper ${IsReadyToCloseSession ? "active" : ""}`}>
        <div className="sure-wrapper">
          <h1 className="sure-text">Завершить выполнение ?</h1>
          <div className="btn-sure-wrapper">
            <button onClick={ReadyFinishTest} className="yes">ДА</button>
            <button onClick={AbortFinishTest} className="no">НЕТ</button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Test;
