//------------- charts-morris.js -------------//
$(document).ready(function() {

    var chartColours = ['#88bbc8', '#ed7a53', '#9FC569', '#bbdce3', '#9a3b1b', '#5a8022', '#2c7282'];

	//------------- Line chart -------------//
    var day_data = [
        {"period": "2014-10-01", "Sales": 560, "PayPal": 300},
        {"period": "2014-10-02", "Sales": 340, "PayPal": 276},
        {"period": "2014-10-03", "Sales": 326, "PayPal": 189},
        {"period": "2014-10-04", "Sales": 730, "PayPal": 314},
        {"period": "2014-10-05", "Sales": 145, "PayPal": 140},
        {"period": "2014-10-06", "Sales": 190, "PayPal": 135},
        {"period": "2014-10-07", "Sales": 459, "PayPal": 356},
        {"period": "2014-10-08", "Sales": 567, "PayPal": 501},
        {"period": "2014-10-09", "Sales": 345, "PayPal": 203},
        {"period": "2014-10-10", "Sales": 800, "PayPal": 560}
    ];
    Morris.Line({
        element: 'morris-line-chart',
        data: day_data,
        xkey: 'period',
        ykeys: ['Sales', 'PayPal'],
        labels: ['Sales', 'Paypal'],
        resize: true,
        lineColors: chartColours,
        lineWidth: 2,
        pointSize: 4,
        hideHover: 'auto',
        preUnits: '$',
        fillOpacity: '0.6'
    });

    //------------- Line charts without points -------------//
    //we use the same data 
    Morris.Line({
        element: 'morris-line-chart-nopoints',
        data: day_data,
        xkey: 'period',
        ykeys: ['Sales', 'PayPal'],
        labels: ['Sales', 'Paypal'],
        resize: true,
        lineColors: chartColours,
        lineWidth: 2,
        pointSize: 0,
        hideHover: 'auto',
        preUnits: '$',
        fillOpacity: '0.6'
    });

    //------------- Area chart -------------//
    // Use Morris.Area instead of Morris.Line
    Morris.Area({
        element: 'morris-area-chart',
        data: [
            {x: '2005', y: 135, z: 125},
            {x: '2006', y: 207, z: 189},
            {x: '2007', y: 345, z: 301},
            {x: '2008', y: 256, z: 223},
            {x: '2009', y: 187, z: 167},
            {x: '2010', y: 345, z: 312},
            {x: '2011', y: 456, z: 423},
            {x: '2012', y: 401, z: 378},
            {x: '2013', y: 345, z: 311},
            {x: '2014', y: 412, z: 389}
        ],
        xkey: 'x',
        ykeys: ['y', 'z'],
        labels: ['Y', 'Z'],
        lineWidth: 0,
        pointSize: 0,
        resize: true,
        lineColors: chartColours,
        fillOpacity: '1'
        //behaveLikeLine: true,
    });

    //------------- Bar chart -------------//
    Morris.Bar({
        element: 'morris-bar-chart',
        data: [
            {x: '2005', y: 135, z: 125, a: 117},
            {x: '2006', y: 207, z: 189, a: 312},
            {x: '2007', y: 345, z: 301, a: 267},
            {x: '2008', y: 256, z: 223, a: 167},
            {x: '2009', y: 187, z: 167, a: 234},
            {x: '2010', y: 345, z: 312, a: 280},
            {x: '2011', y: 456, z: 423, a: 350},
            {x: '2012', y: 401, z: 378, a: 178},
            {x: '2013', y: 345, z: 311, a: 509},
            {x: '2014', y: 412, z: 389, a: 602}
        ],
        xkey: 'x',
        ykeys: ['y', 'z', 'a'],
        labels: ['Y', 'Z', 'A'],
        resize: true,
        barColors: chartColours,
        fillOpacity: '0.6'
    });

    //------------- Stacked bar chart -------------//
    Morris.Bar({
        element: 'morris-bar-stacked',
        data: [
            {x: '2005', y: 135, z: 125, a: 117},
            {x: '2006', y: 207, z: 189, a: 312},
            {x: '2007', y: 345, z: 301, a: 267},
            {x: '2008', y: 256, z: 223, a: 167},
            {x: '2009', y: 187, z: 167, a: 234},
            {x: '2010', y: 345, z: 312, a: 280},
            {x: '2011', y: 456, z: 423, a: 350},
            {x: '2012', y: 401, z: 378, a: 178},
            {x: '2013', y: 345, z: 311, a: 509},
            {x: '2014', y: 412, z: 389, a: 602}
        ],
        xkey: 'x',
        ykeys: ['y', 'z', 'a'],
        labels: ['Y', 'Z', 'A'],
        resize: true,
        barColors: chartColours,
        fillOpacity: '0.6',
        stacked: true
    });

    //------------- Donut chart -------------//
    Morris.Donut({
        element: 'morris-donut',
        data: [
            {value: 70, label: 'Desing'},
            {value: 15, label: 'Coding'},
            {value: 10, label: 'SEO'},
            {value: 5, label: 'Other'}
        ],
        formatter: function (x) { return x + "%"},
        colors: chartColours,
        resize: true
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