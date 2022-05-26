import React, { useContext, useEffect, useState } from "react";
import "./CheckStudents.scss";
import { GetTestsToCheck } from "../../api/api";
import Context from "../../context/Context";
import UsersAnswers from "./UsersAnswers";
import FullScreenImg from "./FullScreenImg";
import FindByName from "./FindByName";
import { onAlert } from "../Alert/Aler";

const CheckStudents = () => {
  const { User } = useContext(Context);

  const [CheckArr, setCheckArr] = useState(null);
  const [TestToCheck, setTestToCheck] = useState([]);
  const [FilteredTestToCheck, setFilteredTestToCheck] = useState(null);
  const [ImageGuid, setImageGuid] = useState(null);
  
  const [isLoading, setIsLoading] = useState(true);
  const [isError, setIsError] = useState(null);
  useEffect(() => {
    let onLoad = true;
    GetTestsToCheck(User.token).then((res) => {
      if (onLoad) {
        if (res.message) {
          onLoad = true;
          setIsError("У вас недостаточно прав");
          setIsLoading(false);
        } else {
          setTestToCheck(res);
          setIsLoading(false);
        }
      }
    });
    return () => {
      onLoad = false;
    };
  }, []);

  if (isError) return <h1>{isError}</h1>;
  if (isLoading) return <h1>Загрузка ...</h1>;
  const onFilter = (text) => {
    if (text && text !== "") {
      const filter = TestToCheck.filter((item) => {
        if (item.user.firstName.toLowerCase() === text.toLowerCase()) return true;
        if (item.user.lastName.toLowerCase() === text.toLowerCase()) return true;
        if (item.user.middleName.toLowerCase() === text.toLowerCase()) return true;
        return false;
      });
      console.log("filter", filter);
      if (filter.length === 0) {
        setFilteredTestToCheck(null);
        onAlert("Ничего не найдено", "error");
      } else {
        setFilteredTestToCheck(filter);
      }
    } else {
      setFilteredTestToCheck(null);
    }
  };

  return (
    <div className="CheckStudents">
      <h1 className="header-text">Проверка контрольных работ</h1>
      <FindByName onFilter={onFilter} />
      <UsersAnswers
        TestToCheck={FilteredTestToCheck ? FilteredTestToCheck : TestToCheck}
        setImageGuid={setImageGuid}
      />
      <FullScreenImg ImageGuid={ImageGuid} setImageGuid={setImageGuid} />
    </div>
  );
};

export default CheckStudents;
