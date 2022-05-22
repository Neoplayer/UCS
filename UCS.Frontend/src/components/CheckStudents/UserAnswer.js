import React, { useMemo, useState } from "react";
import { motion } from "framer-motion";
import { GetImageByGuid } from "../../api/api";

const UserAnswer = ({ UserData, TaskData, Time, TaskInfo, Index, setImageGuid }) => {
  const [ActivateCheck, SetActivateCheck] = useState(false);

  let date = useMemo(() => new Date(Time), [Time]);

  date = date.toLocaleDateString("ru-RU", {
    day: "2-digit",
    year: "numeric",
    month: "2-digit",
    hour: "2-digit",
    minute: "2-digit",
  });

  const LetsCheck = TaskData.map((task, index) => {
    return (
      <div className="check-wrapper" key={index}>
        <p className="question">
          <span className="num">{index + 1}.</span> {task.body}
        </p>
        <div className="img-wrapper">
          {task.questionImageId ? (
            <img
              onClick={() => setImageGuid(task.questionImageId)}
              src={GetImageByGuid(task.questionImageId)}
              alt="Рисунок вопроса"
            />
          ) : (
            <h1>Изображение с вопросом не найдено</h1>
          )}
          {task.answerImageId ? (
            <img
              onClick={() => setImageGuid(task.answerImageId)}
              src={GetImageByGuid(task.answerImageId)}
              alt="Ответ не найден"
            />
          ) : (
            <h1>Ответ на вопрос не найден</h1>
          )}
        </div>
      </div>
    );
  });

  return (
    <li className={`user ${ActivateCheck ? "active-user" : ""}`}>
      <div
        className="user-personal-data"
        onClick={() => SetActivateCheck((prev) => !prev)}
      >
        <p className="name">
          <span className="num">{Index}.</span>
          {UserData.lastName} {UserData.firstName} {UserData.middleName}
        </p>
        <p className="way">
          <span className="space-divider">|</span>
          {TaskInfo.subjectName} {" ➜ "}
          {TaskInfo.charapterName} {" ➜ "}
          {TaskInfo.topicName}
        </p>

        <p className="date-pass">
          <span className="space-divider">|</span>
          {date}
        </p>
      </div>
      {ActivateCheck && LetsCheck}
    </li>
  );
};

export default UserAnswer;
