const Account = localStorage.getItem('Account');
console.log(Account);

function fillPage() {
  fillHeader();
  fillEvents();
}

function fillHeader() {
  const account = JSON.parse(Account);
  const headerAccount = document.getElementById('header-account');
  let contentHeaderAccount = headerAccount.innerHTML;
  contentHeaderAccount += account['Name'];
  headerAccount.innerHTML = contentHeaderAccount;
}

function fillEvents() {

}
