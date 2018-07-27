const userId = JSON.parse(localStorage.getItem('Account'))['Id'];

var url = 'http://localhost:5387/api/guests';

const saveEvent = () => {
  var data = {};

  var accountName = document.getElementById("accountName").value
  
  data.EventId = getElement('eventId');
  data.AccountName = accountName;

  var json = JSON.stringify(data);
  console.log(json);
  fetch(url, {
    body: json,
    headers: {'content-type': 'application/json'},
    method: 'POST'
  }).then(data => data.json())
  .then(response => {
      console.log(response);
      if(response['Success'] === true) {
        console.log(response['Message']);
        window.location.href = 'info-event.html';
      } else {
        console.log(response['Message']);
        alert(response['Message']);
      }
    })
    .catch(error => {
      console.log(error);
      alert("Error: "+error);
    })
}

function getElement(name){
	name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    let regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    let results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
}

const cancelEventCreation = () => {
  window.location.href = 'info-event.html'
}