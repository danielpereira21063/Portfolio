import * as React from 'react';
import { ProjetoService } from '../../../services/ProjetoService';
import Projeto from '../../../models/Projeto';
import { error } from 'console';

export default function NovoProjeto() {
    const [id, setId] = React.useState(0);
    const [titulo, setTitulo] = React.useState("");
    const [descricao, setDescricao] = React.useState("");
    const [url, setUrl] = React.useState("");
    const [urlGithub, setUrlGithub] = React.useState("");
    const [inativo, setInativo] = React.useState(false);

    const [erros, setErros] = React.useState(Array);

    var projeto = {
        id: 0,
        descricao: descricao,
        inativo: inativo,
        titulo: titulo,
        url: url,
        urlGitHub: urlGithub,
    } as Projeto

    const salvar = (e: any) => {
        e.preventDefault();

        try {
            ProjetoService.salvar(projeto).then(data => {
                location.href = "/";
            });
        } catch (error: any) {
            setErros(error.errors);
        }
    }

    return (
        <div className='mt-2 mt-lg-3'>
            <h2 className='text-center'>Novo projeto</h2>

            {(erros.map(e => <div className='alert alert-danger'>{e as string}</div>))}

            <form>
                <div className="row">
                    <div className="col-12">
                        <input type='hidden' ></input>
                        <div className="mb-3">
                            <label className="form-label">Título</label>
                            <input onChange={(e) => setTitulo(e.target.value)} type="text" className="form-control" id="titulo" name="titulo" required />
                        </div>
                        <div className="mb-3">
                            <label className="form-label">Descrição</label>
                            <textarea onChange={(e) => setDescricao(e.target.value)} className="form-control" id="descricao" name="descricao" required></textarea>
                        </div>
                        <div className="mb-3">
                            <label className="form-label">URL</label>
                            <input onChange={(e) => setUrl(e.target.value)} type="text" className="form-control" id="url" name="url" required />
                        </div>
                        <div className="mb-3">
                            <label className="form-label">URL GitHub</label>
                            <input onChange={(e) => setUrlGithub(e.target.value)} type="text" className="form-control" id="urlGitHub" name="urlGitHub" required />
                        </div>
                        <div className="mb-3 form-check">
                            <input onChange={(e) => setInativo(e.target.checked)} type="checkbox" className="form-check-input" id="inativo" name="inativo" />
                            <label className="form-check-label" >Inativo</label>
                        </div>
                    </div>
                </div>

                <button type="submit" className="btn btn-primary w-100" onClick={salvar}>Salvar</button>
            </form>

        </div>
    );
}
