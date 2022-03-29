const _URL = "http://localhost:5000/Users";

export const Auth = async (email, password) => {
  try {
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ username: email, password: password }),
    };

    const response = await fetch(_URL + "/Authenticate", requestOptions);
    return await response.json();
  } catch (error) {
    console.log(error);
    return await "404";
  }
};

export const RegistrationNewUser = async (email, login, password) => {
  try {
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        username: login,
        email: email,
        password: password,
      }),
    };

    const response = await fetch(_URL + "/Register", requestOptions);
    return await response.json();
  } catch (error) {
    console.log(error);
    return Promise.reject();
  }
};

export const GetUser = async (token) => {
  const requestOptions = {
    method: "GET",
    headers: {
      Authorization: token,
      "content-type": "application/json",
      charset: "utf-8",
    },
  };
  try {
    const response = await fetch(_URL + "/GetUser", requestOptions);
    // const res = await response.json();
    // return res
  } catch (error) {
    console.log(error);
  }
};
