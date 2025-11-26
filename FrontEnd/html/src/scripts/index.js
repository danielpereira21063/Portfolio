window.sr = ScrollReveal({ reset: true });

const buttonTop = document.querySelector('.button-top'); // Certifique-se de que essa classe existe
const menuMobile = document.querySelector('.menu-mobile'); // Certifique-se de que essa classe existe

if (buttonTop && menuMobile) {
    window.addEventListener('scroll', () => {
        if (window.scrollY > 350) {
            buttonTop.classList.add('show');
        } else {
            buttonTop.classList.remove('show');
        }

        if (window.scrollY > 400) {
            menuMobile.checked = false;
        }
    });

    buttonTop.addEventListener('click', () => {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    });
}

// Configuração das animações com ScrollReveal
sr.reveal('.texto-home', {
    duration: 1500,
    origin: 'top',
    distance: '60px',
});

sr.reveal('.img-box', {
    duration: 1200,
    origin: 'left',
    distance: '60px',
});

sr.reveal('.imagem-sobre-mim', {
    origin: 'bottom',
    distance: '60px',
    duration: 1200
});

sr.reveal('.informacoes-sobre-mim', {
    origin: 'bottom',
    distance: '60px',
    duration: 1200
});

sr.reveal('.section-title', {
    origin: 'top',
    distance: '60px',
    duration: 1200
});

sr.reveal('.container-habilidades', {
    origin: 'bottom',
    distance: '60px',
    duration: 1200
});

sr.reveal('.container-projetos', {
    origin: 'bottom',
    distance: '60px',
    duration: 1200
});

