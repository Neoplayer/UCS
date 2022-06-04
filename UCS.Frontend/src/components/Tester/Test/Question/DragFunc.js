import HandleUploadImg from "./HandleUploadImg";

export const HandleDrag = (e) => {
  e.preventDefault();
  e.stopPropagation();
};

export const HandleDragIn = (e, dragCounter, setDragCounter, setIsDragNow) => {
  e.preventDefault();
  e.stopPropagation();
  let count = dragCounter;
  setDragCounter(dragCounter + 1);
  if (count + 1 > 0) {
    setIsDragNow(true);
  }
};

export const HandleDragOut = (e, dragCounter, setDragCounter, setIsDragNow) => {
  e.preventDefault();
  e.stopPropagation();
  let count = dragCounter;
  setDragCounter(dragCounter - 1);
  if (count - 1 === 0) {
    setIsDragNow(false);
  }
};

export const HandleDrop = (
  e,
  setDragCounter,
  setIsDragNow,
  setFilesToUpload,
  FilesToUpload,
  questionId,
  index,
  UserFiles,
  setUserFiles,
  token,
) => {
  e.preventDefault();
  e.stopPropagation();
  setIsDragNow(false);
  setDragCounter(0);

  if (e.dataTransfer.files) {

    let file = e.dataTransfer.files.item(0);
    if (file) {
      HandleUploadImg(file, index, questionId, UserFiles, setUserFiles, token);
    }
  }
};
