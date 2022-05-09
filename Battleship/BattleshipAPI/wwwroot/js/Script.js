function startGame(diff) {
    window.alert("WORK IN PROGRESS");
}

function loadAdmin(){
    window.alert("WORK IN PROGRESS");
}

var count = 0;

function getCells() {
	var guessClick = document.getElementsByTagName("td");
		for (var i = 0; i < guessClick.length; i++) {
			guessClick[i].onclick = answer;
		}
}

function answer(eventObj) {
	var fire = eventObj.target;

    if(count == 0){
        sessionStorage.setItem("ShipStartPos",fire.id);
        document.getElementById(fire.id).parentElement.style.backgroundColor = "#f5d972";
        count++;
    }
    
    else if (count == 1){
        if(fire.id == sessionStorage.getItem("ShipStartPos")){
            document.getElementById(fire.id).parentElement.style.backgroundColor = "";
            sessionStorage.removeItem("ShipStartPos");
            count = 0;
        }
        else{
            sessionStorage.setItem("ShipEndPos",fire.id);
            document.getElementById(fire.id).parentElement.style.backgroundColor = "#f5d972";
            count++;
        }
    }

    if(count == 2){
        position = [sessionStorage.getItem("ShipStartPos"),sessionStorage.getItem("ShipEndPos")]
        count++;
        sessionStorage.removeItem("ShipStartPos");
        sessionStorage.removeItem("ShipEndPos");
        count = 0;
    }

    //TODO : Requete poste avec #position en paramètre
}

function auth() {
    if(sessionStorage.user == undefined){
        window.alert("Vous n'êtes pas connectés");
        window.location.assign("index.html");
    }
}

function back() {
    auth();
    history.back();
}

function disconnect() {
    auth();
    sessionStorage.removeItem("user");
    window.location.assign("index.html");
}

function loadProfile() {
    auth();
    window.location.assign("Profil.html");
}

function getUser() {
    console.log("test");
    auth();
    var user = JSON.parse(sessionStorage.user);

    fetch('api/users/' + user.id, {
        headers: {
            'Authorization': 'Bearer ' + user.token,
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then((response) => {
        document.getElementById('LastName').innerHTML= response.lastName;
        document.getElementById('FirstName').innerHTML= response.firstName;
        document.getElementById('UserName').innerHTML= response.userName;
        document.getElementById('Email').innerHTML= response.email;
        if(Array.from(user.roles).includes("Administrator")){
            document.getElementById('Role').innerHTML= "Administrateur";
        }
        else {
            document.getElementById('Role').innerHTML= "Joueur";
        }
        
    })
    .catch(error => console.error('Error ', error));
}


function game(res) {
    if (arguments.length == 0) {
        auth();
        res = JSON.parse(sessionStorage.user);
    }

    fetch('api/game', {
        headers: {
            'Authorization': 'Bearer ' + res.token
        }
    })
        .then(function (response) {
            if (response.status == 200) {
                window.location.assign("Game.html");
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
                document.getElementById('Password').value = '';
            }
            else if (response.isAuthenticated) {
                game(response);
            }
        })
        .catch(error => console.error('Error ', error));
}


function register() {
    email = document.getElementById('Email1');
    password = document.getElementById('Password1');

    const item = {
        isComplete: false,
        LastName: document.getElementById('LastName').value.trim(),
        FirstName: document.getElementById('FirstName').value.trim(),
        UserName: document.getElementById('UserName').value.trim(),
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
            else if (response.includes("Mot de passe trop faible")){
                password.value = '';
            }
            else if (response == "Inscription validée") {
                token(item.Email,item.Password)
            }
        })
        .catch(error => console.error('Error ', error));
}
