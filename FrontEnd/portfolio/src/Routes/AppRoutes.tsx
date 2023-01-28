import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Admin from "../pages/admin/Index";
import Login from "../pages/admin/login/Index";
import Home from "../pages/home/Index";
import PrivateRoute from "./PrivateRoute";

function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Home />}></Route>
        {/* <PrivateRoute path='/admin' element={<Admin />}></PrivateRoute> */}
        <Route path='/admin' element={<Admin />}></Route>
        <Route path='/admin/login' element={<Login />}></Route>
        <Route path='*' element={<h1 style={{ textAlign: 'center' }}>404 NOT FOUND!</h1>}></Route>
      </Routes>
    </BrowserRouter>
  )
}

export default AppRoutes;