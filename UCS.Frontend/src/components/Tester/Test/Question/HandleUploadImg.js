import { SendUserAnswerImg } from "../../../../api/api";
import { onAlert } from "../../../Alert/Aler";

const HandleUploadImg = async (
  data,
  index,
  questionId,
  UserFiles,
  setUserFiles,
  token,
) => {
  const fileObject = {
    index: index,
    data: data,
  };
  let newArr = [...UserFiles];
  // newArr[index] = fileObject;
  newArr[index] = {
    ...UserFiles[index],
    userData: fileObject,
  };
  setUserFiles(newArr);
  // send to server
  const formData = new FormData();
  formData.append("file", data);
  await SendUserAnswerImg(formData, token, questionId).then((res) => {
    if (res.status === 200) onAlert("Ответ был сохранен и отправлен");
    else {
      onAlert(
        "Произошла ошибка на стороне сервера. Обновите страницу и попробуйте снова!",
        "error",
      );
    }
  });

  // alert !
};

export default HandleUploadImg;
