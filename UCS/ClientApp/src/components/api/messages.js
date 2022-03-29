const _URL = "http://localhost:5000/Social/Messages";

export const GetChatByID = async (token, id) => {
  const requestOptions = {
    method: "GET",
    headers: {
      Authorization: token,
      "content-type": "application/json",
      charset: "utf-8",
    },
  };
  try {
    const response = await fetch(
      _URL + `/GetChat?chatId=${id}&count=50&page=1`,
      requestOptions
    );
    const res = await response.json();
    return res;
  } catch (error) {
    console.log(error);
  }
};

export const SendMessange = async (token, chatID, body) => {
  const requestOptions = {
    method: "POST",
    headers: {
      Authorization: token,
      "content-type": "application/json",
      charset: "utf-8",
    },
    body: JSON.stringify({
      chatId: chatID,
      body: body,
    }),
  };

  try {
    const response = await fetch(_URL + "/Send", requestOptions);
    const res = await response.json();
    return res;
  } catch (error) {
    console.log(error);
  }
};
