import React, { useContext } from "react";
import UserAnswer from "./UserAnswer";

const UsersAnswers = ({ TestToCheck, setImageGuid }) => {
  if (!TestToCheck) return null;

  const TestToCheckMap = TestToCheck.map((el, index) => {
    return (
      <UserAnswer
        key={index}
        UserData={el.user}
        TaskData={el.questions}
        Time={el.startDateTime}
        TaskInfo={el.topicInfo}
        Index={index + 1}
        setImageGuid={setImageGuid}
      />
    );
  });
  return <ul className="users">{TestToCheckMap}</ul>;
};

export default UsersAnswers;
