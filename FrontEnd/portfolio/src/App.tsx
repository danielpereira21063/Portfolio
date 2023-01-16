import React from 'react';
import { Route, Routes } from 'react-router';
import { BrowserRouter } from 'react-router-dom';

import Home from "./Pages/Home/Index";
import Login from "./Pages/Admin/Login/Index";
import './App.css';
import Admin from './Pages/Admin/Index';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Home/>}></Route>
        <Route path='/admin' element={<Admin/>}></Route>
        <Route path='/admin/login' element={<Login/>}></Route>
        <Route path='*' element={<h1 style={{textAlign: 'center'}}>404 NOT FOUND!</h1>}></Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
