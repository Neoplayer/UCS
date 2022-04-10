import React, { useMemo, useState } from "react";
import { GetImageByGuid, SendRemoveAnswer, SendUserAnswerImg } from "../../../../api/api";
import "./Questions.scss";
import clip from "./clip.png";

const UserData = ({ image, index, questionId, token }) => {
  const CurrentImg = image.find((el) => el.index === index);

  if (CurrentImg.data === null) return null;

  const onDelete = () => {
    SendRemoveAnswer(questionId, token);
  };

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

const Question = ({ quest, token }) => {
  let InitionalUserFiles = [...Array(quest.length)].map((arr, i) => {
    return { index: i, data: null };
  });

  const [UserFiles, setUserFiles] = useState(InitionalUserFiles);

  const handleUpload = (event, index, questionId) => {
    console.log(event);
    let data = event.target.files[0];
    const fileObject = {
      index: index,
      data: data,
    };
    let newArr = [...UserFiles];
    newArr[index] = fileObject;
    setUserFiles(newArr);

    // send to server
    const formData = new FormData();
    formData.append("file", data);
    SendUserAnswerImg(formData, token, questionId);
  };

  const QuestionMap = useMemo(() => {
    return quest.map((el, i) => {
      console.log(i, el);
      return (
        <div key={i} className="quest">
          <div className="number-wrapper">
            <h2 className="number">Задание {i + 1}</h2>
          </div>

          <h3 className="main-question">{el.body}</h3>

          <div className="file-wrapper">
            <div className="img-wrapper">
              <img
                className="quest-img"
                src={GetImageByGuid(el.questionImageId, token)}
                alt="Картинка вопроса"
              />
            </div>

            <div className="user-file-wrapper">
              <label className="label">
                <img className="clip" src={clip} alt="Добавить" />
                <span className="title">Добавить ответ</span>
                <span className="accept-files">.png, .jpg, .jpeg</span>
                <input
                  onChange={(event) => handleUpload(event, i, el.questionId)}
                  accept=".png, .jpg, .jpeg"
                  className="user-file"
                  type="file"
                  name="file"
                  id="user-file"
                />
              </label>

              <UserData
                image={UserFiles}
                index={i}
                questionId={el.questionId}
                token={token}
              />
            </div>
          </div>
        </div>
      );
    });
  }, [quest, UserFiles]);
  if (!quest) return null;
  return <div className="Question">{QuestionMap}</div>;
};

export default Question;
