const _URL = "http://194.58.107.109";

export const FetchReq = async (url, token = null, method = "GET", ownHeader = null) => {
  let requestOptions = null;
  if (ownHeader) requestOptions = ownHeader;
  else {
    requestOptions = {
      method: method,
      headers: { "Content-Type": "application/json", Authorization: token },
    };
  }
  return await fetch(_URL + url, requestOptions);
};

export const sendLogin = async (username, password) => {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ username: username, password: password }),
  };

  return await fetch(_URL + "/Users/Authenticate", requestOptions).then((response) =>
    response.json(),
  );
};

export const getUserByToken = async (token) => {
  return await FetchReq("/Users/GetUser", token).then((response) => response.json());
};

export const getSubjects = async (token) => {
  return FetchReq("/Catalog/GetUserCatalog", token).then((res) => res.json());
};

export const getTopicInfo = async (id) => {
  return FetchReq("/Catalog/GetTopicInfo?topicId=" + id, null).then((res) => res.json());
};

export const GetActiveSession = async (token) => {
  return FetchReq("/Testing/GetActiveSession", token).then((res) => res.json());
};

export const GetStartSession = async (topicId, token) => {
  return FetchReq("/Testing/StartSession?topicId=" + topicId, token).then((res) =>
    res.json(),
  );
};

export const GetImageByGuid = (imageGuid) => {
  return `${_URL}/Image/GetFileByGuid?imageGuid=${imageGuid}`;
};

export const SendUserAnswerImg = async (image, token, questionId) => {
  const requestOptions = {
    method: "POST",
    headers: { Authorization: token },
    body: image,
  };
  return await FetchReq(
    `/Testing/SendAnswer?questionId=${questionId}`,
    token,
    "POST",
    requestOptions,
  );
};

export const SendRemoveAnswer = async (questionId, token) => {
  return await FetchReq(`/Testing/RemoveAnswer?questionId=${questionId}`, token);
};

export const SendFinishSession = async (token) => {
  return await FetchReq("/Testing/FinishSession", token).then((response) => response.json());
};

