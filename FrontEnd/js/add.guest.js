const Account = localStorage.getItem('Account');

function fillHeader() {
  const account = JSON.parse(Account);
  const headerAccount = document.getElementById('header-account');
  let contentHeaderAccount = headerAccount.innerHTML;
  contentHeaderAccount += account['Name'];
  headerAccount.innerHTML = contentHeaderAccount;
}

const validateGuest = () => {
	var urlAccount = 'http://localhost:5387/api/accounts?accountName='+document.getElementById("accountName").value;
	var urlGuest = 'http://localhost:5387/api/guests?eventId='+ getElement('eventId');
	var data = {};
	fetch(urlAccount)
		.then(data => data.json())
		.then((responseText) => {
			let result = responseText;
			if (result.Success===true) {
				let userId = result.Data.Id;
				data.EventId = getElement('eventId');
				data.UserId = userId;
				var json = JSON.stringify(data);
			return fetch(urlGuest, {
					body: json,
					headers: {'content-type': 'application/json'},
					method: 'POST'
				  })
				  return Promise.resolve("asdaas");
			}
			else {
				alert("ERROR: \n"+result.Message);
			}
		})
		.then((data) => data.json())
		.then(response => {
		  if(response['Success'] === true) {
			alert(response['Message']);
			window.location.href = 'info-event.html?eventId='+ getElement('eventId');
		  } else {
			alert("ERROR: \n"+response['Message']);
		  }
		})
	.catch(error => {
		console.log(error);
    });
}

function getElement(name){
	name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    let regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    let results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
}

const cancelAddGuest = () => {
  window.location.href = 'info-event.html?eventId='+ getElement('eventId');
}