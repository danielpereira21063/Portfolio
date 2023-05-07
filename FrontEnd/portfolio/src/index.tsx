import React from 'react';
import App from './App';
// import { config } from 'dotenv';
import 'dotenv/config'
import ReactDOM from 'react-dom/client';

// const env = process.env.NODE_ENV || 'development';
// const path = `./../.env.${env}`;
// config({ path: path });

// console.log(process.env.API_URL, path);

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <App />
);
