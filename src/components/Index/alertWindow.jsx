import React from "react";

{
  /* <div
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
      </div> */
  //   код ниже РАВНОЗНАЧЕН коду выше, написан ради практики
}

const e = React.createElement;

export default function AlertWindow({ isVisible, state, handleClick, now }) {
  return e(
    "div",
    {
      className: "buyAlert",
      style: { visibility: isVisible ? "hidden" : "visible" },
    },
    [
      e("a", { className: "comfortaa-regular" }, [
        now.toLocaleDateString(),
        e("hr", null, null),
        state !== null ? `Вы хотите купить \"${state}\" ?` : null,
      ]),
      e("div", { className: "containerButton" }, [
        e(
          "button",
          {
            id: "yesAnswer",
            className: "blockButton comfortaa-regular",
            onClick: () => handleClick(null, 1),
          },
          "Да",
        ),
        e(
          "button",
          {
            id: "noAnswer",
            className: "blockButton comfortaa-regular",
            onClick: () => handleClick(null, 1),
          },
          "Нет",
        ),
      ]),
    ],
  );
}
