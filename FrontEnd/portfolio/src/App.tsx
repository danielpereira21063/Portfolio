import React from 'react';
import AppRoutes from './routes/AppRoutes';
import '../node_modules/bootstrap/dist/css/bootstrap.css';
import '../node_modules/bootstrap/dist/js/bootstrap.bundle';
import NavBar from './pages/admin/components/navBar/Index';

function App() {
  const loginPage = location.href.includes("login");
  return (
    <main>
      {!loginPage && < NavBar />}
      <div className='container'>
        <AppRoutes />
      </div>
    </main>

  );
}

export default App;
