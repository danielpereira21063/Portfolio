import React, { useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import { AccountService } from '../../../../services/AccountService';

interface Props {
  /**
   * Injected by the documentation to work in an iframe.
   * You won't need it on your project.
   */
  window?: () => Window;
}

const navItems = [
  {
    nome: "Home",
    rota: "/admin"
  },
  {
    nome: "Novo projeto",
    rota: "/admin/projeto/novo"
  }
];

export default function NavBar(props: Props) {
  return (
    <nav className="navbar navbar-expand-lg bg-body-tertiary">
      <div className="container-fluid">
        <a className="navbar-brand" href="/">Portfólio</a>
        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#nav" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="nav">
          <ul className="navbar-nav me-auto mb-2 mb-lg-0">
            <li className="nav-item">
              <a className="nav-link active" aria-current="page" href="/">Início</a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/admin/projeto/novo">Novo projeto</a>
            </li>
            {/* <li className="nav-item dropdown">
              <a className="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                Dropdown
              </a>
              <ul className="dropdown-menu">
                <li><a className="dropdown-item" href="#">Action</a></li>
                <li><a className="dropdown-item" href="#">Another action</a></li>
                <li><a className="dropdown-item" href="#">Something else here</a></li>
              </ul>
            </li> */}
            <li className="nav-item">
              <a className="nav-link" href='/admin/perfil'>Dados do portfólio</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}