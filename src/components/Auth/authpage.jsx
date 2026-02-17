import "./authPage.css";

export default function AuthPage({}) {
  return (
    <main className="content">
      <article className="contentBlock"></article>

      <form id="authForm">
        <a>Вход</a>

        <div id="usernameBlock">
          <label htmlFor="usernameInput">username</label>
          <input type="text" id="usernameInput" name="username"></input>
        </div>
        <div id="passwordBlock">
          <label htmlFor="passwordInput">password</label>
          <input type="password" id="passwordInput" name="password"></input>
        </div>
        <button type="submit">Отправить</button>
      </form>
    </main>
  );
}
