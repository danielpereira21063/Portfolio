import React, { useState } from 'react';
import { AccountService } from '../../../services/AccountService';
import "./style.css";
import UserLogin from './../../../models/UserLogin';

const Copyright = () => {
    return (
        <div className='text-center'>
            <a target='_blank' href="https://github.com/danielpereira21063">&copy; Daniel Pereira Sanches</a>
        </div>
    );
}

const Login = () => {
    const autenticado = AccountService.obterUsuarioLocalStorage();

    if (autenticado) location.href = "/";

    const [usuario, setUsuario] = useState("");
    const [senha, setSenha] = useState("");
    const [error, setError] = useState("");

    const autenticar = (e: any) => {
        e.preventDefault();

        setError("");

        const login = {
            usuario: usuario,
            senha: senha
        } as UserLogin;

        AccountService.login(login).then((response) => {
            if (typeof response == 'string') {
                setError(response);
            } else {
                location.href = "/";
            }
        });
    }

    return (
        <div className='vh-100 d-flex justify-content-center align-items-center login text-light' data-bs-theme="dark">
            <div className='col-12 col-sm-8 col-md-6 col-lg-4 bg-dark rounded-3'>
                <div className='p-3 px-md-5 py-lg-3 mx-2 mx-md-0'>
                    <div className='d-flex align-items-center'>
                        <img className='rounded-circle mx-auto' width={'50px'} src='https://avatars.githubusercontent.com/u/67229104?s=400&u=908e61a470f452d94f1620d8b5378dc80f962457&v=4'></img>
                    </div>
                    <div className='text-center my-1'>
                        <h5>Bem vindo, Daniel.</h5>
                        <small>Faça login para administar seu portfólio.</small>
                    </div>

                    {error.length > 0 && <div className='alert alert-danger mt-2 text-center'>{error}</div>}

                    <form className='mt-3'>
                        <div className="form-outline mb-4">
                            <label className="form-label">Usuário</label>
                            <input onChange={(e) => setUsuario(e.target.value)} required type="text" placeholder='Usuário' className="form-control" />
                        </div>

                        <div className="form-outline mb-4">
                            <label className="form-label">Senha</label>
                            <input onChange={(e) => setSenha(e.target.value)} required type="password" placeholder='********' className="form-control" />
                        </div>

                        <button type="submit" className="btn btn-primary btn-block mb-4 w-100" onClick={autenticar}>Entrar</button>

                        {Copyright()}
                    </form>
                </div>
            </div>

        </div>
    );
}

export default Login;