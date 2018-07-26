const Account = JSON.parse(localStorage.getItem('Account'))

const fillHeader = () => {
  const headerAccount = document.getElementById('header-account');
  let contentHeaderAccount = headerAccount.innerHTML;
  contentHeaderAccount += Account['Name'];
  headerAccount.innerHTML = contentHeaderAccount;
}

const cancelPosition = () => {
  window.location.href = 'events.html'
}

var url = 'http://localhost:5387/api/accounts';

const saveMyPosition = () => {
  var data = {}
  data.Id = Account['Id']
  data.Latitude = parseFloat(document.getElementsByTagName('input')[0].value)
  data.Longitude = parseFloat(document.getElementsByTagName('input')[1].value)
  var json = JSON.stringify(data)
  fetch(url, {
    body: json,
    headers: {'content-type': 'application/json'},
    method: 'PATCH'
  }).then(response => window.location.href = 'events.html')
}
