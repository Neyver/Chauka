const userId = JSON.parse(localStorage.getItem('Account'))['Id'];

var url = 'http://localhost:5387/api/events';

const saveEvent = () => {
  var data = {};

  data.NameEvent = document.getElementById('event-name').value;
  const startDate = document.getElementById('start-date').value;
  const startTime = document.getElementById('start-time').value;
  data.StartDatetime = startDate +" "+ startTime;
  data.UserId = userId;
  data.Latitude = parseFloat(document.getElementById('latitude').value);
  data.Longitude = parseFloat(document.getElementById('longitude').value);

  if (data.NameEvent === '' || startDate === '' || startTime === '') {
    // alert('Complete the required data');
    message = 'Complete the required data'
  }
  else if(Number.isNaN(data.Latitude))
  {
    // alert('Mark event position')
    message = 'Mark event position'
  }
  else {
    var json = JSON.stringify(data);
    fetch(url, {
      body: json,
      headers: {'content-type': 'application/json'},
      method: 'POST'
    }).then(data => data.json())
    .then(response => {
        if(response['Success'] === true) {
          window.location.href = 'events.html';
        } else {
          // alert(response['Message']);
          message = response['Message']
        }
      })
      .catch(error => {
        // alert("Error: "+error);
        message = "Error: "+error
      })
  }
}

const cancelEventCreation = () => {
  window.location.href = 'events.html'
}
