import React, { useContext, useEffect, useState } from "react";
import { GetCheckedTests } from "../../api/api";
import Context from "../../context/Context";
import FullScreenImg from "../CheckStudents/FullScreenImg";
import UserAnswer from "../CheckStudents/UserAnswer";
import UsersAnswers from "../CheckStudents/UsersAnswers";

const AcademicPerformance = () => {
  const { User } = useContext(Context);
  const [CheckedTest, setCheckedTest] = useState([]);
  const [isloading, setIsloading] = useState(true);
  const [ImageGuid, setImageGuid] = useState(null);

  useEffect(() => {
    GetCheckedTests(User.token).then((res) => {
      setCheckedTest(res);
      setIsloading(false);
    });

    return () => {};
  }, []);

  if (isloading) return <h1>Загрузка...</h1>;
  return (
    <div>
      <UsersAnswers
        setImageGuid={setImageGuid}
        isAnsweredAlready={true}
        TestToCheck={CheckedTest}
        UseHintBtn={false}
      />

      <FullScreenImg ImageGuid={ImageGuid} setImageGuid={setImageGuid} />
    </div>
  );
};

export default AcademicPerformance;
