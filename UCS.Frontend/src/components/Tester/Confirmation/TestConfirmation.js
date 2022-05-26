import React, { useContext, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { GetActiveSession, GetStartSession, getTopicInfo } from "../../../api/api";
import Context from "../../../context/Context";
import { onAlert } from "../../Alert/Aler";
import "./TestConfirmation.scss";
import time from "./time.png";

const TestConfirmation = () => {
  const navigate = useNavigate();
  const { User } = useContext(Context);
  const [TopicInfo, setTopicInfo] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [isError, setIsError] = useState(false);
  
  let { id } = useParams();
  useEffect(() => {
    getTopicInfo(id).then((res) => {
      if (res.topicInfo) {
        setTopicInfo(res.topicInfo);
        setIsLoading(false);
      }
      if (res.success === false) {
        setIsError("Выбранная вами контрольная работа не найдена");
        setIsLoading(false);
      }
    });
  }, []);

  if (isLoading) return <h1>Загрузка...</h1>;

  if (isError) {
    return <h1>{isError}</h1>;
  }
  const StartSession = async () => {
    const isActiveSession = await GetActiveSession(User.token);
    if (!isActiveSession.success && isActiveSession.message === "No active sessions") {
      const StartSessionTest = await GetStartSession(id, User.token);
      if (StartSessionTest.success) {
        navigate("/tester", { replace: true });
      } else {
        alert("Проблемы с сервером");
      }
    } else {
      onAlert("У вас уже открыта сессия с контрольной работой", 'error')
    }
  };

  return (
    <div className="TestConfirmation">
      <div className="alarm-baner">
        <h1 className="header-text">Подтверждение</h1>

        <div className="info-wrapper">
          <h2 className="subject">
            Дисциплина<span className="text-info">«{TopicInfo.subjectName}»</span>
          </h2>
          <p className="charapter">
            Глава<span className="text-info">«{TopicInfo.charapterName}»</span>
          </p>
          <p className="topic">
            Тема<span className="text-info">«{TopicInfo.topicName}»</span>
          </p>
          <div className="time-wrapper">
            <img src={time} alt="time" className="time-img" />
            <p className="timer">
              Время для выполнения <span className="time">{TopicInfo.timeLimit}</span>
            </p>
          </div>
        </div>

        <div className="btn-wrapper">
          <Link to={"/"} className="btn-back">
            Назад
          </Link>
          <button onClick={StartSession} className="btn-confirm">
            Готов
          </button>
        </div>
      </div>
    </div>
  );
};

export default TestConfirmation;
