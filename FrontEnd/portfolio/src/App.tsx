import React from 'react';
import AppRoutes from './routes/AppRoutes';
import '../node_modules/bootstrap/dist/css/bootstrap.css';
import '../node_modules/bootstrap/dist/js/bootstrap.bundle';
import NavBar from './pages/admin/components/navBar/Index';
import { BrowserRouter } from 'react-router-dom';

function App() {
  const loginPage = location.href.includes("login");
  return (
    <div className='container'>
      <BrowserRouter>
        {!loginPage && < NavBar />}
          <AppRoutes />
      </BrowserRouter>
    </div>

  );
}

export default App;
