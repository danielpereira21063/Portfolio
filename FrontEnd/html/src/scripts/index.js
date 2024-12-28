const buttonTop = document.getElementById('backToTopButton')
const menuMobile = document.querySelector('#menu-hamburguer')

window.sr = ScrollReveal({ reset: true });


window.addEventListener('scroll', () => {
    buttonTop.classList.add('show')
    if (scrollY < 350) {
        buttonTop.classList.remove('show')
    }
    else if (scrollY > 400) {
        menuMobile.checked = false;
    }
})

buttonTop.addEventListener('click', () => {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    })
})


sr.reveal('.texto-home', {
    duration: 1500,
    origin: 'top',
    distance: '150px',
});


sr.reveal('.img-box', {
    duration: 1200,
    origin: 'left',
    distance: '150px',
});

sr.reveal('.imagem-sobre-mim', {
    origin: 'bottom',
    distance: '150px',
    duration: 1200
});

sr.reveal('.informacoes-sobre-mim', {
    origin: 'bottom',
    distance: '150px',
    duration: 1200
});

sr.reveal('.section-title', {
    origin: 'top',
    distance: '150px',
    duration: 1200
});

sr.reveal('.container-habilidades', {
    origin: 'bottom',
    distance: '150px',
    duration: 1200
});

sr.reveal('.container-projetos', {
    origin: 'bottom',
    distance: '100px',
    duration: 1200
});

sr.reveal('.cards-wrapper', {
    origin: 'top',
    distance: '150px',
    duration: 0
});

const irPara = (url) => {
    window.open("https://" + url, '_blank');
}

const texts = {
    pt: {
        home: {
            greeting: "Olá,",
            introName: "Meu nome é",
            name: "Daniel Pereira Sanches",
            profession: "Sou um Desenvolvedor FullStack",
        },
        sobre: {
            title: "Sobre mim",
            textHtml: `
            <p>
                Olá. Meu nome é Daniel, um desenvolvedor Full Stack, com experiência em tecnologias que incluem, mas não se limitam a: 
                <strong>C# .NET</strong>, <strong>JavaScript</strong>, <strong>HTML</strong>, <strong>CSS</strong>, <strong>Vue.js</strong> e 
                <strong>React.js Frameworks</strong>.
            </p>
            <p>
                Comecei a minha carreira como um programador de forma autodidata. Quando iniciei meus estudos, não tinha acesso à internet 
                em casa, mas essa limitação nunca foi um obstáculo para mim. Pelo contrário, ela fortaleceu minha determinação em buscar 
                alternativas e alcançar meus objetivos. Com muito esforço e dedicação, consegui proporcionar acesso à internet em minha 
                casa, o que me permitiu evoluir ainda mais minhas possibilidades de aprendizado. Hoje, continuo firme nos estudos, sempre 
                buscando crescer e superar novos desafios.
            </p>
            <p>
                Além disso, tenho muito interesse em aprofundar meus conhecimentos sobre os processos de desenvolvimento de software. Meu 
                nível de inglês é <strong>B2</strong>, e estou me esforçando para em breve alcançar o nível <strong>C1</strong>. Tenho um 
                profundo conhecimento da <strong>arquitetura DDD</strong>, dos <strong>padrões de código de qualidade</strong>, como injeções 
                de dependências, e do uso de <strong>interfaces</strong> para a criação de aplicações com um modelo de domínio rico.
            </p>
            <p>
                Minhas formações incluem uma graduação em <strong>Análise e Desenvolvimento de Sistemas</strong> e uma 
                <strong>pós-graduação em Engenharia de Software</strong>; portanto, tenho uma formação teórica e prática substancialmente 
                fortalecida na disciplina.
            </p>
            <p>
                Sei lidar bem com pessoas, o que facilita meu trabalho em equipe e me torna eficaz na comunicação com diferentes perfis 
                profissionais, contribuindo para o sucesso dos projetos em que estou envolvido. Sou uma pessoa extremamente paciente, 
                muito esforçada e resiliente que sabe tomar boas decisões.
            </p>
            `,
            cvLink: "Baixe meu CV"
        },
        habilidades: {
            title: "Habilidades"
        },
        projetos: {
            title: "Projetos"
        },
        footer: {
            contact: "Entre em contato comigo!"
        }
    },
    en: {
        home: {
            greeting: "Hello,",
            introName: "My name is",
            name: "Daniel Pereira Sanches",
            profession: "I am a FullStack Developer",
        },
        sobre: {
            title: "About me",
            textHtml: `
                <p>
                    Hello. My name is Daniel, a Full Stack Developer with experience in technologies that include, but are not limited to: 
                    <strong>C# .NET</strong>, <strong>JavaScript</strong>, <strong>HTML</strong>, <strong>CSS</strong>, <strong>Vue.js</strong>, and 
                    <strong>React.js Frameworks</strong>.
                </p>
                <p>
                    I started my career as a self-taught programmer. When I started my studies, I did not have internet access at home, but this limitation 
                    was never an obstacle for me. On the contrary, it strengthened my determination to seek alternatives and achieve my goals. With a lot 
                    of effort and dedication, I managed to provide internet access at home, which helped me to further develop my learning possibilities. 
                    Today, we continue to study hard, always seeking to grow and overcome new challenges.
                </p>
                <p>
                    In addition, I am very interested in deepening my knowledge of software development processes. My English level is <strong>B2</strong>, 
                    and I am working hard to reach level <strong>C1</strong> soon. I have a deep knowledge of <strong>DDD architecture</strong>, 
                    <strong>quality code standards</strong> such as dependency injections, and the use of <strong>interfaces</strong> to create applications 
                    with a rich domain model.
                </p>
                <p>
                    My background includes a degree in <strong>Systems Analysis and Development</strong> and a 
                    <strong>postgraduate degree in Software Engineering</strong>, so I have a theoretical and practical background that is advantageous for the subject.
                </p>
                <p>
                    I am good at dealing with people, which facilitates my teamwork and makes me effective in communicating with different professional profiles, 
                    contributing to the success of the projects I am involved in. I am an extremely patient, hard-working, and resilient person who knows how to 
                    make good decisions. If I am considered the ideal candidate for the position, I will be deeply grateful and honored to be part of your team. 
                    I see this opportunity as a chance not only to apply my skills but also to learn, grow, and collaborate for the success of the company.
                </p>
                `,
            cvLink: "Download my CV"
        },
        habilidades: {
            title: "Skills"
        },
        projetos: {
            title: "Projects"
        },
        footer: {
            contact: "Get in touch with me!"
        }
    }
};

