//------------- charts-other.js -------------//
$(document).ready(function() {

    //define colours first
    var chartColours = ['#88bbc8', '#ed7a53', '#9FC569', '#bbdce3', '#9a3b1b', '#5a8022', '#2c7282'];

    //generate random number for charts
    randNum = function(){
        return (Math.floor( Math.random()* (1+40-20) ) ) + 20;
    }

    //Some random data for sparklines
    var data = [[1, 3+randNum()], [2, 5+randNum()], [3, 8+randNum()], [4, 11+randNum()],[5, 14+randNum()],[6, 17+randNum()],[7, 20+randNum()], [8, 15+randNum()], [9, 18+randNum()], [10, 22+randNum()]];

    //------------- Sparklines -------------//
    //line default
    $("#spark-line").sparkline(data, {
        width: '100%',//Width of the chart - Defaults to 'auto' - May be any valid css width - 1.5em, 20px, etc (using a number without a unit specifier won't do what you want) - This option does nothing for bar and tristate chars (see barWidth)
        height: 30,//Height of the chart - Defaults to 'auto' (line height of the containing tag)
        lineColor: '#c4c4c4',//Used by line and discrete charts to specify the colour of the line drawn as a CSS values string
        fillColor: '#f3f3f3',//Specify the colour used to fill the area under the graph as a CSS value. Set to false to disable fill
        spotColor: '#7e7e7e',//The CSS colour of the final value marker. Set to false or an empty string to hide it
        maxSpotColor: '#9FC569',//The CSS colour of the marker displayed for the maximum value. Set to false or an empty string to hide it
        minSpotColor: '#ED7A53',//The CSS colour of the marker displayed for the mimum value. Set to false or an empty string to hide it
        spotRadius: 3,//Radius of all spot markers, In pixels (default: 1.5) - Integer
        lineWidth: 2//In pixels (default: 1) - Integer
    });

    //line blue
    $("#spark-line-blue").sparkline(data, {
        width: '100%',//Width of the chart - Defaults to 'auto' - May be any valid css width - 1.5em, 20px, etc (using a number without a unit specifier won't do what you want) - This option does nothing for bar and tristate chars (see barWidth)
        height: 30,//Height of the chart - Defaults to 'auto' (line height of the containing tag)
        lineColor: '#88bbc8',//Used by line and discrete charts to specify the colour of the line drawn as a CSS values string
        fillColor: '#f2f7f9',//Specify the colour used to fill the area under the graph as a CSS value. Set to false to disable fill
        spotColor: '#467e8c',//The CSS colour of the final value marker. Set to false or an empty string to hide it
        maxSpotColor: '#9FC569',//The CSS colour of the marker displayed for the maximum value. Set to false or an empty string to hide it
        minSpotColor: '#ED7A53',//The CSS colour of the marker displayed for the mimum value. Set to false or an empty string to hide it
        spotRadius: 3,//Radius of all spot markers, In pixels (default: 1.5) - Integer
        lineWidth: 2//In pixels (default: 1) - Integer
    });

    //line red
    $("#spark-line-red").sparkline(data, {
        width: '100%',//Width of the chart - Defaults to 'auto' - May be any valid css width - 1.5em, 20px, etc (using a number without a unit specifier won't do what you want) - This option does nothing for bar and tristate chars (see barWidth)
        height: 30,//Height of the chart - Defaults to 'auto' (line height of the containing tag)
        lineColor: '#ed7a53',//Used by line and discrete charts to specify the colour of the line drawn as a CSS values string
        fillColor: '#ffd9cc',//Specify the colour used to fill the area under the graph as a CSS value. Set to false to disable fill
        spotColor: '#a12c04',//The CSS colour of the final value marker. Set to false or an empty string to hide it
        maxSpotColor: '#9FC569',//The CSS colour of the marker displayed for the maximum value. Set to false or an empty string to hide it
        minSpotColor: '#88bbc8',//The CSS colour of the marker displayed for the mimum value. Set to false or an empty string to hide it
        spotRadius: 3,//Radius of all spot markers, In pixels (default: 1.5) - Integer
        lineWidth: 2//In pixels (default: 1) - Integer
    });

    //line green
    $("#spark-line-green").sparkline(data, {
        width: '100%',//Width of the chart - Defaults to 'auto' - May be any valid css width - 1.5em, 20px, etc (using a number without a unit specifier won't do what you want) - This option does nothing for bar and tristate chars (see barWidth)
        height: 30,//Height of the chart - Defaults to 'auto' (line height of the containing tag)
        lineColor: '#9FC569',//Used by line and discrete charts to specify the colour of the line drawn as a CSS values string
        fillColor: '#daf9ad',//Specify the colour used to fill the area under the graph as a CSS value. Set to false to disable fill
        spotColor: '#558f02',//The CSS colour of the final value marker. Set to false or an empty string to hide it
        maxSpotColor: '#9FC569',//The CSS colour of the marker displayed for the maximum value. Set to false or an empty string to hide it
        minSpotColor: '#ED7A53',//The CSS colour of the marker displayed for the mimum value. Set to false or an empty string to hide it
        spotRadius: 3,//Radius of all spot markers, In pixels (default: 1.5) - Integer
        lineWidth: 2//In pixels (default: 1) - Integer
    });

    // Bar types
    //==========

    //bar default
    $("#spark-bar").sparkline([1+randNum(), 2+randNum(), 3+randNum(),4+randNum(),5+randNum(),6+randNum(),7+randNum(),8+randNum(),9+randNum(),10+randNum(),11+randNum(),12+randNum(),13+randNum(),14+randNum(),15+randNum() ], {
        height:'25px',
        spotRadius: 0,
        barColor: '#c4c4c4',
        type: 'bar'
    });

    //bar blue
    $("#spark-bar-blue").sparkline([1+randNum(), 2+randNum(), 3+randNum(),4+randNum(),5+randNum(),6+randNum(),7+randNum(),8+randNum(),9+randNum(),10+randNum(),11+randNum(),12+randNum(),13+randNum(),14+randNum(),15+randNum() ], {
        type: 'bar',
        width: '100%',
        height: '30px',
        barColor: '#88bbc8',
    });

    //bar red
    $("#spark-bar-red").sparkline([1+randNum(), 2+randNum(), 3+randNum(),4+randNum(),5+randNum(),6+randNum(),7+randNum(),8+randNum(),9+randNum(),10+randNum(),11+randNum(),12+randNum(),13+randNum(),14+randNum(),15+randNum() ], {
        type: 'bar',
        width: '100%',
        height: '30px',
        barColor: '#ed7a53',
    });

    //bar green
    $("#spark-bar-green").sparkline([1+randNum(), 2+randNum(), 3+randNum(),4+randNum(),5+randNum(),6+randNum(),7+randNum(),8+randNum(),9+randNum(),10+randNum(),11+randNum(),12+randNum(),13+randNum(),14+randNum(),15+randNum() ], {
        type: 'bar',
        width: '100%',
        height: '30px',
        barColor: '#9FC569',
    });


    //------------- Init Easy pie charts -------------//
    //pass the variables to pie chart init function
    //first is line width, size for pie, animated time.
    initPieChartPage(10,80,1500);


    //------------- Circular progrress bar (Knobs) -------------//
    $(function () {
        $(".greenCircle").knob({
            'min':0,
            'max':100,
            'readOnly': true,
            'width': 80,
            'height': 80,
            'fgColor': '#9FC569',
            'dynamicDraw': true,
            'thickness': 0.2,
            'tickColorizeValues': true
        })
        $(".redCircle").knob({
            'min':0,
            'max':100,
            'readOnly': true,
            'width': 80,
            'height': 80,
            'fgColor': '#ED7A53',
            'dynamicDraw': true,
            'thickness': 0.2,
            'tickColorizeValues': true
        })
        $(".blueCircle").knob({
            'min':0,
            'max':100,
            'readOnly': true,
            'width': 80,
            'height': 80,
            'fgColor': '#88BBC8',
            'dynamicDraw': true,
            'thickness': 0.2,
            'tickColorizeValues': true
        })
        $(".grayCircle").knob({
            'min':0,
            'max':100,
            'readOnly': true,
            'width': 80,
            'height': 80,
            'fgColor': '#c4c4c4',
            'dynamicDraw': true,
            'thickness': 0.2,
            'tickColorizeValues': true
        })
    });

    //------------- Gauge -------------//

    //default colors
    var gauge = new Gauge(document.getElementById('gauge')).setOptions({
        lines: 10, // The number of lines to draw
        angle: 0, // The length of each line
        lineWidth: 0.4, // The line thickness
        pointer: {
            length: 0.8, // The radius of the inner circle
            strokeWidth: 0.035, // The rotation offset
            color: '#c4c4c4' // Fill color
        },
        limitMax: true,   // If true, the pointer will not go past the end of the gauge
        colorStart: '#c4c4c4' ,   // Colors
        colorStop: '#c4c4c4' ,    // just experiment with them
        strokeColor: '#f3f3f3' ,   // to see which ones work best for you
        generateGradient: false 
    }); // create sexy gauge!
    gauge.maxValue = 100; // set max gauge value
    gauge.animationSpeed = 20; // set animation speed (32 is default value)
    gauge.set(35); // set actual value

    //red
    var gaugeRed = new Gauge(document.getElementById('gauge-red')).setOptions({
        lines: 10, // The number of lines to draw
        angle: 0, // The length of each line
        lineWidth: 0.4, // The line thickness
        pointer: {
            length: 0.8, // The radius of the inner circle
            strokeWidth: 0.035, // The rotation offset
            color: '#c4c4c4' // Fill color
        },
        limitMax: true,   // If true, the pointer will not go past the end of the gauge
        colorStart: '#ed7a53',   // Colors
        colorStop: '#ed7a53',    // just experiment with them
        strokeColor: '#f3f3f3',   // to see which ones work best for you
        generateGradient: false 
    }); // create sexy gauge!
    gaugeRed.maxValue = 100; // set max gauge value
    gaugeRed.animationSpeed = 20; // set animation speed (32 is default value)
    gaugeRed.set(45); // set actual value

    //blue
    var gaugeBlue = new Gauge(document.getElementById('gauge-blue')).setOptions({
        lines: 10, // The number of lines to draw
        angle: 0, // The length of each line
        lineWidth: 0.4, // The line thickness
        pointer: {
            length: 0.8, // The radius of the inner circle
            strokeWidth: 0.035, // The rotation offset
            color: '#c4c4c4' // Fill color
        },
        limitMax: true,   // If true, the pointer will not go past the end of the gauge
        colorStart: '#88bbc8',   // Colors
        colorStop: '#88bbc8',    // just experiment with them
        strokeColor: '#f3f3f3',   // to see which ones work best for you
        generateGradient: false 
    }); // create sexy gauge!
    gaugeBlue.maxValue = 100; // set max gauge value
    gaugeBlue.animationSpeed = 20; // set animation speed (32 is default value)
    gaugeBlue.set(55); // set actual value

    //green
    var gaugeGreen = new Gauge(document.getElementById('gauge-green')).setOptions({
        lines: 10, // The number of lines to draw
        angle: 0, // The length of each line
        lineWidth: 0.4, // The line thickness
        pointer: {
            length: 0.8, // The radius of the inner circle
            strokeWidth: 0.035, // The rotation offset
            color: '#c4c4c4'  // Fill color
        },
        limitMax: true,   // If true, the pointer will not go past the end of the gauge
        colorStart: '#9FC569' ,   // Colors
        colorStop: '#9FC569' ,    // just experiment with them
        strokeColor: '#f3f3f3' ,   // to see which ones work best for you
        generateGradient: false 
    }); // create sexy gauge!
    gaugeGreen.maxValue = 100; // set max gauge value
    gaugeGreen.animationSpeed = 20; // set animation speed (32 is default value)
    gaugeGreen.set(65); // set actual value

    //With percentage colors
    var gaugePercent = new Gauge(document.getElementById('gauge-percent')).setOptions({
        lines: 10, // The number of lines to draw
        angle: 0, // The length of each line
        lineWidth: 0.4, // The line thickness
        pointer: {
            length: 0.8, // The radius of the inner circle
            strokeWidth: 0.035, // The rotation offset
            color: '#c4c4c4'// Fill color
        },
        limitMax: true,   // If true, the pointer will not go past the end of the gauge
        strokeColor: '#f3f3f3',   // to see which ones work best for you
        percentColors: [[0.0, '#c4c4c4' ], [0.35, '#9FC569'], [0.55, '#88bbc8'], [1.0, '#ed7a53']],
        generateGradient: false 
    }); // create sexy gauge!
    gaugePercent.maxValue = 100; // set max gauge value
    gaugePercent.animationSpeed = 20; // set animation speed (32 is default value)
    gaugePercent.set(10); // set actual value

    //update gauges every 5 sec with random data
    setInterval(function() {
        gauge.set(Math.floor( Math.random()*(100-1+1)+1));
        gaugeBlue.set(Math.floor( Math.random()*(100-1+1)+1));
        gaugeRed.set(Math.floor( Math.random()*(100-1+1)+1));
        gaugeGreen.set(Math.floor( Math.random()*(100-1+1)+1));
        gaugePercent.set(Math.floor( Math.random()*(100-1+1)+1));
    }, 5000);
		
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

//Setup easy pie charts in page
var initPieChartPage = function(lineWidth, size, animateTime) {

    $(".easy-pie-chart").easyPieChart({
        barColor: '#c4c4c4',
        borderColor: '#c4c4c4',
        trackColor: '#f3f3f3',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
    $(".easy-pie-chart-red").easyPieChart({
        barColor: '#ed7a53',
        borderColor: '#ed7a53',
        trackColor: '#ffd9cc',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
    $(".easy-pie-chart-green").easyPieChart({
        barColor: '#9FC569',
        borderColor: '#9FC569',
        trackColor: '#daf9ad',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
    $(".easy-pie-chart-blue").easyPieChart({
        barColor: '#88bbc8',
        borderColor: '#88bbc8',
        trackColor: '#f2f7f9',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
    $(".easy-pie-chart-yellow").easyPieChart({
        barColor: '#FF8A00',
        borderColor: '#FF8A00',
        trackColor: '#f9cd99',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
}