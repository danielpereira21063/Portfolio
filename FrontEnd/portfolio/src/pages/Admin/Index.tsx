import React, { useEffect, useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { Alert, Badge, Button, Chip, Container, Menu, MenuItem, Stack, Toolbar, Tooltip, Typography } from '@mui/material';
import { Box } from '@mui/system';
import { ProjetoService } from '../../services/ProjetoService';
import Projeto from '../../models/Projeto';
import { Link } from 'react-router-dom';

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


  useEffect(() => {
    ProjetoService.obterTodos(1, true, search)
      .then((result) => {
        if (result) {
          setProjetos(result);
        }
      });

  }, []);

  const handleAlterarStatus = (projeto: Projeto) => {
    handleClose();

    console.log(projeto.id)
    ProjetoService.alterarStatus(projeto.id).then((result) => {
      if (!result) {
        return;
      }

      ProjetoService.obterTodos(1, true, search)
        .then((result) => {
          if (result) {
            setProjetos(result);
          }
        });
    });
  }

  return (
    <Container maxWidth={'lg'}>
      <Box>
        <br />
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
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
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
        </TableContainer>
      </Box>
    </Container>
  );
}