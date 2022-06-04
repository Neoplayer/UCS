import React, { useContext, useState } from "react";
import { sendResultToTest } from "../../api/api";
import Context from "../../context/Context";
import { onAlert } from "../Alert/Aler";
import "./CheckStudents.scss";

const ResultTestForm = ({ sessionId, result, comment, isAnsweredAlready }) => {
  const { User } = useContext(Context);
  const [isSentResult, setIsSentResult] = useState(false);
  const onSubmitHendler = async (e) => {
    e.preventDefault();
    e.stopPropagation();
    const result = e.target[0]?.value;
    const comment = e.target[1]?.value;

    await sendResultToTest(User.token, sessionId, result, comment).then((res) => {
      if (res.status === 200) {
        onAlert("Результат за КР отправлен на сервер!");
        setIsSentResult(true);
      }
    });
  };
  return (
    <form onSubmit={onSubmitHendler} className="ResultTestForm">
      <div className="estimation">
        <p>Оценка</p>
        <input
          readOnly={isAnsweredAlready}
          defaultValue={result}
          required
          type="number"
          max={10000}
          min={-10000}
        />
      </div>
      <div className="comment">
        <p>Комментарий</p>
        <textarea defaultValue={comment} readOnly={isAnsweredAlready} />
      </div>
      <input
        className={`send-result-btn ${isSentResult ? "sent-result" : ""} ${
          isAnsweredAlready ? "sent-result-hidden" : ""
        }`}
        type="submit"
        value="Отправить результат"
      />
    </form>
  );
};

export default ResultTestForm;
