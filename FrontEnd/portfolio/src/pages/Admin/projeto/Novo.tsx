import * as React from 'react';
import Projeto from './Index';

export default function NovoProjeto() {
    const [id, setId] = React.useState(0);
    const [titulo, setTitulo] = React.useState("");
    const [descricao, setDescricao] = React.useState("");
    const [url, setUrl] = React.useState("");
    const [urlGithub, setUrlGithub] = React.useState("");
    const [inativo, setInativo] = React.useState(false);

    return (
        <div className='mt-2 mt-lg-3'>
            <h2 className='text-center'>Novo projeto</h2>

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
                            <textarea className="form-control" id="descricao" name="descricao" required></textarea>
                        </div>
                        <div className="mb-3">
                            <label className="form-label">URL</label>
                            <input type="text" className="form-control" id="url" name="url" required />
                        </div>
                        <div className="mb-3">
                            <label className="form-label">URL GitHub</label>
                            <input type="text" className="form-control" id="urlGitHub" name="urlGitHub" required />
                        </div>
                        <div className="mb-3 form-check">
                            <input type="checkbox" className="form-check-input" id="inativo" name="inativo" />
                            <label className="form-check-label" >Inativo</label>
                        </div>
                    </div>
                </div>

                <button type="submit" className="btn btn-primary">Salvar</button>
            </form>

        </div>
    );
}
