import { useState } from "react";
// import reactLogo from "./assets/react.svg";

import { BrowserRouter, Routes, Route } from "react-router-dom";
import Content from "./components/Index/content.jsx";
import AuthPage from "./components/Auth/authpage.jsx";
import LostPassword from "./components/Auth/lostPass.jsx";

import "./app.css";
import HeaderTemp from "./components/Template/headerTemp.jsx";
import RegisterPage from "./components/Auth/registerPage.jsx";

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route
          path="*"
          element={
            <div className="divBody">
              <HeaderTemp></HeaderTemp>
              <Content />
            </div>
          }
        />
        <Route
          path="auth"
          element={
            <div className="divBody">
              <HeaderTemp></HeaderTemp>
              <AuthPage />
            </div>
          }
        />

        <Route
          path="lostPassword"
          element={
            <div className="divBody">
              <HeaderTemp></HeaderTemp>
              <LostPassword />
            </div>
          }
        />

        <Route
          path="reg"
          element={
            <div className="divBody">
              <HeaderTemp></HeaderTemp>
              <RegisterPage />
            </div>
          }
        />
      </Routes>
    </BrowserRouter>
  );
}
