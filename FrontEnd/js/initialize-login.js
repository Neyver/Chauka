localStorage.clear();

setFormLogin = () => {
  document.getElementById("userId").focus()
}

function validateLogin() {
  var username = document.getElementById("userId").value
  if (username === '' ) {
    message = 'The account name must not be empty'
  }
  else {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            let obj = JSON.parse(this.responseText);
            if (obj.Success===true) {
                localStorage.clear();
                localStorage.setItem('Account', JSON.stringify(obj.Data));
                location.href = "events.html";
            }
            else {
                message = obj.Message
            }

        }
        else {
            if (this.readyState == 4 && this.status != 200) {
                if (this.readyState == 4 && this.status == 400) {
                    let obj = JSON.parse(this.responseText);
                    message = obj.Message
                }
                else {
                    message = 'Unexpected error!\n could not be processed.'
                }
            }
        }
    };
    xhttp.open('GET', 'http://localhost:5387/api/Accounts?accountName=' + username + '', true);
    xhttp.send();
  }
}


/*
{"Message":"User not found","Success":false,"Data":null}
*/
