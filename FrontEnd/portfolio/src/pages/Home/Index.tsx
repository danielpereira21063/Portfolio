import React, { useEffect, useState } from 'react';
import Projeto from '../../models/Projeto';
import { ApiException } from '../../services/api/ApiException';
import { ProjetoService } from '../../services/ProjetoService';

const Home = () => {
  const [search, setSearch] = useState("");
  const [projetos, setProjetos] = useState<Projeto[]>([]);

  useEffect(() => {
    ProjetoService.obterTodos(1, search)
      .then((result) => {
        if (result instanceof ApiException) {
          alert(result.message);
        } else {
          setProjetos(result);
        }
      });
  }, []);
  return (
    <div>
      <h1>Lista de projetos || Página do portfólio aqui</h1>
      {projetos.map(projeto => (
        <div style={{background: '#ccc'}}>
          <h2>{projeto.titulo}</h2>
          <p>{projeto.descricao}</p>
        </div>
      ))}
    </div>
  )
}

export default Home;