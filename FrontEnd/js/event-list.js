const Account = localStorage.getItem('Account');
console.log(Account);

function fillPage() {
  fillHeader();
  getEvents();
  getInvitations();
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
      console.log(event['NameEvent']);
      contentTable += '<tr>\
        <td>' + event['NameEvent'] + '</td>\
        <td>' + event['StartDatetime'] + '</td>\
        <td> <a href="info-event.html?eventId=' + event['Id'] + '"> <i class="material-icons">insert_drive_file</i> </a> </td>\
      </tr>'
    });
    tableEvents.innerHTML = contentTable;
  }
}

function getInvitations() {
  const account = JSON.parse(Account);
  const userId = account['Id'];
  fetch('http://localhost:5387/api/Invitations?userId=' + userId)
    .then(response => response.json())
    .then(data => {
      console.log(data);
      if(data['Success'] === true) {
        console.log(data['Message']);
        fillTableInvitations(data['Data']['Events']);
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

function fillTableInvitations(invitations) {
  if(invitations !== null) {
    let tableInvitations = document.getElementById('table-invitations-user');
    let contentTable = "";
    invitations.forEach((invitation) => {
      contentTable += '<tr>\
        <td>' + invitation['NameEvent'] + '</td>\
        <td>' + invitation['StartDatetime'] + '</td>\
        <td> <a href="info-event.html?eventId=' + invitations['EventId'] + '"> <i class="material-icons">insert_drive_file</i> </a> </td>\
        <td>\
          <div class="action" onclick="sendStatusInvitation('+ invitation['GuestId'] + ', ' + invitation['EventId'] + ', 1)">\
            <i class="material-icons">event_available</i>\
          </div>\
          <div class="action" onclick="sendStatusInvitation('+ invitation['GuestId'] + ', ' + invitation['EventId'] + ', 0)">\
            <i class="material-icons">event_busy</i>\
          </div>\
        </td>\
      </tr>'
    });
    tableInvitations.innerHTML = contentTable;
  }
}

function sendStatusInvitation (guestId, eventId, status) {
  const account = JSON.parse(Account);
  const userId = account['Id'];
  if(status) {
      status = "ACCEPTED"
  }
  else {
    status = "REJECTED"
  }
  const data = {
    Id: guestId,
    UserId: userId,
    EventId: eventId,
    Status: status
  }
  fetch('http://localhost:5387/api/Invitations', {
    body: JSON.stringify(data),
    headers: {
      'content-type': 'application/json'
    },
    method: 'PATCH',
  })
  .then(data => data.json())
  .then((response) => alert(response['Message']))
  .catch((error) => alert(error));
}
