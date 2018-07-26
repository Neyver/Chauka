const Account = JSON.parse(localStorage.getItem('Account'))

const fillHeader = () => {
  const headerAccount = document.getElementById('header-account');
  let contentHeaderAccount = headerAccount.innerHTML;
  contentHeaderAccount += Account['Name'];
  headerAccount.innerHTML = contentHeaderAccount;
}


var url = 'http://localhost:5387/api/events';

const saveEvent = () => {
  var data = {};

  data.NameEvent = document.getElementsById('name-event');
  data.StartDatetime = document.getElementsById('name-event');
  data.EndDatetime = document.getElementsById('name-event');
  data.UserId = Account['Id'];
  data.Latitude = parseFloat(document.getElementsById('input'));
  data.Longitude = parseFloat(document.getElementsById('input'));

  var json = JSON.stringify(data);
  fetch(url, {
    body: json,
    headers: {'content-type': 'application/json'},
    method: 'POST'
  }).then(data => {
      console.log(data);
      if(data['Success'] === true) {
        console.log(data['Message']);
        window.location.href = 'events.html';
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

const cancelCreation = () => {
  window.location.href = 'events.html'
}