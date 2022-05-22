import React, { useContext, useEffect, useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import "./Test.scss";
import { GetActiveSession, SendFinishSession } from "../../../api/api";
import Context from "../../../context/Context";
import Question from "./Question/Question";
import Progress from "./Progressbar/Progress";
import { onAlert } from "../../Alert/Aler";
import ConfirmeEnd from "./ConfirmeEnd/ConfirmeEnd";

const Test = () => {
  const { User } = useContext(Context);
  const intervall = useRef(null);
  const navigate = useNavigate();

  const [ActiveSession, setActiveSession] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [IsReadyToCloseSession, setIsReadyToCloseSession] = useState(false);
  const [ProgressValue, setProgressValue] = useState(0);

  useEffect(() => {
    let onLoad = true;
    GetActiveSession(User.token).then((res) => {
      if (onLoad) {
        console.log(res);
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
      let time = ActiveSession.timeLeft.split(":");
      let hour = time[0] * 60 * 60;
      let min = time[1] * 60;
      let sec = Math.floor(time[2]);

      onAlert(`Оставшееся время на выполнение: ${time[0]}:${time[1]}:${sec < 10 ? 0 : ""}${sec}`);
      let allTimeInSec = hour + min + sec;
      const timeInter = (allTimeInSec / 100) * 1000;
      let valueNow = ProgressValue;
      intervall.current = setInterval(() => {
        valueNow += 1;
        if (valueNow >= 100) {
          clearInterval(interval);
          onAlert("Время закончилось!", "error");
          ReadyFinishTest();
        } else {
          setProgressValue(valueNow);
        }
      }, timeInter);
    }

    return () => {
      console.log("clearInterval");
      clearInterval(intervall.current);
      intervall.current = null;
    };
  }, [ActiveSession]);

  if (isLoading) return <h1>Загрузка...</h1>;

  if (!ActiveSession.success) {
    return <h1>Нет активных тестов</h1>;
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
      <Question quest={ActiveSession.questions} token={User.token} />
      <Progress ProgressValue={ProgressValue} />
      <div className="finish-btn-wrapper">
        <button className="finish-btn" onClick={onFinishTest}>
          Завершить выполнение
        </button>
      </div>

      <ConfirmeEnd
        IsReadyToCloseSession={IsReadyToCloseSession}
        ReadyFinishTest={ReadyFinishTest}
        AbortFinishTest={AbortFinishTest}
      />
    </div>
  );
};

export default Test;
