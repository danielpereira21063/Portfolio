// const baseUrl = "https://portfolio-api.dev.danielsanchesdev.com.br/api";

// const requestData = async (url) => {
//     url = baseUrl + "/" + url;
//     console.log(url);
//     const result = await (await fetch(url)).json();
//     return result;
// }

// const obterPortfolio = async () => {
//     return await requestData("portfolio");
// }

// const obterProjetos = async () => {
//     return await requestData("projeto/portfolio/1");
// }

// const exibirDadosPortfolio = () => {
//     obterPortfolio().then(resp => {
//         console.log(resp)
//         document.querySelector("#nomeCompleto").innerHTML = `${resp.nomeCompleto}`;
//         document.querySelector("#msgApresentacao").innerHTML = `${resp.mensagemApresentacao}`;
//         document.querySelector("#numeroWhatsapp2").setAttribute("href", `https://wa.me/${resp.whatsApp}`);
//         document.querySelector("#urlInstagram2").setAttribute("href", `https://wa.me/${resp.instagramURL}`);
//         document.querySelector("#urlLinkedin2").setAttribute("href", `https://wa.me/${resp.gitHubUrl}`);
//         document.querySelector("#urlGithub2").setAttribute("href", `https://wa.me/${resp.linkedinURL}`);

//         // console.log(resp);
//     });
// }
// criarCardProjeto = (projeto) => {
//     const html = `<div class="card-grid-space">
//     <a class="card" href="${projeto.urlGitHub}"
//       style="--bg-img: url('../imagens/projeto-8.jpg')" target="_blank">
//       <div>
//         <h1>${projeto.titulo}</h1>
//         <p>${projeto.descricao}</p>
//         <div class="date">${projeto.dataCadastro}</div>
//         <div class="tags">
//           <div class="tag">Vizualizar Projeto</div>
//         </div>
//       </div>
//     </a>
//   </div>`;

//   return html;
// }

// const exibirProjetos = () => {
//     obterProjetos().then(resp => {
//         let htmlProjetos = "";
//         resp.itens.forEach(p => {
//             htmlProjetos += criarCardProjeto(p);
//         })

//         document.querySelector("#projetos").innerHTML = htmlProjetos;
//     });
// }

// exibirDadosPortfolio();
// exibirProjetos();
