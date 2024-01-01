
// Carga el archivo JavaScript
//elementos del menu de la etiqueta nav
let menu = document.querySelector(".nav__options");
let nav_button = document.querySelector(".nav__icon");

// Agrega los listeners de eventos
nav_button.addEventListener("click", e => {
    menu.classList.toggle("nav__options_show");
});



let login__buttoncreate = document.querySelector(".login__group--create");

login__buttoncreate.addEventListener("click", e => {
    e.preventDefault();

    alert("HOLA");
});
