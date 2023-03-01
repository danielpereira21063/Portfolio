import React from 'react'

const Navbar = () => {
  return (
    <header className="header">
    <div className="container">
      <div className="row justify-content-between alinhar-itens-no-centro">
        <a href="#">
          <h1 className="logo">LZ</h1>
        </a>

        <nav>
          <input id="menu-hamburguer" type="checkbox"/>

          <label htmlFor="menu-hamburguer">
            <div className="menu">
              <span className="hamburguer"></span>
            </div>
          </label>

          <ul>
            <li><a href="#sobre-mim">Sobre mim</a></li>
            <li><a href="#habilidades">Habilidades</a></li>
            <li><a href="#projects">Meus projetos</a></li>
          </ul>
        </nav>

      </div>
    </div>
  </header>
  )
}

export default Navbar

