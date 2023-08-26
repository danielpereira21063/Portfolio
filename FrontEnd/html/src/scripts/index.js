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

const irPara = (url) =>{
    window.open("https://" + url, '_blank');
}