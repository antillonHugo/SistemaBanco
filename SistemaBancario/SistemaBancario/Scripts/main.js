
// Carga el archivo JavaScript
//elementos del menu de la etiqueta nav
let menu = document.querySelector(".nav");
let nav_button = document.querySelector(".header__button");

// Agrega los listeners de eventos
nav_button.addEventListener("click", e => {
    //alert("DDd");
    menu.classList.toggle("nav__options_show");
    menu.transition("display", 1000);
});

/*

let login__buttoncreate = document.querySelector(".login__group--create");

login__buttoncreate.addEventListener("click", e => {
    e.preventDefault();

    alert("HOLA");
});
*/