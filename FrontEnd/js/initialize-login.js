function validateLogin() {

    var username = document.getElementById("userId").value;
    console.log(username);
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log(this.responseText);
            let obj = JSON.parse(this.responseText);
            if (obj.Success===true) {
                localStorage.clear()
                localStorage.setItem('Account', JSON.stringify(obj.Data));
                location.href = "events.html";
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
    xhttp.open("GET", "http://localhost:5387/api/Accounts?accountName=" + username+"", true);
    xhttp.send();

}


/*
{"Message":"User not found","Success":false,"Data":null}
*/
