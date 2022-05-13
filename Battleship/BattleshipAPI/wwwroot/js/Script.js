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
    auth();
	var fire = eventObj.target;

    if(count == 0){
        sessionStorage.setItem("ShipStartPos",[Math.floor(fire.id / 10), fire.id % 10].toString());
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
            sessionStorage.setItem("ShipEndPos",[Math.floor(fire.id / 10), fire.id % 10].toString());
            document.getElementById(fire.id).parentElement.style.backgroundColor = "#f5d972";
            count++;
        }
    }

    if(count == 2){

        var cellStart = sessionStorage.getItem("ShipStartPos").replace(',','');
        var cellEnd = sessionStorage.getItem("ShipEndPos").replace(',','');

        document.getElementById(cellStart).parentElement.style.backgroundColor = "";
        document.getElementById(cellEnd).parentElement.style.backgroundColor = "";

        var start = sessionStorage.getItem("ShipStartPos").split(",").map(str => {return Number(str);});
        var end = sessionStorage.getItem("ShipEndPos").split(",").map(str => { return Number(str);});
        position = [start,end]
        count++;
        sessionStorage.removeItem("ShipStartPos");
        sessionStorage.removeItem("ShipEndPos");
        count = 0;
        
        tryShip(position);
    }
}

function tryShip(position){
    auth();
    var user = JSON.parse(sessionStorage.user);

    const item = {
        isComplete: false,
        Start: position[0],
        End: position[1]
    };

    fetch('api/ship/placeship', {
        method: 'POST',
        headers: {
            'Authorization': 'Bearer ' + user.token,
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => Promise.all([response, response.json()]))
        .then(([status, data]) => {
        unauthorized(status);
        placeShip(data);
        })
        .catch(error => console.error('Error ', error));
}

function placeShip(ship) {
    if(ship.isValid){
        var positions = ship.positions;

        positions.forEach(element => {
            var cell = element.row.toString() + element.column.toString();
            document.getElementById(cell).parentElement.style.backgroundColor = "#42aee3";
            document.getElementById(cell).setAttribute("class","hit");
            
        });
    }
    else {
        window.alert("Placement invalide !");
    }
}

function unauthorized(response) {
    if(response.status == 401){
        window.alert("Vous n'avez pas accès à cette ressource");
        back();
    }
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
    window.alert("Vous avez été déconnecté");
}

function loadProfile() {
    auth();
    window.location.assign("Profil.html");
}

function getUser() {
    auth();
    var user = JSON.parse(sessionStorage.user);

    if(Array.from(user.roles).includes("Administrator")){
        document.getElementById('Title').innerHTML = "VOTRE ESPACE ADMIN"
        document.getElementById('Role').innerHTML = "Administrateur";
    }
    else {
        document.getElementById('Role').innerHTML= "Joueur";
    }
    getGames();

    fetch('api/users/' + user.id, {
        headers: {
            'Authorization': 'Bearer ' + user.token,
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
    .then(response => Promise.all([response, response.json()]))
    .then(([status, response]) => {
    unauthorized(status);
    document.getElementById('LastName').innerHTML= response.lastName;
    document.getElementById('FirstName').innerHTML= response.firstName;
    document.getElementById('UserName').innerHTML= response.userName;
    document.getElementById('Email').innerHTML= response.email;

    })
    .catch(error => console.error('Error ', error));
}

function game(res) {
    if (arguments.length == 0) {
        auth();
        res = JSON.parse(sessionStorage.user);
    }

    fetch('api/game/'+ res.id, {
        headers: {
            'Authorization': 'Bearer ' + res.token
        }
    })
        .then(response => Promise.all([response, response.json()]))
        .then(([status, data]) => {
        unauthorized(status);
        window.location.assign("Game.html");
        sessionStorage.setItem("user",JSON.stringify(res));
        sessionStorage.setItem("game",JSON.stringify(data));
        })

        .catch(error => console.error('Error ', error));
}

function getGame(id) {
    auth();
    var res = JSON.parse(sessionStorage.user);
    var game = JSON.parse(sessionStorage.game);

    fetch('api/game/get/' + game.id, {
        headers: {
            'Authorization': 'Bearer ' + res.token
        }
    })
        .then(response => Promise.all([response, response.json()]))
        .then(([status, data]) => {
        unauthorized(status);
        sessionStorage.setItem("user",JSON.stringify(res));
        sessionStorage.setItem("game",JSON.stringify(data));
        })

        .catch(error => console.error('Error ', error));
}

function getGames() {
    auth();
    var res = JSON.parse(sessionStorage.user);
    var url;

    if(Array.from(res.roles).includes("Administrator")){
        url = "api/game/history";
    }
    else {
        url = "api/game/history/" + res.id;
    }

    fetch(url, {
        headers: {
            'Authorization': 'Bearer ' + res.token
        }
    })
        .then(response => Promise.all([response, response.json()]))
        .then(([status, data]) => {
        unauthorized(status);

        var col = [];
        for (var i = 0; i < data.length; i++) {
            for (var key in data[i]) {
                if (col.indexOf(key) === -1) {
                    col.push(key);
                }
            }
        }
        var table = document.getElementById("stats");
        var tr = table.insertRow(-1);

        for (var i = 0; i < data.length; i++) {

            tr = table.insertRow(-1);

            for (var j = 0; j < col.length; j++) {
                var tabCell = tr.insertCell(-1);
                tabCell.innerHTML = data[i][col[j]];
            }
        }
        var divContainer = document.getElementById("showData");
        divContainer.innerHTML = "";
        divContainer.appendChild(table);
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
