import React, { useContext } from "react";
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import NavBar from "../pages/admin/components/navBar/Index";
import Admin from "../pages/admin/Index";
import Login from "../pages/admin/login/Index";
import Perfil from "../pages/admin/perfil/Index";
import NovoProjeto from './../pages/admin/projeto/Novo';
import Projeto from "../pages/admin/projeto/Index";

function AppRoutes() {
  const usuarioAutenticado = localStorage.getItem("usuario") != null;

  return (
    
      <Routes>
        {/* ROTAS PÚBLICAS */}
        <Route path="/admin/login" element={<Login />}></Route>


        {/* ROTAS PRIVADAS */}
        <Route path='/' element={usuarioAutenticado ? <><Admin /></> : <Navigate to={"/admin/login"} />}></Route>
        <Route path='/admin' element={usuarioAutenticado ? <><Admin /></> : <Navigate to={"/admin/login"} />}></Route>
        <Route path="/admin/perfil" element={usuarioAutenticado ? <><Perfil /></> : <Navigate to={"/admin/login"} />}></Route>
        <Route path="/admin/projeto/novo/:id" element={usuarioAutenticado ? <NovoProjeto /> : <Navigate to={"/admin/login"} />}></Route>


        {/* 404 */}
        <Route path='*' element={<> <h1 style={{ textAlign: 'center' }}>404 NOT FOUND!</h1></>}></Route>
      </Routes>
  )
}

export default AppRoutes;







// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER
// MESCLAR BRANCH COM A MASTER