const uri = 'api/LoginRegister';
let todos = [];


function game(token) {
    fetch('api/game', {
        headers: {
            'Authorization': 'Bearer ' + token
        }
    })
        .then(function (response) {
            if (response.status == 200) {
                window.location.replace("Game.html");
            }
            else {
                window.alert("Error " + response.statusText);
            }
            return response.text();
        })
        .catch(error => console.error('Error ', error));
}


function token(mail, pwd) {

    var email;
    var password;

    if (arguments.length == 0) {
        email = document.getElementById('Email').value.trim();
        password = document.getElementById('Password').value.trim();
    }
    else {
         email = mail;
        password = pwd;
    }

    const item = {
        isComplete: false,
        Email: email,
        Password: password
    };

    fetch('api/users/token', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then((response) => {
            if (response.isAuthenticated == false) {
                window.alert(response.message);
                password.value = '';
            }
            else if (response.isAuthenticated) {
                game(response.token);
            }

        })
        .catch(error => console.error('Error ', error));
}


function register() {
    const lastName = document.getElementById('LastName');
    const firstName = document.getElementById('FirstName');
    const userName = document.getElementById('UserName');
    const email = document.getElementById('Email1');
    const password = document.getElementById('Password1');

    const item = {
        isComplete: false,
        LastName: lastName.value.trim(),
        FirstName: firstName.value.trim(),
        UserName: userName.value.trim(),
        Email: email.value.trim(),
        Password: password.value.trim()
    };

    fetch('api/users/register', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then((response) => {
            window.alert(response);
            if (response == "L'e-mail est déjà enregistré") {
                email.value = '';
                password.value = '';
            }
            else if (response == "Inscription validée") {
                token(item.Email,item.Password)
            }
        })
        .catch(error => console.error('Error ', error));
}








function getUsers() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayUsers(data))
        .catch(error => console.error('Unable to get users.', error));
}

function addItem() {
    const addNameTextbox = document.getElementById('add-name');

    const item = {
        isComplete: false,
        name: addNameTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const item = todos.find(item => item.id === id);

    document.getElementById('edit-name').value = item.name;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-isComplete').checked = item.isComplete;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const item = {
        id: parseInt(itemId, 10),
        isComplete: document.getElementById('edit-isComplete').checked,
        name: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'to-do' : 'to-dos';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = item.isComplete;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(isCompleteCheckbox);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(item.name);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    todos = data;
}