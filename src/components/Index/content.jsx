import ContentBlock from "./contentBlock.jsx";
import "./content.css";
import { useState } from "react";

let data = [
  {
    id: 1,
    title: "och krutoy bit",
    content: "#jugg",
    username: "morgenshtern",
  },
  {
    id: 2,
    title: "mlncr 180bpm",
    content: "#MYLANCORE",
    username: "morgenshtern",
  },
  {
    id: 3,
    title: "mlncr 180bpm",
    content: "#MYLANCORE",
    username: "morgenshtern",
  },
  {
    id: 4,
    title: "mlncr 180bpm",
    content: "#MYLANCORE",
    username: "morgenshtern",
  },
  {
    id: 5,
    title: "mlncr 180bpm",
    content: "#MYLANCORE",
    username: "morgenshtern",
  },
];

export default function Content() {
  const [state, setState] = useState(null);
  const [isVisible, setVisible] = useState(1);
  const [now, setTime] = useState(new Date());

  setInterval(() => setTime(new Date()), 1000);

  function handleClick(titleState, visibleState) {
    setState(titleState);
    setVisible(visibleState);
  }

  return (
    <main className="content">
      <div
        className="buyAlert"
        style={{ visibility: isVisible ? "hidden" : "visible" }}
      >
        <a className="comfortaa-regular">
          {now.toLocaleDateString()}
          <hr></hr>
          {state !== null ? `Вы хотите купить \"${state}\" ?` : null}
        </a>
        <div className="containerButton">
          <button
            id="yesAnswer"
            className="blockButton comfortaa-regular"
            onClick={() => handleClick(null, 1)}
          >
            Да
          </button>
          <button
            id="noAnswer"
            className="blockButton comfortaa-regular"
            onClick={() => handleClick(null, 1)}
          >
            Нет
          </button>
        </div>
      </div>
      <article className="contentBlock">
        <ContentBlock
          title={data[0].title}
          content={data[0].content}
          username={data[0].username}
          id={data[0].id}
          handleClick={handleClick}
        />
        <ContentBlock
          title={data[1].title}
          content={data[1].content}
          username={data[1].username}
          id={data[1].id}
          handleClick={handleClick}
        />
        <ContentBlock
          title={data[1].title}
          content={data[1].content}
          username={data[1].username}
          id={data[1].id}
          handleClick={handleClick}
        />
        <ContentBlock
          title={data[1].title}
          content={data[1].content}
          username={data[1].username}
          id={data[1].id}
          handleClick={handleClick}
        />
        <ContentBlock
          title={data[1].title}
          content={data[1].content}
          username={data[1].username}
          id={data[1].id}
          handleClick={handleClick}
        />
      </article>
    </main>
  );
}
