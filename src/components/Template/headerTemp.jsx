import "./templates.css";

export default function HeaderTemp({ children }) {
  function handleClickMenu() {}

  return (
    <nav className="navigate">
      <ul className="header comfortaa-regular">
        <li id="storeNameBlock">
          <a id="storeName" href="/">
            битстор.рф
          </a>
        </li>
        <li id="storePageStatusBlock">
          <a id="storePageStatus">{children}</a>
        </li>
        <li id="storeMenuBlock">
          <a id="storeMenu" href="auth">
            меню
          </a>
        </li>
      </ul>
    </nav>
  );
}
