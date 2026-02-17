import "./authPage.css";

export default function RegisterPage({}) {
  return (
    <main className="content">
      <form id="registerForm">
        <div id="usernameBlock" className="formBlock">
          <label
            htmlFor="usernameInput"
            className="inputLabel comfortaa-regular"
          >
            username
          </label>
          <input type="text" id="usernameInput" name="username"></input>
        </div>

        <div id="emailBlock" className="formBlock">
          <label htmlFor="emailInput" className="inputLabel comfortaa-regular">
            email
          </label>
          <input type="email" id="emailInput" name="email"></input>
        </div>

        <div id="passwordBlock" className="formBlock">
          <label
            htmlFor="passwordInput"
            className="inputLabel comfortaa-regular"
          >
            password
          </label>
          <input type="password" id="passwordInput" name="password"></input>
        </div>
        <div className="formBlock">
          <button type="submit" className="comfortaa-regular">
            Отправить
          </button>
        </div>
      </form>
    </main>
  );
}
