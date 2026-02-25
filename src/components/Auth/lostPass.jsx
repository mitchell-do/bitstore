import { useState } from "react";
import "./authPage.css";

export default function LostPassword() {
  let [alertVisible, alertVisibleSet] = useState("hidden");
  return (
    <main className="content" style={{ backgroundColor: "rgba(0,0,0,0)" }}>
      <div className="lostPassword">
        <form id="lostPasswordForm">
          <h1 className="hTitle comfortaa-regular">Сброс пароля</h1>

          {/* поле email пользователя */}
          <div id="emailBlock" className="formBlock">
            <label
              htmlFor="emailInput"
              className="inputLabel comfortaa-regular"
            >
              email
            </label>
            <input
              type="email"
              id="emailInput"
              name="email"
              className="inputBlock comfortaa-regular"
              required
            ></input>
          </div>

          {/* кнопка отправки формы регистрации */}
          <div id="submitButtonBlock" className="formBlock">
            <button
              id="lostPassword"
              type="submit"
              className="submitButton comfortaa-regular"
              onClick={() => alertVisibleSet("visible")}
            >
              отправить
            </button>
          </div>

          <span
            className="alert"
            style={{
              visibility: { alertVisible },
            }}
          >
            <p className="comfortaa-regular" style={{ color: "white" }}>
              Ждите письмо на указанную почту, с помощью которого вы сможете
              сменить пароль
            </p>
          </span>
        </form>
      </div>
    </main>
  );
}