sr.reveal('.cards-wrapper', {
    origin: 'top',
    distance: '60px',
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
                Olá, meu nome é Daniel, desenvolvedor Full Stack com experiência em <strong>C# .NET</strong>, <strong>JavaScript</strong>, 
                <strong>HTML</strong>, <strong>CSS</strong> e <strong>React.js</strong>. Sou formado em 
                <strong>Análise e Desenvolvimento de Sistemas</strong> pela Estácio e concluí minha <strong>Pós-Graduação em Engenharia de Software</strong> pela Unyleya.
            </p>
            <p>
                Iniciei minha carreira como programador autodidata em 2020, estudando HTML, CSS, JavaScript e PHP. Após um ano de estudos 
                dedicados, conquistei minha primeira oportunidade como desenvolvedor FullStack júnior em 2021.
            </p>
            <p>
                Atualmente, faço parte da <strong>TETRIS IT</strong>, atuando na <strong>MAG Seguros</strong>, onde trabalho em projetos 
                orientados a eventos utilizando <strong>C#</strong>, <strong>Microservices</strong>, testes unitários e de integração, e 
                recursos do <strong>Azure Cloud</strong> como Functions e Service Bus. Anteriormente, trabalhei por quase 4 anos na RCA Sistemas, 
                desenvolvendo aplicações Web e Desktop (Windows Forms + DevExpress).
            </p>
            <p>
                Sou leitor assíduo do livro "<strong>Clean Code</strong>" e busco aplicar rigorosamente seus princípios em meus projetos, 
                seguindo boas práticas de <strong>DDD (Domain Driven Design)</strong>, injeção de dependências e padrões de qualidade.
            </p>
            <p>
                Meu nível de inglês é <strong>B2 (Professional Working)</strong> (<a style="text-decoration: underline" target='_blank' href='https://cert.efset.org/hthhpg'>veja meu certificado EF SET</a>). 
                Tenho conversado frequentemente com falantes nativos e recebo elogios pela fluência nas conversações.
            </p>
            <p>
                Estou aberto a oportunidades e colaborações na área de tecnologia. Vamos nos conectar!
            </p>
            `,
            cvLink: "Baixe meu CV",
            timeline: {
                date1: "Fevereiro 2025 - Presente",
                desc1: "Back-End .NET Developer - Projetos event-driven com C#, Azure Functions, Service Bus e Microservices",
                date2: "Julho 2021 - Fevereiro 2025",
                desc2: "Fullstack Developer - C# .NET, Vue.js, Bootstrap, Windows Forms, DevExpress"
            }
        },
        habilidades: {
            title: "Habilidades"
        },
        projetos: {
            title: "Projetos",
            subtitle: "Alguns dos meus trabalhos mais recentes",
            viewProject: "Ver Projeto",
            code: "Código",
            project1: "Uma rede social completa criada com ASP.NET Core MVC Web App. Permite interação entre usuários com posts, comentários e sistema de amizades.",
            project2: "Plataforma de blog moderna desenvolvida com React.js e MongoDB. Sistema completo de autenticação, criação e gerenciamento de posts.",
            project3: "Sistema completo de gerenciamento de eventos desenvolvido com C# .NET Core e Angular. Cadastro de eventos, palestrantes e controle de participantes.",
            project4: "Jogo de adivinhação de palavras estilo caça-palavras desenvolvido em React. Interface interativa e dinâmica com sistema de pontuação."
        },
        footer: {
            contact: "Entre em contato comigo!"
        },
        stats: {
            label1: "Anos de Experiência",
            label2: "Tecnologias",
            label3: "Projetos+"
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
                    Hello, my name is Daniel, a Full Stack developer with experience in <strong>C# .NET</strong>, <strong>JavaScript</strong>, 
                    <strong>HTML</strong>, <strong>CSS</strong>, and <strong>React.js</strong>. I hold a degree in 
                    <strong>Systems Analysis and Development</strong> from Estácio and completed my <strong>Postgraduate degree in Software Engineering</strong> from Unyleya.
                </p>
                <p>
                    I started my career as a self-taught programmer in 2020, studying HTML, CSS, JavaScript, and PHP. After one year of dedicated study, 
                    I landed my first opportunity as a junior FullStack developer in 2021.
                </p>
                <p>
                    Currently, I'm part of <strong>TETRIS IT</strong> and based at <strong>MAG Seguros</strong>, where I work on event-driven projects 
                    using <strong>C#</strong>, <strong>Microservices</strong>, unit and integration testing, and <strong>Azure Cloud</strong> resources 
                    such as Functions and Service Bus. Previously, I worked for nearly 4 years at RCA Sistemas, developing Web and Desktop applications (Windows Forms + DevExpress).
                </p>
                <p>
                    I'm an avid reader of the book "<strong>Clean Code</strong>" and strive to rigorously apply its principles in my projects, following 
                    best practices of <strong>DDD (Domain Driven Design)</strong>, dependency injection, and quality standards.
                </p>
                <p>
                    My English level is <strong>B2 (Professional Working)</strong> (<a style="text-decoration: underline" target='_blank' href='https://cert.efset.org/hthhpg'>see my EF SET certificate</a>). 
                    I've had conversations with several speakers of the language, including native speakers, and have been praised for being able to hold long conversations.
                </p>
                <p>
                    I'm open to opportunities and collaborations in the field of technology. Let's connect!
                </p>
                `,
            cvLink: "Download my CV",
            timeline: {
                date1: "February 2025 - Present",
                desc1: "Back-End .NET Developer - Event-driven projects with C#, Azure Functions, Service Bus and Microservices",
                date2: "July 2021 - February 2025",
                desc2: "Fullstack Developer - C# .NET, Vue.js, Bootstrap, Windows Forms, DevExpress"
            }
        },
        habilidades: {
            title: "Skills"
        },
        projetos: {
            title: "Projects",
            subtitle: "Some of my most recent works",
            viewProject: "View Project",
            code: "Code",
            project1: "A complete social network created with ASP.NET Core MVC Web App. Allows user interaction with posts, comments and friendship system.",
            project2: "Modern blog platform developed with React.js and MongoDB. Complete authentication system, post creation and management.",
            project3: "Complete event management system developed with C# .NET Core and Angular. Event registration, speakers and participant control.",
            project4: "Word guessing game in crossword puzzle style developed in React. Interactive and dynamic interface with scoring system."
        },
        footer: {
            contact: "Get in touch with me!"
        },
        stats: {
            label1: "Years of Experience",
            label2: "Technologies",
            label3: "Projects+"
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
    document.querySelector('#download-cv-text').textContent = selectedTexts.sobre.cvLink;

    // Atualizar timeline
    if (selectedTexts.sobre.timeline) {
        document.querySelector('#timeline-date-1').textContent = selectedTexts.sobre.timeline.date1;
        document.querySelector('#timeline-desc-1').textContent = selectedTexts.sobre.timeline.desc1;
        document.querySelector('#timeline-date-2').textContent = selectedTexts.sobre.timeline.date2;
        document.querySelector('#timeline-desc-2').textContent = selectedTexts.sobre.timeline.desc2;
    }

    // Atualizar stats cards
    if (selectedTexts.stats) {
        document.querySelector('#stat-label-1').textContent = selectedTexts.stats.label1;
        document.querySelector('#stat-label-2').textContent = selectedTexts.stats.label2;
        document.querySelector('#stat-label-3').textContent = selectedTexts.stats.label3;
    }

    document.querySelector('#habilidades .section-title h2').textContent = selectedTexts.habilidades.title;

    document.querySelector('#projects .section-title h2').textContent = selectedTexts.projetos.title;
    
    // Atualizar subtitle de projetos
    if (selectedTexts.projetos.subtitle) {
        document.querySelector('#projects-subtitle').textContent = selectedTexts.projetos.subtitle;
    }

    // Atualizar descrições dos projetos
    if (selectedTexts.projetos.project1) {
        document.querySelector('#project-desc-1').textContent = selectedTexts.projetos.project1;
        document.querySelector('#project-desc-2').textContent = selectedTexts.projetos.project2;
        document.querySelector('#project-desc-3').textContent = selectedTexts.projetos.project3;
        document.querySelector('#project-desc-4').textContent = selectedTexts.projetos.project4;
    }

    // Atualizar botões dos projetos
    if (selectedTexts.projetos.viewProject) {
        document.querySelector('#btn-view-1').textContent = selectedTexts.projetos.viewProject;
        document.querySelector('#btn-view-2').textContent = selectedTexts.projetos.viewProject;
        document.querySelector('#btn-view-3').textContent = selectedTexts.projetos.viewProject;
        document.querySelector('#btn-view-4').textContent = selectedTexts.projetos.viewProject;
        
        document.querySelector('#btn-code-1').textContent = selectedTexts.projetos.code;
        document.querySelector('#btn-code-2').textContent = selectedTexts.projetos.code;
        document.querySelector('#btn-code-3').textContent = selectedTexts.projetos.code;
        document.querySelector('#btn-code-4').textContent = selectedTexts.projetos.code;
    }

    document.querySelector('#contact-title').textContent = selectedTexts.footer.contact;
};

const track = () =>{
    const host = "https://track.danielsanchesdev.com.br";
    
    fetch(host + '/track', {
    method: 'POST',
    keepalive: true,
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      referer: document.referrer
    })
  }).catch(console.error);
}

