const Account = localStorage.getItem('Account');
const UserEvents = localStorage.getItem('EventsUser');
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
  let xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function () {
      if (this.readyState == 4 && this.status == 200) {
          console.log(this.responseText);
          let obj = JSON.parse(this.responseText);
          if(obj.Success===true){
              localStorage.setItem('EventsUser', JSON.stringify(obj.Data));
              fillTableEvents();
          }
          else {
              alert("ERROR: \n"+obj.Message);
          }

      }
      else {
          if (this.readyState == 4 && this.status != 200) {
              if (this.readyState == 4 && this.status == 400) {
                  let obj = JSON.parse(this.responseText);
                  alert(obj.Message);
              }
              else {
                  alert("Unexpected error!\n could not be processed.");
              }
              console.log(this.responseText);
              console.log(this.statusText);
              console.log(this.readyState);
              console.log(this.getAllResponseHeaders());
          }
      }
  };
  xhttp.open("GET", "http://localhost:5387/api/Events?userId=" + userId +"", true);
  xhttp.send();
}

function fillTableEvents() {
  if(UserEvents !== null) {
    const userEvents = JSON.parse(UserEvents);
    let tableEvents = document.getElementById('table-events-user');
    let contentTable = "";
    let events = userEvents['Events'];
    events.forEach((event) => {
      contentTable += '<tr>\
        <td>' + event['NameEvent'] + '</td>\
        <td>' + event['StartDatetime'] + '</td>\
        <td>' + event['EndDatetime'] + '</td>\
        <td> <a href="info-event?Id=' + event['Id'] + '.html"> <i class="material-icons">insert_drive_file</i> </a> </td>\
      </tr>'
    });
    tableEvents.innerHTML = contentTable;
  }
}
