document.write("<"+"script type='text/javascript' src='./js/configuration.js'><"+"/script>");
const Account = localStorage.getItem('Account');

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
  fetch(accountUrl + '/' + userId + '/events')
    .then(response => response.json())
    .then(data => {
      if(data['Success'] === true) {
        fillTableEvents(data['Data']['Events']);
      } else {
        message = data['Message']
      }
    })
    .catch(error => {
      message = error
    })
}

function fillTableEvents(events) {
  if(events !== null) {
    let tableEvents = document.getElementById('table-events-user');
    let contentTable = "";
    events.forEach((event) => {
	const startDatetime = new Date(event['StartDatetime']);
      contentTable += '<tr>\
        <td>' + event['NameEvent'] + '</td>\
        <td>' + startDatetime.toLocaleTimeString(regionalConfiguration, options) + '</td>\
        <td> <a href="info-event.html?eventId=' + event['Id'] + '"> <i class="material-icons">insert_drive_file</i> </a> </td>\
      </tr>'
    });
    tableEvents.innerHTML = contentTable;
  }
}

function getInvitations() {
  const account = JSON.parse(Account);
  const userId = account['Id'];
  fetch(invitationsUrl + '/' + userId)
    .then(response => response.json())
    .then(data => {
      if(data['Success'] === true) {
        fillTableInvitations(data['Data']['Events']);
      } else {
        message = data['Message']
      }
    })
    .catch(error => {
      message = error
    })
}

function fillTableInvitations(invitations) {
  if(invitations !== null) {
    let tableInvitations = document.getElementById('table-invitations-user');
    let contentTable = "";
    invitations.forEach((invitation) => {
      const startDatetime = new Date(invitation['StartDatetime']);
      contentTable += '<tr>\
        <td>' + invitation['NameEvent'] + '</td>\
        <td>' + startDatetime.toLocaleTimeString(regionalConfiguration, options) + '</td>\
        <td> <a href="info-event.html?eventId=' + invitation['EventId'] + '"> <i class="material-icons">insert_drive_file</i> </a> </td>\
        <td>\
          <div class="action accept" onclick="sendStatusInvitation('+ invitation['GuestId'] + ', ' + invitation['EventId'] + ', 1)">\
            <i class="material-icons" title="Accept">event_available</i>\
          </div>\
          <div class="action reject" onclick="sendStatusInvitation('+ invitation['GuestId'] + ', ' + invitation['EventId'] + ', 0)">\
            <i class="material-icons" title="Reject">event_busy</i>\
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
  fetch(invitationsUrl, {
    body: JSON.stringify(data),
    headers: {
      'content-type': 'application/json'
    },
    method: 'PUT',
  })
  .then(data => data.json())
  .then((response) => {
    if(status === "ACCEPTED") {
      getEvents();
    }
    getInvitations();
    message = response['Message']
  })
  .catch(error => message = error);
}
