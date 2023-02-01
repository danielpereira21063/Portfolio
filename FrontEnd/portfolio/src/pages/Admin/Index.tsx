import React, { useEffect, useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { Alert, Badge, Button, Chip, Container, Menu, MenuItem, Pagination, Skeleton, Stack, TextField, Toolbar, Tooltip, Typography } from '@mui/material';
import { Box } from '@mui/system';
import { ProjetoService } from '../../services/ProjetoService';
import Projeto from '../../models/Projeto';
import { Link, MemoryRouter } from 'react-router-dom';
import PageList from '../../models/PageList';

export default function Admin() {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);
  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

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
    handleClose();
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
    <Container maxWidth={'lg'}>
      <Box marginY={'18px'}>
        <TableContainer component={Paper}>
          <Toolbar>
            <Typography
              sx={{ flex: '1 1 100%' }}
              variant="h6"
              id="tableTitle"
              component="div"
            >
              Projetos

            </Typography>

          </Toolbar>

          <Box maxWidth={'98%'} marginX={'auto'}>
            <TextField onChange={(e) => setSearch(e.target.value)} size='small' placeholder='Buscar por título ou descrição' fullWidth label="Pesquisa" id="fullWidth" />
          </Box>

          <Box maxWidth={'98%'} marginX={'auto'} display={requesting ? 'block' : 'none'}>
            <Skeleton height={'50px'} />
            <Skeleton height={'50px'} animation="wave" />
            <Skeleton height={'50px'} animation={false} />
            <Skeleton height={'50px'} />
            <Skeleton height={'50px'} animation="wave" />
            <Skeleton height={'50px'} animation={false} />
            <Skeleton height={'50px'} />
            <Skeleton height={'50px'} animation="wave" />
          </Box>
          <Table sx={{ minWidth: 650 }} aria-label="simple table" style={{ display: requesting || projetos.length == 0 ? 'none' : 'initial' }}>
            <TableHead>
              <TableRow>
                <TableCell><strong>Título</strong></TableCell>
                <TableCell><strong>Descrição</strong></TableCell>
                <TableCell><strong>URL GitHub</strong></TableCell>
                <TableCell><strong>URL</strong></TableCell>
                <TableCell><strong>Status</strong></TableCell>
                <TableCell><strong>Ações</strong></TableCell>
              </TableRow>
            </TableHead>

            <TableBody>
              {projetos.map((projeto) => (
                <TableRow
                  key={projeto.id}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell> {projeto.titulo}  </TableCell>
                  <TableCell>{projeto.descricao}</TableCell>
                  <TableCell><Link target={'_blank'} to={projeto.urlGitHub}>{projeto.urlGitHub}</Link></TableCell>
                  <TableCell><Link target={'_blank'} to={projeto.url}>{projeto.url}</Link></TableCell>
                  <TableCell style={{ 'textAlign': 'center' }} onClick={() => handleAlterarStatus(projeto)}>
                    <Stack direction="row" spacing={2}>
                      {/* <Circle ></Circle> */}
                      <Chip label={projeto.inativo ? 'Inativo' : 'Ativo'} color={projeto.inativo ? 'error' : 'success'} />
                    </Stack>
                  </TableCell>
                  <TableCell>
                    <Link to={`/admin/projeto/${projeto.id}`} color='info'>
                      Detalhes
                    </Link>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>

          <Box display={'flex'} justifyContent={'space-between'} marginY={'20px'} marginX={'15px'}>
            <Typography fontWeight={'bold'} variant='caption'>Exibindo {projetos.length} de um total de {qtdResultados} resultados</Typography>
            <Pagination color="primary" count={totalPaginas} page={numeroPagina} onChange={handleAlterarPagina} />
          </Box>
        </TableContainer>
      </Box>
    </Container>
  );
}