import { Button, Container } from '@mui/material';
import React, { useEffect, useState } from 'react';
import PageList from '../../models/PageList';
import Projeto from '../../models/Projeto';
import { ProjetoService } from '../../services/ProjetoService';

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
    <Container maxWidth={'lg'}>
      <h1>Lista de projetos || Página do portfólio aqui</h1>
      {projetos.map(projeto => (
        <div key={projeto.id} style={{ background: '#ccc' }}>
          <h2>{projeto.titulo}</h2>
          <p>{projeto.descricao}</p>
        </div>
      ))}
    </Container>
  )
}

export default Home;