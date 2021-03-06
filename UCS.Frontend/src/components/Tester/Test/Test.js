import React, { useContext, useEffect, useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import "./Test.scss";
import { GetActiveSession, SendFinishSession } from "../../../api/api";
import Context from "../../../context/Context";
import Question from "./Question/Question";
import Progress from "./Progressbar/Progress";
import { onAlert } from "../../Alert/Aler";
import ConfirmeEnd from "./ConfirmeEnd/ConfirmeEnd";
import { SecForSolve, StringToSec } from "./TimeUtils";
import QR from "./QR/QR";
import FullScreenImg from "./FullScreenImg/FullScreenImg";

const Test = () => {
  const { User } = useContext(Context);
  const intervall = useRef(null);
  const navigate = useNavigate();

  const [ActiveSession, setActiveSession] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [IsReadyToCloseSession, setIsReadyToCloseSession] = useState(false);
  const [ProgressValue, setProgressValue] = useState(0);
  const [isQRVisible, setIsQRVisible] = useState(false);
  const [FullImgData, setFullImgData] = useState(null);

  useEffect(() => {
    let onLoad = true;
    GetActiveSession(User.token).then((res) => {
      if (onLoad) {
        setActiveSession(res);
        setIsLoading(false);
      }
    });
    return () => {
      onLoad = false;
    };
  }, []);

  const ReadyFinishTest = async () => {
    SendFinishSession(User.token).then((res) => {
      clearInterval(intervall.current);
      intervall.current = null;
      if (res.success) navigate("/subject");
      else alert("Возникла ошибка с сервером");
    });
  };

  useEffect(() => {
    let interval = null;
    if (ActiveSession?.timeLeft) {
      let Time = StringToSec(ActiveSession.timeLeft);

      onAlert(
        `Всего времени на выполнение: ${Time.hour}:${Time.min}:${Time.sec < 10 ? 0 : ""}${
          Time.sec
        }`,
      );
      const Max = SecForSolve(ActiveSession.startDateTime, ActiveSession.timeLimit);
      let valueNow = Max - Time.totalSec;
      intervall.current = setInterval(() => {
        valueNow += 1;
        if (valueNow >= Max) {
          clearInterval(interval);
          onAlert("Время закончилось!", "error");
          ReadyFinishTest();
        } else {
          setProgressValue(valueNow);
        }
      }, 1000);
    }

    return () => {
      clearInterval(intervall.current);
      intervall.current = null;
    };
  }, [ActiveSession]);

  if (isLoading) return <h1>Загрузка...</h1>;

  if (!ActiveSession.success) {
    return <h1>Нет активных контрольных работ</h1>;
  }

  const onFinishTest = () => {
    setIsReadyToCloseSession(true);
  };

  const AbortFinishTest = () => {
    setIsReadyToCloseSession(false);
  };

  return (
    <div className="Test">
      <h1 className="header-text">{ActiveSession.topicInfo.topicName}</h1>
      <Question
        quest={ActiveSession.questions}
        token={User.token}
        setFullImgData={setFullImgData}
      />
      <Progress
        setIsQRVisible={setIsQRVisible}
        ProgressValue={ProgressValue}
        Time={ActiveSession}
      />
      <div className="finish-btn-wrapper">
        <button className="finish-btn" onClick={onFinishTest}>
          Завершить выполнение
        </button>
      </div>

      <QR isQRVisible={isQRVisible} setIsQRVisible={setIsQRVisible} />

      <FullScreenImg FullImgData={FullImgData} setFullImgData={setFullImgData} />

      <ConfirmeEnd
        IsReadyToCloseSession={IsReadyToCloseSession}
        ReadyFinishTest={ReadyFinishTest}
        AbortFinishTest={AbortFinishTest}
      />
    </div>
  );
};

export default Test;
