import ContentBlock from "./contentBlock.jsx";
import "./content.css";
import { useState } from "react";
import AlertWindow from "./alertWindow.jsx";

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
      <AlertWindow
        isVisible={isVisible}
        state={state}
        handleClick={handleClick}
        now={now}
      />
      <article className="contentBlock">
        {data.map((data) => (
          <ContentBlock
            key={data.id} //для работы react
            title={data.title}
            content={data.content}
            username={data.username}
            id={data.id}
            handleClick={handleClick}
          />
        ))}
      </article>
    </main>
  );
}
