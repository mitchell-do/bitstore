import "./authPage.css";
export default function AuthPage({}) {
  return (
    <main className="content" style={{ backgroundColor: "rgba(0,0,0,0)" }}>
      <div className="auth">
        <form id="authForm">
          <h1 className="hTitle comfortaa-regular">Vход</h1>

          {/* поле Имя пользователя */}
          <div id="usernameBlock" className="formBlock">
            <label
              htmlFor="usernameInput"
              className="inputLabel comfortaa-regular"
            >
              username
            </label>
            <input type="text" id="usernameInput" name="username"></input>
          </div>

          {/* поле пароль пользователя */}
          <div id="passwordBlock" className="formBlock">
            <label
              htmlFor="passwordInput"
              className="inputLabel comfortaa-regular"
            >
              password
            </label>
            <input type="password" id="passwordInput" name="password"></input>
          </div>

          {/* кнопка отправки формы регистрации */}
          <div id="submitButtonBlock" className="formBlock">
            <button type="submit" className="submitButton comfortaa-regular">
              Отправить
            </button>
          </div>
        </form>
        <div className="perehodBlock">
          <a href="lostPassword" className="perehod comfortaa-regular">
            Забыли пароль?
          </a>
          <a href="reg" className="perehod comfortaa-regular">
            Нет аккаунта?
          </a>
        </div>
      </div>
    </main>
  );
}
