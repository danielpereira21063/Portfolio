import NavBar from './pages/admin/components/navBar/Index';
import React from 'react';
import { Route } from 'react-router-dom';
import { AuthProvider, AuthContext } from './context/AuthContext';
import Login from './pages/admin/login/Index';
import AppRoutes from './routes/AppRoutes';
import { Box } from '@mui/material';
import { Container } from '@mui/system';

function App() {
  return (
    <AuthProvider>
      <Container maxWidth="lg">
        <AppRoutes />
      </Container>
    </AuthProvider>
  );
}

export default App;
