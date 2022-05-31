import React, { useMemo, useState } from "react";
import { motion } from "framer-motion";
import { GetImageByGuid } from "../../api/api";
import ResultTestForm from "./ResultTestForm";
import CurrentAnswer from "./CurrentAnswer";

const UserAnswer = ({
  UserData,
  TaskData,
  Time,
  TaskInfo,
  Index,
  setImageGuid,
  sessionId,
  comment,
  result,
  isAnsweredAlready,
}) => {
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
      <CurrentAnswer key={index} setImageGuid={setImageGuid} task={task} index={index} />
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
      {ActivateCheck && (
        <ResultTestForm
          sessionId={sessionId}
          comment={comment}
          result={result}
          isAnsweredAlready={isAnsweredAlready}
        />
      )}
    </li>
  );
};

export default UserAnswer;
