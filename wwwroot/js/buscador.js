const MIN_CHARACTERS = 3;

document.getElementById('searchInput').addEventListener('keypress', function (event) {
    if (event.key === 'Enter') {
        event.preventDefault();
        searchCountry();
    }
});

function searchCountry() {
    // Obtener el texto de búsqueda y verificar su longitud
    let input = document.getElementById('searchInput').value.trim().toLowerCase();
    
    if (input.length < MIN_CHARACTERS) {
        // Si el texto es menor que el mínimo, no hacer nada
        return;
    }

    // Obtener todas las tarjetas de los países
    let cards = document.querySelectorAll('.card');

    // Remover resaltado previo si existe
    cards.forEach(card => {
        card.classList.remove('highlight');
        card.style.backgroundColor = ''; // Reinicia el fondo
        card.style.color = ''; // Reinicia el color del texto
    });

    // Iterar sobre las tarjetas para buscar coincidencias
    let found = false;
    cards.forEach(card => {
        let countryName = card.querySelector('.card-title').textContent.toLowerCase();

        // Verificar si el nombre del país coincide con el texto de búsqueda
        if (countryName.includes(input)) {
            found = true;
            // Resaltar la tarjeta con fondo oscuro y texto claro
            card.style.backgroundColor = '#333'; // Fondo oscuro
            card.style.color = '#fff'; // Texto claro
            card.classList.add('highlight');
            
            // Desplazarse a la tarjeta encontrada
            card.scrollIntoView({ behavior: 'smooth', block: 'center' });

            // Detener la búsqueda después de encontrar la primera coincidencia
            return;
        }
    });


}