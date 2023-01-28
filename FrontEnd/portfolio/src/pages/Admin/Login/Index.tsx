import React, { useState } from 'react';
import { AuthContext } from '../../../context/AuthContext';
import { LockOutlined } from '@mui/icons-material';
import { makeStyles } from "@mui/styles";
import { Alert, Button, colors, Grid, Hidden, Link, TextField, Typography } from '@mui/material';
import Avatar from '@mui/material/Avatar';
import { Box } from '@mui/system';
import { useContext } from 'react';
import UserLogin from '../../../models/UserLogin';
import { LoadingButton } from '@mui/lab';
import { useNavigate } from "react-router-dom";

const useStyles = makeStyles(() => ({
    root: {
        height: '100vh'
    },
    image: {
        background: 'url(/images/login-page-bg.jpg)',
        backgroundPosition: 'center',
        backgroundSize: 'cover',
        padding: '16px !important'
    },
    avatar: {
        background: colors.blue.A400 + ' !important',
        marginBottom: '8px !important'
    },
    button: {
        marginTop: '8px !important'
    },
    form: {
        margin: '16px !important'
    }
}));

const Copyright = () => {
    return (
        <Typography variant="body2" align="center">
            {'Copyright © '}
            <a
                color="inherit"
                href="https://danielsanchesdev.com.br"
                target={'_blank'}
            >
                Daniel Sanches
            </a>{' '}
            {new Date().getFullYear()}
        </Typography>
    );
}

const Login = () => {
    const classes = useStyles();
    const navigate = useNavigate();

    const [usuario, setUsuario] = useState("");
    const [senha, setSenha] = useState("");

    const [usuarioError, setUsuarioError] = useState("");
    const [senhaError, setSenhaError] = useState("");

    const { authenticated, loading, login, loginError } = useContext(AuthContext);

    if (authenticated) navigate("/admin");

    async function handleLogin(e: any) {
        e.preventDefault();

        setUsuarioError("");
        setSenhaError("");

        if (usuario.length == 0) {
            setUsuarioError("Informe um nome de usuário válido");
        }

        if (senha.length == 0) {
            setSenhaError("Informe uma senha válida");
        }

        const temErro = usuario.length == 0 || senha.length == 0;
        if (temErro) return;

        const data: UserLogin = {
            usuario: usuario,
            senha: senha
        }

        const user = await login(data);

        if (user) navigate("/admin");
    }

    return (
        <Grid container className={classes.root}>
            <Hidden mdDown>
                <Grid
                    item
                    container
                    direction={'column'}
                    justifyContent={'center'}
                    alignContent={'center'}
                    md={7}
                    className={classes.image}>

                    <Typography style={{ color: '#fff', fontSize: 35, lineHeight: '45px', textAlign: 'center' }}>
                        <strong>Bem vindo, Daniel!</strong>
                    </Typography>
                    <Typography variant="body2" style={{ color: 'rgb(255,255,255,0.7)', textAlign: 'center', marginTop: 30, fontSize: 15, lineHeight: '30px' }}>
                        Faça login para gerenciar seu portfólio.
                    </Typography>
                </Grid>
            </Hidden>

            <Grid item md={5} sm={12}>
                <Box display={'flex'} flexDirection={'column'} alignItems={'center'} mt={8}>
                    <Avatar className={classes.avatar}>
                        <LockOutlined></LockOutlined>
                    </Avatar>
                    <Typography>
                        Acesso
                    </Typography>

                    {loginError && (
                        <Alert severity="error">
                            {loginError}
                        </Alert>
                    )}

                    <form className={classes.form}>
                        <TextField
                            error={usuarioError.length > 0}
                            helperText={usuarioError}
                            variant={'outlined'}
                            margin={'normal'}
                            required={true}
                            fullWidth
                            id={'usuario'}
                            label={'Usuário'}
                            name={'usuário'}
                            value={usuario}
                            onChange={(e) => setUsuario(e.target.value)} />

                        <TextField
                            error={senhaError.length > 0}
                            helperText={senhaError}
                            variant="outlined"
                            margin="normal"
                            required
                            fullWidth
                            id="password"
                            label="Senha"
                            name="senha"
                            autoComplete="current-password"
                            value={senha}
                            onChange={(e) => setSenha(e.target.value)} />


                        {!loading && (
                            <LoadingButton onClick={handleLogin} loading={loading} fullWidth color="primary" variant="contained" className={classes.button}>
                                Entrar
                            </LoadingButton>
                        )}


                        <Grid item marginTop={2}>
                            <Link href='/admin/reset-password'>Esqueceu sua senha?</Link>
                        </Grid>
                    </form>

                    <Copyright />
                </Box>
            </Grid>
        </Grid>
    )
}

export default Login;