const MIN_CHARACTERS = 3;

document.getElementById('searchInput').addEventListener('keypress', function (event) {
    if (event.key === 'Enter') {
        event.preventDefault();
        searchCountry();
    }
});

function searchCountry() {
    let input = document.getElementById('searchInput').value.trim().toLowerCase();
    
    if (input.length < MIN_CHARACTERS) {
        return;
    }


    let cards = document.querySelectorAll('.card');


    cards.forEach(card => {
        card.classList.remove('highlight');
        card.style.backgroundColor = ''; 
        card.style.color = '';
    });


    let found = false;
    cards.forEach(card => {
        let countryName = card.querySelector('.card-title').textContent.toLowerCase();

        if (countryName.includes(input)) {
            found = true;
            card.style.backgroundColor = '#333'; 
            card.style.color = '#fff';
            card.classList.add('highlight');


            card.scrollIntoView({ behavior: 'smooth', block: 'center' });

            return;
        }
    });


}