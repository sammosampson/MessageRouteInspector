//------------- charts-rickshaw.js -------------//
$(document).ready(function() {

    //some colors for chart
    var chartColours = ['#88bbc8', '#ed7a53', '#9FC569', '#bbdce3', '#9a3b1b', '#5a8022', '#2c7282'];

    //generate random number for charts
    randNum = function(){
        //return Math.floor(Math.random()*101);
        return (Math.floor( Math.random()* (1+40-20) ) ) + 20;
    }

    //------------- Rickshaw charts -------------//

    //line Chart
    //some random data
    var data = [ { x: 0, y: 5+randNum() }, { x: 1, y: 10+randNum() }, { x: 2, y: 15+randNum() }, { x: 3, y: 20+randNum() }, { x: 4, y: 25+randNum()}, { x: 5, y: 30+randNum() }, { x: 6, y: 30+randNum() }, { x: 7, y: 20+randNum() }, { x: 8, y: 30+randNum() }, { x: 9, y: 35+randNum() }];

    var data1 = [ { x: 0, y: randNum() }, { x: 1, y: 1+randNum() }, { x: 2, y: 2+randNum() }, { x: 3, y: 3+randNum() }, { x: 4, y: 4+randNum()}, { x: 5, y: 5+randNum() }, { x: 6, y: 6+randNum() }, { x: 7, y: 7+randNum() }, { x: 8, y: 8+randNum() }, { x: 9, y: 9+randNum() }];

    var selector = document.querySelector("#line-chart");
    var yaxis = 21; // yaxis width
    var chart = new Rickshaw.Graph( {
        element: selector,
        width: selector.offsetWidth-yaxis,
        height: 230,
        renderer: 'line',
        padding: { top: 0.1 },
        series: [
            {
                color: '#88bbc8',
                name: 'Credit Card',
                data: data
            },
            {
                color: '#ed7a53',
                name: 'Pay Pal',
                data: data1
            },
        ]
    });

    var hoverDetail = new Rickshaw.Graph.HoverDetail({
        graph: chart
    });

    //X Axis
    var xAxis =  new Rickshaw.Graph.Axis.X({
        graph: chart,
        orientation: 'bottom',
        element: document.getElementById('x_axis')
    });

    //Y Axis
    var yAxis = new Rickshaw.Graph.Axis.Y({
        graph: chart,
        orientation: 'left',
        element: document.getElementById('y_axis')
    });
    //render chart and axis elements
    xAxis.render();
    yAxis.render();
    chart.render();

    //------------- Line charts with dots (lineplot) -------------//
    //some random data
    var data = [ { x: 0, y: 5+randNum() }, { x: 1, y: 10+randNum() }, { x: 2, y: 15+randNum() }, { x: 3, y: 20+randNum() }, { x: 4, y: 25+randNum()}, { x: 5, y: 30+randNum() }, { x: 6, y: 30+randNum() }, { x: 7, y: 20+randNum() }, { x: 8, y: 30+randNum() }, { x: 9, y: 35+randNum() }];

    var data1 = [ { x: 0, y: randNum() }, { x: 1, y: 1+randNum() }, { x: 2, y: 2+randNum() }, { x: 3, y: 3+randNum() }, { x: 4, y: 4+randNum()}, { x: 5, y: 5+randNum() }, { x: 6, y: 6+randNum() }, { x: 7, y: 7+randNum() }, { x: 8, y: 8+randNum() }, { x: 9, y: 9+randNum() }];

    var selector = document.querySelector("#line-chart-dots");
    var yaxis = 21; // yaxis width
    var chart1 = new Rickshaw.Graph( {
        element: selector,
        width: selector.offsetWidth-yaxis,
        height: 230,
        renderer: 'lineplot',
        fill: false,
        stroke: true,
        dotSize: 3,
        strokeWidth: 2,
        padding: { top: 0.1 },
        series: [
            {
                color: '#88bbc8',
                name: 'Credit Card',
                data: data
            },
            {
                color: '#ed7a53',
                name: 'Pay Pal',
                data: data1
            },
        ]
    });

    var hoverDetail1 = new Rickshaw.Graph.HoverDetail({
        graph: chart1
    });

    //X Axis
    var xAxis1 =  new Rickshaw.Graph.Axis.X({
        graph: chart1,
        orientation: 'bottom',
        element: document.getElementById('x_axis1')
    });

    //Y Axis
    var yAxis1 = new Rickshaw.Graph.Axis.Y({
        graph: chart1,
        orientation: 'left',
        element: document.getElementById('y_axis1')
    });
    //render chart and axis elements
    xAxis1.render();
    yAxis1.render();
    chart1.render();

    //------------- Area chart -------------//
    //some random data
    var data = [ { x: 0, y: 5+randNum() }, { x: 1, y: 10+randNum() }, { x: 2, y: 15+randNum() }, { x: 3, y: 20+randNum() }, { x: 4, y: 25+randNum()}, { x: 5, y: 30+randNum() }, { x: 6, y: 30+randNum() }, { x: 7, y: 20+randNum() }, { x: 8, y: 30+randNum() }, { x: 9, y: 35+randNum() }];

    var data1 = [ { x: 0, y: randNum() }, { x: 1, y: 1+randNum() }, { x: 2, y: 2+randNum() }, { x: 3, y: 3+randNum() }, { x: 4, y: 4+randNum()}, { x: 5, y: 5+randNum() }, { x: 6, y: 6+randNum() }, { x: 7, y: 7+randNum() }, { x: 8, y: 8+randNum() }, { x: 9, y: 9+randNum() }];

    var selector = document.querySelector("#area-chart");
    var yaxis = 21; // yaxis width
    var chart2 = new Rickshaw.Graph( {
        element: selector,
        width: selector.offsetWidth-yaxis,
        height: 230,
        renderer: 'area',
        padding: { top: 0.1 },
        series: [
            {
                color: 'rgba(136,187,200,0.6)',
                stroke: 'rgba(136,187,200,1)',
                name: 'Credit Card',
                data: data
            },
            {
                color: 'rgba(237,122,83,0.6)',
                stroke: 'rgba(237,122,83,1)',
                name: 'Pay Pal',
                data: data1
            },
        ]
    });

    var hoverDetail2 = new Rickshaw.Graph.HoverDetail({
        graph: chart2
    });

    //X Axis
    var xAxis2 =  new Rickshaw.Graph.Axis.X({
        graph: chart2,
        orientation: 'bottom',
        element: document.getElementById('x_axis2')
    });

    //Y Axis
    var yAxis2 = new Rickshaw.Graph.Axis.Y({
        graph: chart2,
        orientation: 'left',
        element: document.getElementById('y_axis2')
    });
    //render chart and axis elements
    xAxis2.render();
    yAxis2.render();
    chart2.renderer.unstack = true;
    chart2.render();

    //------------- Bars chart -------------//
    //some random data
    var data = [ { x: 0, y: 5+randNum() }, { x: 1, y: 10+randNum() }, { x: 2, y: 15+randNum() }, { x: 3, y: 20+randNum() }, { x: 4, y: 25+randNum()}, { x: 5, y: 30+randNum() }, { x: 6, y: 30+randNum() }, { x: 7, y: 20+randNum() }, { x: 8, y: 30+randNum() }, { x: 9, y: 35+randNum() }];

    var data1 = [ { x: 0, y: randNum() }, { x: 1, y: 1+randNum() }, { x: 2, y: 2+randNum() }, { x: 3, y: 3+randNum() }, { x: 4, y: 4+randNum()}, { x: 5, y: 5+randNum() }, { x: 6, y: 6+randNum() }, { x: 7, y: 7+randNum() }, { x: 8, y: 8+randNum() }, { x: 9, y: 9+randNum() }];

    var selector = document.querySelector("#bars-chart");
    var yaxis = 21; // yaxis width
    var chart3 = new Rickshaw.Graph( {
        element: selector,
        width: selector.offsetWidth-yaxis,
        height: 230,
        renderer: 'bar',
        stack: false,
        padding: { top: 0.1 },
        series: [
            {
                color: '#88bbc8',
                name: 'Credit Card',
                data: data
            },
            {
                color: '#ed7a53',
                name: 'Pay Pal',
                data: data1
            },
        ]
    });

    var hoverDetail3 = new Rickshaw.Graph.HoverDetail({
        graph: chart3
    });

    //X Axis
    var xAxis3 =  new Rickshaw.Graph.Axis.X({
        graph: chart3,
        orientation: 'bottom',
        element: document.getElementById('x_axis3')
    });

    //Y Axis
    var yAxis3 = new Rickshaw.Graph.Axis.Y({
        graph: chart3,
        orientation: 'left',
        element: document.getElementById('y_axis3')
    });
    //render chart and axis elements
    xAxis3.render();
    yAxis3.render();
    chart3.render();

    $(window).resize(function() {
        //resize function for line chart
        chart.configure({width: selector.offsetWidth-yaxis});
        chart.update();
        //resize function for line-chart-dots
        chart1.configure({width: selector.offsetWidth-yaxis});
        chart1.update();
        //resize function for area-chart
        chart2.configure({width: selector.offsetWidth-yaxis});
        chart2.update();
        //resize function for bar chart
        chart3.configure({width: selector.offsetWidth-yaxis});
        chart3.update();
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