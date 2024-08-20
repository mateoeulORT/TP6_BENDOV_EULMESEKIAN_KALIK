document.addEventListener('DOMContentLoaded', function() {
    const listaDeportes = document.querySelectorAll('.lista-deportes');
    const logoGrande = document.getElementById('mostrar-logo-deporte');
    const nombreDeporte = document.getElementById('nombre-deporte');

    listaDeportes.forEach(deporte => {
        deporte.addEventListener('mouseover', function() {
            const imageSrc = this.getAttribute('data-image');
            const deporteName = this.getAttribute('data-name');
            logoGrande.src = imageSrc;
            nombreDeporte.textContent = deporteName;
        });
    });
});