const Account = localStorage.getItem('Account');
var eventId;

function fillPage() {
    fillHeader();
    eventId = getElement("Id");
    console.log(eventId);
    getEventById();
}

function fillHeader() {
    const account = JSON.parse(Account);
    const headerAccount = document.getElementById('header-account');
    let contentHeaderAccount = headerAccount.innerHTML;
    contentHeaderAccount += account['Name'];
    headerAccount.innerHTML = contentHeaderAccount;
}

function getEventById() {
    fetch('http://localhost:5387/api/Events?eventId=' + eventId)
        .then(response => response.json())
        .then(data => {
            console.log(data);
            if (data['Success'] === true) {
                console.log(data['Message']);
                fillEvents(data['Data']);
            } else {
                console.log(data['Message']);
                alert(data['Message']);
            }
        })
        .catch(error => {
            console.log(error);
            alert(error);
        })
}

function getElement(name) {
    name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    let regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    let results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
}

function fillEvents(data) {
    console.log('asd');
    if (data !== null) {
        let nameEvent = document.getElementById('name-event');
        nameEvent.innerHTML = data.NameEvent;
        let startDate = document.getElementById('start-date');
        startDate.innerHTML = data.StartDatetime;
        let endDate = document.getElementById('end-date');
        endDate.innerHTML = data.EndDatetime;
        getMap(data);
    }
}

function getMap(data) {
    var mapOptions = { lat: data.Latitude, lng: data.Longitude};
    var map = new google.maps.Map(document.getElementById('map'), { zoom: 14, center: mapOptions });
    var marker = new google.maps.Marker({ position: mapOptions, map: map });

}


function cancelPosition() {
    window.location.href = 'events.html'
}