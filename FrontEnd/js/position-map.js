var map;
function initialize() {
   map = new google.maps.Map(document.getElementById('map-canvas'), {
     zoom: 3,
     center: {lat: -10, lng: -60}
   });
   
   var marker=new google.maps.Marker({
      position:map.getCenter(), 
      map:map, 
      draggable:true
   });
			
   google.maps.event.addListener(marker,'dragend',function(event) {
      document.getElementById("coords").value = this.getPosition().toString();
   });
}
google.maps.event.addDomListener(window, 'load', initialize);