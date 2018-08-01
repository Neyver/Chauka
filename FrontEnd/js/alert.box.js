var AlertBox = function(option) {
  this.show = function(msg) {
    if (msg === ''  || typeof msg === 'undefined' || msg === null) {
      throw '"msg parameter is empty"';
    }
    else {
      var alertArea = document.querySelector('#alert-area');
      var alertBox = document.createElement('div');
      var alertContent = document.createElement('div');
      var alertClose = document.createElement('a');
      var alertClass = this;
      alertContent.classList.add('alert-content');
      alertContent.innerText = msg;
      alertClose.classList.add('alert-close');
      alertClose.setAttribute('href', '#');
      alertBox.classList.add('alert-box');
      alertBox.appendChild(alertContent);
      if (!option.hideCloseButton || typeof option.hideCloseButton === 'undefined') {
        alertBox.appendChild(alertClose);
      }
      alertArea.appendChild(alertBox);
      alertClose.addEventListener('click', function(event) {
        event.preventDefault();
        alertClass.hide(alertBox);
      });
      if (!option.persistent) {
        var alertTimeout = setTimeout(function() {
          alertClass.hide(alertBox);
          clearTimeout(alertTimeout);
        }, option.closeTime);
      }
    }
  };

  this.hide = function(alertBox) {
    alertBox.classList.add('hide');
    var disperseTimeout = setTimeout(function() {
      alertBox.parentNode.removeChild(alertBox);
      clearTimeout(disperseTimeout);
    }, 500);
  };
};

var alertNonPersistent = document.querySelector('#alert');

var alertbox = new AlertBox({
  closeTime: 5000,
  persistent: false,
  hideCloseButton: false
});


var message = 'message'

if (alertNonPersistent != null) {  
  alertNonPersistent.addEventListener('click', function() {
    alertbox.show(message)
    message = ''
  });
}
