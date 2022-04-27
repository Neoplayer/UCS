import React, { useContext, useEffect, useState } from "react";
import "./CheckStudents.scss";
import { getGroupsToCheck } from "../../api/api";
import Context from "../../context/Context";
const CheckStudents = () => {
  const { User } = useContext(Context);

  const [isLoading, setIsLoading] = useState(true);
  const [CheckArr, setCheckArr] = useState(null);

  useEffect(() => {
    let onLoad = true;
    getGroupsToCheck(User.token).then((res) => {
      if (onLoad) {
        console.log(res);
        setCheckArr(res);
        setIsLoading(false);
      }
    });

    return () => {
      onLoad = false;
    };
  }, []);

  if (isLoading) return <h1>Загрузка ...</h1>;

  return (
    <div className="CheckStudents">
      <h1 className="header-text">Проверка работ студентов</h1>

    </div>
  );
};

export default CheckStudents;
