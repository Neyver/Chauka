const Account = localStorage.getItem('Account');
console.log(Account);

function fillPage() {
    fillHeader();
  getEvents();
}

function fillHeader() {
  const account = JSON.parse(Account);
  const headerAccount = document.getElementById('header-account');
  let contentHeaderAccount = headerAccount.innerHTML;
  contentHeaderAccount += account['Name'];
  headerAccount.innerHTML = contentHeaderAccount;
}

function getEvents() {
  const account = JSON.parse(Account);
  const userId = account['Id'];
  fetch('http://localhost:5387/api/Events?userId=' + userId)
    .then(response => response.json())
    .then(data => {
      console.log(data);
      if(data['Success'] === true) {
        console.log(data['Message']);
        fillTableEvents(data['Data']['Events']);
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

function fillTableEvents(events) {
  if(events !== null) {
    let tableEvents = document.getElementById('table-events-user');
    let contentTable = "";
    events.forEach((event) => {
      contentTable += '<tr>\
        <td>' + event['NameEvent'] + '</td>\
        <td>' + event['StartDatetime'] + '</td>\
        <td> <a href="info-event.html?eventId=' + event['Id'] + '"> <i class="material-icons">insert_drive_file</i> </a> </td>\
      </tr>'
    });
    tableEvents.innerHTML = contentTable;
  }
}
