import "./styles/index.css";

import React, { useEffect, useState } from 'react';
import Projeto from '../../models/Projeto';
import { ProjetoService } from '../../services/ProjetoService';
import Navbar from "./components/Navbar";

const Home = () => {
  const [search, setSearch] = useState("");
  const [projetos, setProjetos] = useState<Projeto[]>([]);

  useEffect(() => {
    ProjetoService.obterTodos(1, false, search)
      .then((result) => {
        if (result) {
          setProjetos(result.itens);
        }
      });
  }, []);
  return (
    <>
      <Navbar></Navbar>
    </>
  )
}

export default Home;