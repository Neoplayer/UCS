import React, { useEffect, useState } from "react";
import { useNavigate, useParams, useSearchParams } from "react-router-dom";

const MobileQR = () => {
  let [searchParams] = useSearchParams();
  const navigate = useNavigate();
  const [IsValid, setIsValid] = useState(true);
  useEffect(() => {
    if (searchParams.get("token") && searchParams.get("token") !== "") {
      localStorage.setItem("token", searchParams.get("token"));
      navigate("/tester");
    } else {
      setIsValid(false);
    }
    return () => {};
  }, []);

  if (!IsValid) return <h1>Ошибка валидации токена</h1>;

  return (
    <div>
      <h1>Пожалуйста, подождите...</h1>
      <h2>Идет обновление данных</h2>
    </div>
  );
};

export default MobileQR;