const changeLanguage = (onLoad = false) => {
    const btnDownloadCv = document.querySelector("#btn_download_cv");

    const currentLanguage = localStorage.getItem("lang") || 'pt';
    let lang = null;

    if (onLoad) {
        lang = currentLanguage;
    } else {
        if (currentLanguage == 'pt') {
            lang = 'en';
        } else {
            lang = 'pt';
        }
    }

    btnDownloadCv.setAttribute("href", `./src/arquivos/Daniel-Pereira-Sanches_${lang}_2025.pdf`)

    document.querySelector("#languageToggle").checked = lang == 'en';

    localStorage.setItem("lang", lang);
    document.querySelector("#langText").textContent = lang?.toUpperCase();

    const selectedTexts = texts[lang];

    document.querySelector('.home .texto-home p').textContent = selectedTexts.home.greeting;
    document.querySelector('.home .texto-home span').innerHTML = selectedTexts.home.name;
    document.querySelector('.home .texto-home h1').innerHTML = selectedTexts.home.introName;
    document.querySelector('.home .texto-home h2').textContent = selectedTexts.home.profession;

    const menus = document.querySelectorAll('nav ul li a span');
    menus[0].textContent = selectedTexts.sobre.title;
    menus[1].textContent = selectedTexts.habilidades.title;
    menus[2].textContent = selectedTexts.projetos.title;

    document.querySelector('#sobre-mim .section-title h2').textContent = selectedTexts.sobre.title;
    document.querySelector('#sobre-mim #msgApresentacao').innerHTML = selectedTexts.sobre.textHtml;
    document.querySelector('#sobre-mim .botao-primario a').textContent = selectedTexts.sobre.cvLink;

    document.querySelector('#habilidades .section-title h2').textContent = selectedTexts.habilidades.title;

    document.querySelector('#projects .section-title h2').textContent = selectedTexts.projetos.title;

    document.querySelector('.footer h2').textContent = selectedTexts.footer.contact;
};

window.onload = () => {
    changeLanguage(true);
}
const checkInput = (lang) => {
    document.querySelector("#languageToggle").checked = lang == 'en';
}