const _URL = "http://localhost:5000/Social/Chat";

export const GetAllChat = async (token) => {
  const requestOptions = {
    method: "GET",
    headers: {
      Authorization: token,
      "content-type": "application/json",
      charset: "utf-8",
    },
  };
  try {
    const response = await fetch(_URL + "/Get", requestOptions);
    const res = await response.json();
    return res
  } catch (error) {
    console.log(error);
  }
};

