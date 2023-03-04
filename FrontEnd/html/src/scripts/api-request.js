const baseUrl = "https://portfolio-api.dev.danielsanchesdev.com.br/api";

const requestData = async (url) => {
    const result = await (await fetch(`${baseUrl}/${url}`)).json();
    return result;
}

const obterPortfolio = async () => {
    return await requestData("portfolio");
}

const exibirDadosPortfolio = () => {
    obterPortfolio().then(resp => {
        document.querySelector("#nomeCompleto").innerHTML = `${resp.nomeCompleto}`;
        document.querySelector("#numeroWhatsapp2").setAttribute("href", `https://wa.me/${resp.whatsApp}`);
        document.querySelector("#urlInstagram2").setAttribute("href", `https://wa.me/${resp.instagramURL}`);
        document.querySelector("#urlLinkedin2").setAttribute("href", `https://wa.me/${resp.gitHubUrl}`);
        document.querySelector("#urlGithub2").setAttribute("href", `https://wa.me/${resp.linkedinURL}`);

        console.log(resp);
    });
}

exibirDadosPortfolio();