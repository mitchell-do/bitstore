export default function ContentBlock({
  title,
  content,
  username,
  id,
  handleClick,
}) {
  return (
    <section id="product">
      <div id="infoBeat">
        <a id="blockUsername" className="comfortaa-regular">
          {username}
        </a>
        <a id="blockTitle" className="comfortaa-regular">
          {title}
        </a>
        <hr className="line" />
        <a id="blockContent" className="comfortaa-regular">
          {content}
        </a>
      </div>
      <div className="activeBlock">
        <audio
          className="audio"
          controls
          src="/shared-assets/audio/t-rex-roar.mp3"
        ></audio>
        <div className="containerButton">
          <button
            id={id}
            className="blockButton comfortaa-regular"
            onClick={() => handleClick(title, 0)}
          >
            💵
          </button>
          <button
            id={id}
            className="blockButton comfortaa-regular"
            onClick={() => handleClick(title, 0)}
          >
            ✉️
          </button>
          <button
            id={id}
            className="blockButton comfortaa-regular"
            onClick={() => handleClick(title, 0)}
          >
            ❤️
          </button>
        </div>
      </div>
    </section>
  );
}
