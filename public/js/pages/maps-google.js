//------------- maps-google.js -------------//
$(document).ready(function() {

	//------------- Google maps -------------//
    //basic map
    var bmap = new GMaps({
        el: '#gmap',
        lat: -12.043333,
        lng: -77.028333,
        zoomControl : true,
        zoomControlOpt: {
            style : 'SMALL',
            position: 'TOP_LEFT'
        },
        panControl : false,
        streetViewControl : false,
        mapTypeControl: false,
        overviewMapControl: false
    });

    //geolocation
    var gmap = new GMaps({
        el: '#gmap-geolocation',
        lat: -12.043333,
        lng: -77.028333
    });

    GMaps.geolocate({
        success: function(position){
          gmap.setCenter(position.coords.latitude, position.coords.longitude);
        },
        error: function(error){
            $.gritter.add({
                title: 'Error !!!',
                text: 'Geolocation failed: '+error.message,
                close_icon: 'en-cross',
                icon: 'ec-location',
                class_name: 'error-notice'
            }); 
        },
        not_supported: function(){
            $.gritter.add({
                title: 'Error !!!',
                text: 'Your browser do not support geolocation',
                close_icon: 'en-cross',
                icon: 'ec-location',
                class_name: 'error-notice'
            }); 
        },
        always: function(){
            $.gritter.add({
                title: 'Done !!!',
                text: 'Your location is detected',
                close_icon: 'en-cross',
                icon: 'ec-location',
                class_name: 'success-notice'
            });     
        }
    });

    //routes
    var rmap = new GMaps({
        el: '#gmap-routes',
        lat: -12.043333,
        lng: -77.028333
    });
    rmap.drawRoute({
        origin: [-12.044012922866312, -77.02470665341184],
        destination: [-12.090814532191756, -77.02271108990476],
        travelMode: 'driving',
        strokeColor: '#db5565',
        strokeOpacity: 0.6,
        strokeWeight: 10
    });

    //street panorama
    panorama = GMaps.createPanorama({
        el: '#gmap-street-panorama',
        lat : 42.3455,
        lng : -71.0983
    });
	
});

//sparkline in sidebar area
var positive = [1,5,3,7,8,6,10];
var negative = [10,6,8,7,3,5,1]
var negative1 = [7,6,8,7,6,5,4]

$('#stat1').sparkline(positive,{
    height:15,
    spotRadius: 0,
    barColor: '#9FC569',
    type: 'bar'
});
$('#stat2').sparkline(negative,{
    height:15,
    spotRadius: 0,
    barColor: '#ED7A53',
    type: 'bar'
});
$('#stat3').sparkline(negative1,{
    height:15,
    spotRadius: 0,
    barColor: '#ED7A53',
    type: 'bar'
});
$('#stat4').sparkline(positive,{
    height:15,
    spotRadius: 0,
    barColor: '#9FC569',
    type: 'bar'
});
//sparkline in widget
$('#stat5').sparkline(positive,{
    height:15,
    spotRadius: 0,
    barColor: '#9FC569',
    type: 'bar'
});

$('#stat6').sparkline(positive, { 
    width: 70,//Width of the chart - Defaults to 'auto' - May be any valid css width - 1.5em, 20px, etc (using a number without a unit specifier won't do what you want) - This option does nothing for bar and tristate chars (see barWidth)
    height: 20,//Height of the chart - Defaults to 'auto' (line height of the containing tag)
    lineColor: '#88bbc8',//Used by line and discrete charts to specify the colour of the line drawn as a CSS values string
    fillColor: '#f2f7f9',//Specify the colour used to fill the area under the graph as a CSS value. Set to false to disable fill
    spotColor: '#e72828',//The CSS colour of the final value marker. Set to false or an empty string to hide it
    maxSpotColor: '#005e20',//The CSS colour of the marker displayed for the maximum value. Set to false or an empty string to hide it
    minSpotColor: '#f7941d',//The CSS colour of the marker displayed for the mimum value. Set to false or an empty string to hide it
    spotRadius: 3,//Radius of all spot markers, In pixels (default: 1.5) - Integer
    lineWidth: 2//In pixels (default: 1) - Integer
});