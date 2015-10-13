//------------- maps-vector.js -------------//
$(document).ready(function() {

    //Get height of page and substract the paddings of page to adjust the map panel to fit the screen
    pageHeight = $( window ).height() -225;

    $("#world-map-markers").css('height', pageHeight);

	//------------- Vector maps -------------//
    $('#world-map-markers').vectorMap({
        map: 'world_mill_en',
        scaleColors: ['#f7f9fe', '#29b6d8'],
        normalizeFunction: 'polynomial',
        hoverOpacity: 0.7,
        hoverColor: false,
        focusOn:{
            x: 0.5,
            y: 0.5,
            scale: 2.0
        },
        zoomMin:0.85,
        markerStyle: {
          initial: {
            fill: '#ec8765',
            stroke: '#ec8765'
          }
        },
        backgroundColor: '#fff',
        regionStyle:{
            initial: {
                fill: '#dde1e7',
                "fill-opacity": 1,
                stroke: '#f7f9fe',
                "stroke-width": 0,
                "stroke-opacity": 0
            },
            hover: {
                "fill-opacity": 0.8
            },
            selected: {
                fill: 'yellow'
            }
        },
        markers: [
            //http://www.latlong.net/
            {latLng: [51.507351, -0.127758], name: 'London'},
            {latLng: [41.385064, 2.173403], name: 'Barcelona'},
            {latLng: [40.712784, -74.005941], name: 'New York'},
            {latLng: [-22.911632, -43.188286], name: 'Rio De Janeiro'},
            {latLng: [49.282729, -123.120738], name: 'Vancuver'},
            {latLng: [35.689487, 139.691706], name: 'Tokio'},
            {latLng: [55.755826, 37.617300], name: 'Moskva'},
            {latLng: [43.214050, 27.914733], name: 'Varna'},
            {latLng: [30.044420, 31.235712], name: 'Cairo'}         
        ]
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