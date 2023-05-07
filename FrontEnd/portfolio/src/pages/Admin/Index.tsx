import React, { useEffect, useState } from 'react';
import { ProjetoService } from '../../services/ProjetoService';
import Projeto from '../../models/Projeto';

export default function Admin() {
  const [search, setSearch] = useState("");
  const [projetos, setProjetos] = useState<Projeto[]>([]);
  const [totalPaginas, setTotalPaginas] = useState(0);
  const [numeroPagina, setNumeroPagina] = useState(1);
  const [qtdResultados, setQtdResultados] = useState(0);
  const [requesting, setRequesting] = useState(false);

  const buscarProjetos = (pagina = 1, obterInativos = true) => {
    setRequesting(true);
    ProjetoService.obterTodos(1, obterInativos, search, pagina)
      .then((result) => {
        if (result) {
          setProjetos(result.itens);
          setTotalPaginas(result.totalPaginas);
          setQtdResultados(result.qtdTotal);
        }
        setRequesting(false);
      });
  }

  useEffect(() => {
    setNumeroPagina(1);
    buscarProjetos();
  }, [search]);

  const handleAlterarStatus = (projeto: Projeto) => {
    ProjetoService.alterarStatus(projeto.id).then((result) => {
      if (!result) {
        return;
      }

      buscarProjetos();
    });
  }

  const handleAlterarPagina = (event: React.ChangeEvent<unknown>, value: number) => {
    if (requesting) return;

    setNumeroPagina(value);
    buscarProjetos(value);
  }

  return (
    <div className='mt-2 mt-lg-3'>
      <h2 className='text-center'>Projetos</h2>
      <table className="table">
        <thead>
          <tr>
            <th scope="col">Título</th>
            <th scope="col">Descrição</th>
            <th scope="col">URL</th>
            <th scope="col">Github URL</th>
            <th scope="col">Status</th>
            <th scope="col">Data</th>
          </tr>
        </thead>
        <tbody>
          {
            projetos.map(p => (
              <>
                <td>{p.titulo}</td>
                <td>{p.descricao}</td>
                <td>{p.url}</td>
                <td>{p.inativo ? 'Inativo' : 'Ativo'}</td>
                <td>{p.dataCadastro.toDateString()}</td>
              </>
            ))
          }
        </tbody>
      </table>
    </div>
  );
}