window.onload = () => {
    // Esconder loading screen
    setTimeout(() => {
        const loadingScreen = document.getElementById('loading-screen');
        if (loadingScreen) {
            loadingScreen.classList.add('hidden');
        }
    }, 1500);
    
    changeLanguage(true);
    track();
    initTypingEffect();
    initCounters();
    initHeaderScroll();
    
    // Inicializar AOS (Animate On Scroll)
    if (typeof AOS !== 'undefined') {
        AOS.init({
            duration: 800,
            easing: 'ease-out-cubic',
            once: true,
            offset: 100
        });
    }
}

// Efeito no header ao rolar
function initHeaderScroll() {
    const header = document.querySelector('.header');
    
    window.addEventListener('scroll', () => {
        if (window.scrollY > 100) {
            header.classList.add('scrolled');
        } else {
            header.classList.remove('scrolled');
        }
    });
}

// Efeito de digitação
function initTypingEffect() {
    const h2Element = document.querySelector('.home .texto-home h2');
    if (!h2Element) return;
    
    const currentLang = localStorage.getItem("lang") || 'pt';
    const professions = currentLang === 'pt' 
        ? ['Desenvolvedor FullStack', 'Desenvolvedor C# .NET', 'Desenvolvedor JavaScript', 'Desenvolvedor React', 'Desenvolvedor Vue.js']
        : ['FullStack Developer', 'C# .NET Developer', 'JavaScript Developer', 'React Developer', 'Vue.js Developer'];
    
    let professionIndex = 0;
    let charIndex = 0;
    let isDeleting = false;
    let typingSpeed = 100;
    
    function type() {
        const currentText = professions[professionIndex];
        
        if (isDeleting) {
            h2Element.innerHTML = currentText.substring(0, charIndex - 1) + '<span class="typing-animation"></span>';
            charIndex--;
            typingSpeed = 50;
        } else {
            h2Element.innerHTML = currentText.substring(0, charIndex + 1) + '<span class="typing-animation"></span>';
            charIndex++;
            typingSpeed = 100;
        }
        
        if (!isDeleting && charIndex === currentText.length) {
            typingSpeed = 2000;
            isDeleting = true;
        } else if (isDeleting && charIndex === 0) {
            isDeleting = false;
            professionIndex = (professionIndex + 1) % professions.length;
            typingSpeed = 500;
        }
        
        setTimeout(type, typingSpeed);
    }
    
    type();
}

// Animação dos contadores
function initCounters() {
    const counters = document.querySelectorAll('.stat-number');
    const speed = 200;
    
    const animateCounter = (counter) => {
        const target = +counter.getAttribute('data-target');
        const count = +counter.innerText;
        const increment = target / speed;
        
        if (count < target) {
            counter.innerText = Math.ceil(count + increment);
            setTimeout(() => animateCounter(counter), 10);
        } else {
            counter.innerText = target + (target === 20 ? '+' : '');
        }
    };
    
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                animateCounter(entry.target);
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.5 });
    
    counters.forEach(counter => observer.observe(counter));
}
