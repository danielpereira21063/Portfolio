import React, { useState } from 'react';
import { LockOutlined } from '@mui/icons-material';
import { makeStyles } from "@mui/styles";
import { Button, colors, Grid, Link, TextField, Typography } from '@mui/material';
import Avatar from '@mui/material/Avatar';
import { Box } from '@mui/system';

const useStyles = makeStyles(() => ({
    root: {
        height: '100vh'
    },
    image: {
        background: 'url(/images/login-background.jpg)',
        backgroundPosition: 'center',
        backgroundSize: 'cover',
        padding: '16px !important'
    },
    avatar: {
        background: colors.indigo.A400 + ' !important',
        marginBottom: '8px !important'
    },
    button: {
        marginTop: '8px !important'
    },
    form: {
        margin: '16px 32px !important'
    }
}));

const Login = () => {
    const classes = useStyles();

    const [usuario, setUsuario] = useState("");
    const [senha, setSenha] = useState("");

    const handleLogin = () => {

    }

    return (
        <Grid container className={classes.root}>
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

            <Grid item md={5}>
                <Box display={'flex'} flexDirection={'column'} alignItems={'center'} mt={8}>
                    <Avatar className={classes.avatar}>
                        <LockOutlined></LockOutlined>
                    </Avatar>
                    <Typography>
                        Acesso
                    </Typography>

                    <form className={classes.form}>
                        <TextField
                            variant={'outlined'}
                            margin={'normal'}
                            required
                            fullWidth
                            id={'usuario'}
                            label={'Usuário'}
                            name={'usuário'}
                            value={usuario}
                            onChange={(e) => setUsuario(e.target.value)} />

                        <TextField
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

                        <Button onClick={handleLogin} fullWidth variant="contained" color="primary" className={classes.button}>
                            Entrar
                        </Button>
                        <Grid item marginTop={2}>
                            <Link>Esqueceu sua senha?</Link>
                        </Grid>
                    </form>
                </Box>
            </Grid>
        </Grid>
    )
}

export default Login;