//------------- profile.js -------------//
$(document).ready(function() {

	//------------- Profile page -------------//
    //activate profile tab
    $('#profileTab a:first').tab('show'); // Select first tab

    //------------- Animated progress bars -------------//
    //animate bar only when reach the bottom of screen
    $('.animated-bar .progress-bar').waypoint(function(direction) {
        $(this).progressbar({display_text: 'fill'});
    }, { offset: 'bottom-in-view' })


    //define chart colours first
    var chartColours = {
        gray: '#a2aaac',
        teal: '#43aea8',
        blue: '#4faede',
        red: '#ec8765',
        orange: '#FF8A00',
        gray_lighter: '#f3f3f3',
        gray_light: '#777777',
        gridColor: '#bfbfbf'
    }

    //convert the object to array for flot use
    var chartColoursArr = Object.keys(chartColours).map(function (key) {return chartColours[key]});

    /* ------------------ Users purchases line chart --------------------*/
    $(function () {
        //declare the data
        var d1 = [];
        //here we add data for chart

        var d1 = [
            [new Date(Date.today().add(0).days()), 17],
            [new Date(Date.today().add(1).days()), 34],
            [new Date(Date.today().add(2).days()), 56],
            [new Date(Date.today().add(3).days()), 12],
            [new Date(Date.today().add(4).days()), 20],
            [new Date(Date.today().add(5).days()), 5],
            [new Date(Date.today().add(6).days()), 6]
        ];

        var chartMinDate = d1[0][0]; //first day
        var chartMaxDate = d1[6][0];//last day

        var tickSize = [1, "day"];
        var tformat = "%a";

        var options = {
            grid: {
                show: true,
                aboveData: true,
                color: chartColours.gridColor,
                labelMargin: 15,
                axisMargin: 0, 
                borderWidth: 0,
                borderColor:null,
                minBorderMargin: 5 ,
                clickable: true, 
                hoverable: true,
                autoHighlight: true,
                mouseActiveRadius: 20
            },
            series: {
                grow: {active:false},
                lines: {
                    show: true,
                    fill: true,
                    lineWidth: 2,
                    steps: false
                    },
                points: {show:false}
            },
            legend: { 
                position: "ne", 
                margin: [0,-25], 
                noColumns: 0,
                labelBoxBorderColor: null,
                labelFormatter: function(label, series) {
                    // just add some space to labes
                    return '&nbsp;&nbsp;' + label + ' &nbsp;&nbsp;';
                },
                width: 30,
                height: 2
            },
            yaxis: { min: 0, tickSize: 10},
            xaxis: {
                mode: "time",
                minTickSize: tickSize,
                timeformat: tformat,
                min: chartMinDate,
                max: chartMaxDate,
                tickLength: 0
            },
            colors: chartColoursArr,
            shadowSize:1,
            tooltip: true, //activate tooltip
            tooltipOpts: {
                content: "%s : %y.0" + " $",
                shifts: {
                    x: -30,
                    y: -50
                }
            }
        };   

        $.plot($("#user-purchase-chart"), [ 

            {
                label: "Purchases", 
                data: d1,
                lines: {fillColor: chartColours.gray_lighter},
                points: {fillColor: chartColours.gray}
            }

        ], options);

    });

    //------------- Donut chart purchase -------------//
    Morris.Donut({
        element: 'morris-donut',
        data: [
            {value: 45, label: 'Clothes'},
            {value: 25, label: 'Shoes'},
            {value: 20, label: 'Jackets'},
            {value: 10, label: 'Other'}
        ],
        formatter: function (x) { return x + "%"},
        colors: chartColoursArr,
        resize: true
    });

    //------------- Radar chart -------------//
    var radarChartData = {
        labels: ["Shirts", "Pants", "Vests", "Boots", "Sandals", "Watches", "Belts"],
        datasets: [
            {
                label: "My First dataset",
                fillColor: "rgba(186,195,210,0.2)",
                strokeColor: "rgba(186,195,210,1)",
                pointColor: "rgba(186,195,210,1)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(186,195,210,1)",
                data: [65,59,90,81,56,55,40]
            },
            {
                label: "My Second dataset",
                fillColor: "rgba(96,177,204,0.2)",
                strokeColor: "rgba(96,177,204,1)",
                pointColor: "rgba(96,177,204,1)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(96,177,204,1)",
                data: [28,48,40,19,96,27,100]
            }
        ]
    };

    myRadar = new Chart(document.getElementById("radar-chartjs").getContext("2d")).Radar(radarChartData, {
        responsive: true,
        //radar options
        scaleShowLine : true,
        angleShowLineOut : true,
        scaleShowLabels : false,
        angleLineColor : "rgba(0,0,0,.0.5)",
        angleLineWidth : 1,
        pointDotRadius : 3,
        pointDotStrokeWidth : 1,
        //points
        pointLabelFontFamily : "'Roboto'",
        pointDot : true,
        //animations
        animation: true,
        animationSteps: 100,
        animationEasing: "easeOutBounce",
        animateRotate : true,
        animateScale : true,
        //tooltips
        showTooltips: true,
        tooltipFillColor: "#344154",
        tooltipFontFamily: "'Roboto'",
        tooltipFontSize: 13,
        tooltipFontColor: "#fff",
        tooltipYPadding: 8,
        tooltipXPadding: 10,
        tooltipCornerRadius: 2,
        tooltipTitleFontFamily: "'Roboto'",
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