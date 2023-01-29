import { CssBaseline } from '@mui/material';
import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
// import { config } from 'dotenv';
import 'dotenv/config'

// const env = process.env.NODE_ENV || 'development';
// const path = `./../.env.${env}`;
// config({ path: path });

// console.log(process.env.API_URL, path);


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <CssBaseline>
    <App />
  </CssBaseline>
);
