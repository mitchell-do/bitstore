import "./authPage.css";

export default function RegisterPage({}) {
  return (
    <main className="content" style={{ backgroundColor: "rgba(0,0,0,0)" }}>
      <div className="registration">
        <form id="registerForm">
          <h1 className="hTitle comfortaa-regular">RRегистрация</h1>

          {/* поле Имя пользователя */}
          <div id="usernameBlock" className="formBlock">
            <label
              htmlFor="usernameInput"
              className="inputLabel comfortaa-regular"
            >
              username
            </label>
            <input
              type="text"
              id="usernameInput"
              name="username"
              className="inputBlock comfortaa-regular"
              required
            ></input>
          </div>

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

          {/* поле пароль пользователя */}
          <div id="passwordBlock" className="formBlock">
            <label
              htmlFor="passwordInput"
              className="inputLabel comfortaa-regular"
            >
              password
            </label>
            <input
              type="password"
              id="passwordInput"
              name="password"
              className="inputBlock comfortaa-regular"
              required
            ></input>
          </div>

          {/* кнопка отправки формы регистрации */}
          <div id="submitButtonBlock" className="formBlock">
            <button type="submit" className="submitButton comfortaa-regular">
              отправить
            </button>
          </div>
        </form>

        <a href="auth" className="perehod comfortaa-regular">
          Уже есть аккаунт?
        </a>
      </div>
    </main>
  );
}
