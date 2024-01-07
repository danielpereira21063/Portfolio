import * as React from 'react';
import { ProjetoService } from '../../../services/ProjetoService';
import Projeto from '../../../models/Projeto';
import { useParams } from 'react-router-dom';

export default function NovoProjeto() {
    const [id, setId] = React.useState(0);
    const [titulo, setTitulo] = React.useState("");
    const [descricao, setDescricao] = React.useState("");
    const [url, setUrl] = React.useState("");
    const [urlGithub, setUrlGithub] = React.useState("");
    const [inativo, setInativo] = React.useState(false);

    const [erros, setErros] = React.useState({} as any);

    const parametros = useParams();

    const projetoId = parseInt(parametros.id as string);

    var projeto = {

    } as Projeto

    if (projetoId > 0) {
        ProjetoService.obterPeloId(projetoId).then(data =>{
            projeto = data as Projeto;
            setTitulo(projeto.titulo);
            setDescricao(projeto.descricao);
            setInativo(projeto.inativo);
            setUrl(projeto.url);
            setUrlGithub(projeto.urlGitHub);
        });
    } else {
        projeto = {
            id: 0,
            descricao: descricao,
            inativo: inativo,
            titulo: titulo,
            url: url,
            urlGitHub: urlGithub,
        } as Projeto
    }

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

                if (data['status'] == 400) {
                    console.log(data)
                    setErros(data.errors);
                    return;
                }

                location.href = "/";
            });
        } catch (error: any) {
            console.log(error)
            setErros(error.errors);
        }
    }

    return (
        <div className='mt-2 mt-lg-3'>
            <h2 className='text-center'>Novo projeto</h2>

            {erros.Titulo && <div className='alert alert-danger'>{erros.Titulo[0]}</div>}
            {erros.Descricao && <div className='alert alert-danger'>{erros.Descricao[0]}</div>}
            {erros.Url && <div className='alert alert-danger'>{erros.Url[0]}</div>}
            {erros.UrlGitHub && <div className='alert alert-danger'>{erros.UrlGitHub[0]}</div>}

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
