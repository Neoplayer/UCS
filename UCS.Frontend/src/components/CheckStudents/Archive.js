import React, { useContext, useState } from "react";
import { GetArchive } from "../../api/api";
import Context from "../../context/Context";
import UsersAnswers from "./UsersAnswers";

const Archive = ({ setImageGuid }) => {
  const { User } = useContext(Context);

  const [isLoading, setIsLoading] = useState(false);
  const [ArchiveData, setArchiveData] = useState([]);
  const getArchive = async () => {
    setIsLoading(true);
    const data = await GetArchive(User.token);
    setIsLoading(false);
    setArchiveData(data);
  };

  return (
    <div className="Archive">
      <button className="getArchive-btn" onClick={() => getArchive()}>
        Архив проверенных работ
      </button>
      {isLoading ? <h1>Загрузка</h1> : null}
      {ArchiveData.length > 0 ? (
        <UsersAnswers
          setImageGuid={setImageGuid}
          TestToCheck={ArchiveData}
          isAnsweredAlready={true}
        />
      ) : null}
    </div>
  );
};

export default Archive;
