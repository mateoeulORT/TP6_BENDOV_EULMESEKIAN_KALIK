document.addEventListener('DOMContentLoaded', function () {
    const nombreInput = document.getElementById('nombre');
    const apellidoInput = document.getElementById('apellido');
    const fotoInput = document.getElementById('foto');
    const deporteSelect = document.getElementById('deporte');
    const paisSelect = document.getElementById('pais');
    const fechaNacimientoInput = document.querySelector('input[name="FechaNacimiento"]');

    const nombreApellidoJugador = document.getElementById('nombre-apellido-jugador');
    const fotoJugador = document.querySelector('.card-img-top');
    const deporteJugador = document.getElementById('deporte-jugador');
    const paisJugador = document.getElementById('pais-jugador');
    const fechaNacimientoJugador = document.getElementById('fecha-nacimiento-jugador');
    const logoDeporte = document.getElementById('logo-deporte');

    function updateCard() {
        nombreApellidoJugador.textContent = `${nombreInput.value} ${apellidoInput.value}`;
        fotoJugador.src = fotoInput.value;
        deporteJugador.textContent = deporteSelect.options[deporteSelect.selectedIndex].text;

        // Actualizar el logo del deporte
        logoDeporte.src = deporteSelect.options[deporteSelect.selectedIndex].getAttribute('data-logo');

        fechaNacimientoJugador.textContent = `Fecha de Nacimiento: ${fechaNacimientoInput.value}`;

        const selectedPais = paisSelect.options[paisSelect.selectedIndex];
        paisJugador.src = selectedPais.getAttribute('data-flag');
        paisJugador.alt = selectedPais.text;
    }

    function clearCard() {
        nombreApellidoJugador.textContent = '';
        fotoJugador.src = '';
        deporteJugador.textContent = '';
        logoDeporte.src = '';
        paisJugador.src = '';
        paisJugador.alt = '';
        fechaNacimientoJugador.textContent = '';
    }

    nombreInput.addEventListener('input', updateCard);
    apellidoInput.addEventListener('input', updateCard);
    fotoInput.addEventListener('input', updateCard);
    deporteSelect.addEventListener('change', updateCard);
    paisSelect.addEventListener('change', updateCard);
    fechaNacimientoInput.addEventListener('input', updateCard);

    document.querySelector('input[type="reset"]').addEventListener('click', function(event) {
        clearCard();
    });
});