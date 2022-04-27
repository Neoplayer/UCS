import React from "react";
import { GetImageByGuid, SendRemoveAnswer } from "../../../../api/api";

const UserData = ({
  setUserFiles,
  UserFiles,
  index,
  questionId,
  token,
  answerImageId,
  body,
  questionImageId,
}) => {
  let URLuploadIMG = null;

  const onDelete = async () => {
    try {
      const answer = await SendRemoveAnswer(questionId, token);
      if (answer.success) {
        let newArr = [...UserFiles];
        newArr[index] = { ...UserFiles[index], userData: null, answerImageId: null };
        setUserFiles(newArr);
        URLuploadIMG = null;
        // let newQuestionArr = [...Question];
        // newQuestionArr[index] = {
        //   answerImageId: null,
        //   body: body,
        //   questionId: questionId,
        //   questionImageId: questionImageId,
        // };
        // setQuestion(newQuestionArr);
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

  if (UserFiles[index].userData === null) return null;
  console.log("UserFiles[index]", UserFiles[index]);
  URLuploadIMG = URL.createObjectURL(UserFiles[index].userData.data);

  return (
    <div className="user-data">
      <img
        className="user-data-img"
        src={URLuploadIMG}
        alt={UserFiles[index].userData.data.name}
      />
      <p className="user-data-name">{UserFiles[index].userData.data.name}</p>
      <p className="user-data-size">{UserFiles[index].userData.data.size} Байт</p>
      <button className="user-data-deleteImg" onClick={onDelete}>
        Удалить ответ
      </button>
    </div>
  );
};

export default UserData;
