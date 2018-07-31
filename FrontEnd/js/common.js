if(localStorage.getItem('Account') === null){
	window.location.href = 'login.html'
}

function logout() {
	localStorage.clear();
	window.location.href = 'login.html';
}