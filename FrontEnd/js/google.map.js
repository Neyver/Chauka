var map;
var markers = []
function initialize() {
  var mapOptions = {
    zoom: 15,
    center: {lat: -17.373949, lng: -66.154064},
    disableDoubleClickZoom: true
  };
  map = new google.maps.Map(document.getElementById('map'),
      mapOptions);

  google.maps.event.trigger(map, 'resize');

  google.maps.event.addListener(map,'click',function(event) {
    markers.map(m => m = m.setMap(null))
    var marker = new google.maps.Marker({
      position: event.latLng,
      map: map,
      title: event.latLng.lat()+', '+event.latLng.lng()
    });
    document.getElementById('latitude').value = event.latLng.lat()
    document.getElementById('longitude').value = event.latLng.lng()
    markers.push(marker)
    marker.addListener('click', function() {
      var infoWindow = new google.maps.InfoWindow({
        content: `<p>This is my position</p>`
      });
      infoWindow.open(map, marker);
    });
  });
}

google.maps.event.addDomListener(window, 'load', initialize);
