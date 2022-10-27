let lastRandomColor = '';

function submitForm() {
    let isNotValid = false;
    const nameRegex = /[А-Я][а-я]+\s+[А-Я]\.\s+[А-Я]\./;
    const groupRegex = /[а-щА-ЩЬьЮюЯяЇїІіЄєҐґ]{2}-[0-9]{2}/;
    const facultyRegex = /[а-щА-ЩЬьЮюЯяЇїІіЄєҐґ]{4}/;
    const birthdateRegex = /[0-9]{2}\.[0-9]{2}\.[0-9]{4}/; 

    const nameElem = document.getElementById('name');
    const name = nameElem.value
    if (name == null | name.length <= 5 | !nameRegex.test(name)) {
        alert("Введіть правильне ПІБ");
        isNotValid = true
        nameElem.style.border = '1px solid red'
    } else {
        nameElem.style.border = '1px solid green'
    }

    const variantElem = document.getElementById('variant');
    const variant = variantElem.value
    if (variant == null || variant <= 0 || variant > 10) {
        if (!isNotValid) {
            alert("Введіть правильний варіант");
        }
        variantElem.style.border = '1px solid red'
        isNotValid = true
    } else {
        variantElem.style.border = '1px solid green'
    }

    const groupElem = document.getElementById('group');
    const group = groupElem.value
    if (group == null || group.length != 5 || !groupRegex.test(group)) {
        if (!isNotValid) {
            alert("Введіть правильну групу");
        }
        groupElem.style.border = '1px solid red'
        isNotValid = true
    } else {
        groupElem.style.border = '1px solid green'
    }

    const facultyElem = document.getElementById('faculty');
    const faculty = facultyElem.value
    if (faculty == null || faculty.length != 4 || !facultyRegex.test(faculty)) {
        if (!isNotValid) {
            alert("Введіть правильний факультет");
        }
        facultyElem.style.border = '1px solid red'
        isNotValid = true
    } else {
        facultyElem.style.border = '1px solid green'
    }

    const birthdateElem = document.getElementById('birthdate');
    const birthdate = birthdateElem.value
    if (birthdate == null || birthdate.length != 10 || !birthdateRegex.test(birthdate)) {
        if (!isNotValid) {
            alert("Введіть правильну дату народження");
        }
        birthdateElem.style.border = '1px solid red'
        isNotValid = true
    }
    if (isNotValid) {
        return false;
    } else {
        birthdateElem.style.border = '1px solid green'
    }

    document.getElementById('name-value').innerHTML = name;
    document.getElementById('variant-value').innerHTML = variant;
    document.getElementById('group-value').innerHTML = group;
    document.getElementById('faculty-value').innerHTML = faculty;
    document.getElementById('birthdate-value').innerHTML = birthdate;


    const responseBlock = document.getElementById('response-block');
    responseBlock.style.display = 'block'

    return false;
}

function createTable() {
    let rows = 6;
    let cols = 6;
    let table = document.getElementById("changing-table");
    table.innerHTML = '';
    for (let i = 0; i < rows; i++) {
        var row = table.insertRow(i);
        for (let j = 0; j < cols; j++)
        row.insertCell(j);
    }
}
function printNumbers() {
    let rows = document.getElementById("changing-table").children[0].children;
    for (let i = 0; i < rows.length; i++) {
        let cols = rows[i].children;
        for (let j = 0; j < cols.length; j++) {
                let cell = cols[j];
                cell.innerHTML = `${i*6+j+1}`;
                cell.addEventListener("click", changeColorByClick)
                cell.addEventListener("mouseover", changeColorByHover)
                cell.addEventListener("mouseout", changeColorByUnhover)
                cell.addEventListener("dblclick", changeColorByDbclick)
        }
    }
}

function changeColorByClick(e) {
    if (e.srcElement.innerHTML !== '9') {
        return;
    }
    this.style.background = document.getElementById("palit").value;
}

function changeColorByHover(e) {
    if (e.srcElement.innerHTML !== '9') {
        return;
    }

    this.style.background = random_rgba()
}

function changeColorByUnhover(e) {
    if (e.srcElement.innerHTML !== '9') {
        return;
    }
 
    if (this.style.background === lastRandomColor) {
        this.style.background = 'white'
    }
}

function changeColorByDbclick() {
    if (this.innerHTML !== '9') {
        return;
    }
    const values = ['9', '21', '33'];
    const tds = document.querySelectorAll('td')
    tds.forEach((td) => {
        if(values.includes(td.innerHTML)) {
            td.style.background = td.style.background === 'rgb(217, 255, 0)' ? 'white' : 'rgb(217, 255, 0)';
        }
    })
}

function random_rgba() {
    var o = Math.round, r = Math.random, s = 255;
    const color = 'rgb(' + o(r()*s) + ', ' + o(r()*s) + ', ' + o(r()*s) + ')';
    lastRandomColor = color;
    return color;
}

createTable()
printNumbers()