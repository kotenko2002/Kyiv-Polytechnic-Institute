const container = document.getElementById('container');

async function getRandomPerson() {
    const server = 'https://randomuser.me/api';
    const response = await fetch(server, {
        method: 'GET',
    });

    const responseResult = await response.json();
    return responseResult.results[0];
}

async function add() {
    const person = await getRandomPerson();

    const temple = `
    <div class="card">
        <div>
            <img src="${person.picture.large}" alt="">
        </div>
        <div>
            <p><b>Name:</b> ${person.name.title} ${person.name.first} ${person.name.last}</p>
            <p><b>City:</b> ${person.location.city}</p>
            <p><b>Postcode:</b> ${person.location.postcode}</p>
            <p><b>Phone:</b> ${person.phone}</p>
        </div>
    </div>`;

    container.insertAdjacentHTML('afterbegin', temple);
}

function del() {
    container.innerHTML = '';
}

add();