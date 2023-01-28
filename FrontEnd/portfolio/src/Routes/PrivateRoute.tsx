import React, { useContext } from 'react';
import { Route, Navigate, redirect } from 'react-router-dom';
import { AuthContext } from '../context/AuthContext';
import Login from '../pages/admin/login/Index';

const PrivateRoute: React.FC<any> = ({ component: Component, ...rest }) => {
  const { authenticated } = useContext(AuthContext);

  if(!authenticated) location.href = "/admin/login";

  return (
    <Route {...rest} render={(props: any) => <Component {...props}></Component>} />
  );
};


export default PrivateRoute;