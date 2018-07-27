const Account = localStorage.getItem('Account');

var url = 'http://localhost:5387/api/events';

const saveEvent = () => {
  var data = {};

  data.NameEvent = document.getElementById('event-name').value;
  const startDate = document.getElementById('start-date').value;
  const startTime = document.getElementById('start-time').value;
  data.StartDatetime = startDate +" "+ startTime;
  const endDate = document.getElementById('end-date').value;
  const endTime = document.getElementById('end-time').value;
  data.EndDatetime = endDate +" "+ endTime;
  data.UserId = userId;
  data.Latitude = parseFloat(document.getElementById('latitude').value);
  data.Longitude = parseFloat(document.getElementById('longitude').value);

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
        window.location.href = 'events.html';
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

const cancelEventCreation = () => {
  window.location.href = 'events.html'
}