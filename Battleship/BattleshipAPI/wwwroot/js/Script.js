function getUser() {
    var user = JSON.parse(sessionStorage.user);

    fetch('api/users/' + user.id, {
        headers: {
            'Authorization': 'Bearer ' + user.token,
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
    .then(function (response) {
        if (response.status == 401) {
            window.alert(response.statusText+ " - Accès non autorisé !");
        }
        else if (response.status == 200) {
            window.location.replace("Profil.html");
        }
    })
    .catch(error => console.error('Error ', error));
}


function game(res) {
    fetch('api/game', {
        headers: {
            'Authorization': 'Bearer ' + res.token
        }
    })
        .then(function (response) {
            if (response.status == 200) {
                window.location.replace("Game.html");
                sessionStorage.setItem("user",JSON.stringify(res))
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
                game(response);
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