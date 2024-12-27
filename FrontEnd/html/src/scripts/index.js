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
    Olá, meu nome é Daniel, e atualmente atuo como desenvolvedor full-stack, trazendo meu conhecimento em
    linguagens como <strong>C# (.NET)</strong>, além de <strong>JavaScript</strong>. Minhas habilidades
    incluem também <strong>HTML</strong> e <strong>CSS</strong>, com experiência em frameworks renomados como
    <strong>Vue.js</strong> e <strong>React.js</strong>.
  </p>

  <p>
     Além do meu papel como desenvolvedor, tenho um interesse particular em ethical hacking, buscando
  ampliar meus conhecimentos em segurança da informação. Concluí minha graduação em
  <strong>Análise e Desenvolvimento de Sistemas na Universidade Estácio de Sá</strong> em dezembro de 2023
  e iniciei minha <strong>Pós-Graduação em Engenharia de Software na Unyleya</strong> em janeiro de 2024 e concluí em setembro de 2024,
  aprofundando ainda mais meu conhecimento e aprimorando minhas habilidades na área.
  </p>

  <p>Possuo um sólido conhecimento em inglês (B2 Independente) e consigo me comunicar no idioma sem grandes problemas. <a
      style="text-decoration: underline;" target="_blank" href="https://cert.efset.org/hthhpg">Clicando
      aqui</a> você pode consultar meu certificado do teste feito no <a style="text-decoration: underline;"
      target="_blank" href="https://www.efset.org">EFSET</a>.</p>

  <p>
    Estou aberto a oportunidades e colaborações na área de tecnologia.

    Agradeço pela atenção dedicada!!!
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
            textHtml: `<p>
    Hello, I am Daniel, and I currently work as a full-stack developer, bringing my knowledge of
    languages like <strong>C# (.NET)</strong>, as well as <strong>JavaScript</strong>. My skills also include
    <strong>HTML</strong> and <strong>CSS</strong>, with experience in well-known frameworks such as
    <strong>Vue.js</strong> and <strong>React.js</strong>.
  </p>

  <p>
    In addition to my role as a developer, I have a particular interest in ethical hacking, constantly seeking
    to expand my knowledge in information security. I completed my undergraduate degree in
    <strong>Systems Analysis and Development at Universidade Estácio de Sá</strong> in December 2023
    and started my <strong>Postgraduate in Software Engineering at Unyleya</strong> in January 2024 and finished in September 2024,
    further deepening my knowledge and improving my skills in the field.
  </p>

  <p>I have a solid knowledge of English (B2 Upper intermediate) and can communicate in the language without major issues. <a
      style="text-decoration: underline;" target="_blank" href="https://cert.efset.org/hthhpg">Clicking here</a>
      you can check my certificate from the test taken at <a style="text-decoration: underline;" target="_blank"
      href="https://www.efset.org">EFSET</a>.</p>

  <p>
    I am open to opportunities and collaborations in the technology field.

    Thank you for your attention!!!
  </p>`,
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