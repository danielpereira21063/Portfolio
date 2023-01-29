import React, { useContext } from "react";
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import NavBar from "../pages/admin/components/navBar/Index";
import Admin from "../pages/admin/Index";
import Login from "../pages/admin/login/Index";
import Perfil from "../pages/admin/perfil/Index";
import Home from "../pages/home/Index";

function AppRoutes() {
  const usuarioAutenticado = localStorage.getItem("usuario") != null;

  return (
    <BrowserRouter>
      <Routes>
        {/* ROTAS PÚBLICAS */}
        <Route path='/' element={<Home />}></Route>
        <Route path="/admin/login" element={<Login />}></Route>


        {/* ROTAS PRIVADAS */}
        <Route path='/admin' element={usuarioAutenticado ? <><NavBar /><Admin /></> : <Navigate to={"/admin/login"} />}></Route>
        <Route path="/admin/perfil" element={usuarioAutenticado ? <><NavBar /><Perfil/></> : <Navigate to={"/admin/login"} />}></Route>
        <Route path="/admin/projeto/novo" element={usuarioAutenticado ? <><NavBar /><h1>Novo projeto</h1></> : <Navigate to={"/admin/login"} />}></Route>
        

        {/* 404 */}
        <Route path='*' element={<><NavBar /> <h1 style={{ textAlign: 'center' }}>404 NOT FOUND!</h1></>}></Route>
      </Routes>
    </BrowserRouter>
  )
}

export default AppRoutes;