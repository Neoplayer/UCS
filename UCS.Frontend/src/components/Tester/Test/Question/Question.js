import React, { useMemo, useState } from "react";
import { GetImageByGuid, SendRemoveAnswer, SendUserAnswerImg } from "../../../../api/api";
import "./Questions.scss";
import clip from "./clip.png";
import UserData from "./UserData";
import { onAlert } from "../../../Alert/Aler";
import { HandleDrag, HandleDragIn, HandleDragOut, HandleDrop } from "./DragFunc";
import HandleUploadImg from "./HandleUploadImg";

const Question = ({ quest, token, setFullImgData }) => {
  let InitionalUserFiles = [...Array(quest.length)].map((arr, i) => {
    return { ...quest[i], index: i, userData: null };
  });

  const [UserFiles, setUserFiles] = useState(InitionalUserFiles);
  const [dragCounter, setDragCounter] = useState(0);
  const [isDragNow, setIsDragNow] = useState(false);
  const [FilesToUpload, setFilesToUpload] = useState([]);

  const QuestionMap = useMemo(() => {
    return UserFiles.map((el, i) => {
      let showLabelUpload = true;
      if (UserFiles[i].answerImageId || UserFiles[i].userData) {
        showLabelUpload = false;
      }
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
                src={GetImageByGuid(el.questionImageId)}
                alt="Картинка вопроса"
                onClick={() =>
                  setFullImgData({ imgUrl: el.questionImageId, question: el.body })
                }
              />
            </div>

            <div className={`user-file-wrapper`}>
              <label
                onDragLeave={(e) =>
                  HandleDragOut(e, dragCounter, setDragCounter, setIsDragNow)
                }
                onDragOver={HandleDrag}
                onDrop={(e) =>
                  HandleDrop(
                    e,
                    setDragCounter,
                    setIsDragNow,
                    setFilesToUpload,
                    FilesToUpload,
                    el.questionId,
                    i,
                    UserFiles,
                    setUserFiles,
                    token,
                  )
                }
                onDragEnter={(e) =>
                  HandleDragIn(e, dragCounter, setDragCounter, setIsDragNow, token)
                }
                className={`label ${showLabelUpload ? "" : "label-hidden"}`}
              >
                <img className="clip" src={clip} alt="Добавить" />
                <span className="title">Добавить ответ</span>
                <span className="accept-files">.png, .jpg, .jpeg</span>
                <input
                  onChange={(event) => {
                    HandleUploadImg(
                      event.target.files[0],
                      i,
                      el.questionId,
                      UserFiles,
                      setUserFiles,
                      token,
                    );
                    return;
                  }}
                  accept=".png, .jpg, .jpeg"
                  className="user-file"
                  type="file"
                  name="file"
                  id="user-file"
                />
              </label>

              <UserData
                setUserFiles={setUserFiles}
                UserFiles={UserFiles}
                index={i}
                questionId={el.questionId}
                body={el.body}
                answerImageId={el.answerImageId}
                token={token}
                questionImageId={el.questionImageId}
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
