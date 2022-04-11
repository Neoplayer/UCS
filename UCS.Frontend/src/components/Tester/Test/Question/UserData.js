import React from "react";
import { GetImageByGuid, SendRemoveAnswer } from "../../../../api/api";

const UserData = ({
  setUserFiles,
  UserFiles,
  index,
  questionId,
  token,
  answerImageId,
}) => {
  const onDelete = async () => {
    try {
      const answer = await SendRemoveAnswer(questionId, token);
      if (answer.success) {
        let newArr = [...UserFiles];
        newArr[index] = { index: index, data: null };
        setUserFiles(newArr);
      }
    } catch (error) {
      console.log(error);
    }
  };

  if (answerImageId) {
    return (
      <div className="user-data">
        <img
          className="user-data-img"
          src={GetImageByGuid(answerImageId, token)}
          alt="Изображение с ответом"
        />
        <button className="user-data-deleteImg" onClick={onDelete}>
          Удалить ответ
        </button>
      </div>
    );
  }

  const CurrentImg = UserFiles.find((el) => el.index === index);

  if (CurrentImg.data === null) return null;

  return (
    <div className="user-data">
      <img
        className="user-data-img"
        src={URL.createObjectURL(CurrentImg.data)}
        alt={CurrentImg.data.name}
      />
      <p className="user-data-name">{CurrentImg.data.name}</p>
      <p className="user-data-size">{CurrentImg.data.size} Байт</p>
      <button className="user-data-deleteImg" onClick={onDelete}>
        Удалить ответ
      </button>
    </div>
  );
};

export default UserData;
