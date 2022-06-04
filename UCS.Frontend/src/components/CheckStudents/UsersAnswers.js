import React, { useContext } from "react";
import UserAnswer from "./UserAnswer";
import "./CheckStudents.scss";

const UsersAnswers = ({
  TestToCheck,
  setImageGuid,
  isAnsweredAlready = false,
  UseHintBtn = false,
}) => {
  if (!TestToCheck) return null;

  if (TestToCheck.length === 0)
    return <h1 style={{ textAlign: "center" }}>Контрольный работ на проверку нет</h1>;

  const TestToCheckMap = TestToCheck.map((el, index) => {
    return (
      <UserAnswer
        key={index}
        UserData={el.user}
        TaskData={el.questions}
        TimeStart={el.startDateTime}
        TimeFinish={el.finishDatetime}
        TaskInfo={el.topicInfo}
        Index={index + 1}
        setImageGuid={setImageGuid}
        sessionId={el.id}
        comment={el.comment}
        result={el.result}
        isAnsweredAlready={isAnsweredAlready}
        UseHintBtn={UseHintBtn}
      />
    );
  });
  return <ul className="users-data">{TestToCheckMap}</ul>;
};

export default UsersAnswers;
