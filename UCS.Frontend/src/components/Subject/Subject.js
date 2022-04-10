import React, { useContext, useEffect, useState } from "react";
import { getSubjects } from "../../api/api";
import Context from "../../context/Context";
import SubjectsMap from "./SubjectsMap";
import "./SubjectStyle.scss";

const Subject = () => {
  const { User } = useContext(Context);
  const [Subjects, setSubjects] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  useEffect(() => {
    getSubjects(User.token).then((res) => {
      console.log(res);
      setSubjects(res);
      setIsLoading(false);
    });

    return () => {};
  }, []);

  if (isLoading) return <h1>Загрузка...</h1>;

  return (
    <div className="Subject">
      <h1 className="header-text">Дисциплины</h1>
      <div className="subjects-wrapper">
        <SubjectsMap Subjects={Subjects} />
      </div>
    </div>
  );
};

export default Subject;
