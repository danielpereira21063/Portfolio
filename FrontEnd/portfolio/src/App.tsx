import React from 'react';
import { AuthProvider, AuthContext } from './context/AuthContext';
import AppRoutes from './Routes/AppRoutes';

function App() {
  return (
    <AuthProvider>
      <AppRoutes />
    </AuthProvider>
  );
}

export default App;
