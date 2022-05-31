import React from "react";
import { GetImageByGuid } from "../../api/api";

const CurrentAnswer = ({ index, setImageGuid, task }) => {
  return (
    <div className="check-wrapper" key={index}>
      <p className="question">
        <span className="num">{index + 1}.</span> {task.body}
      </p>
      <button className="extraImg-btn" onClick={() => setImageGuid(task.hintImageId)}>
        Открыть подсказку
      </button>
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
};

export default CurrentAnswer;
