//------------- dashboard.js -------------//
$(document).ready(function() {

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
    });

    //generate random number for charts
    randNum = function(){
        //return Math.floor(Math.random()*101);
        return (Math.floor( Math.random()* (1+40-20) ) ) + 20;
    }

    var chartColours = ['#88bbc8', '#ed7a53', '#9FC569', '#bbdce3', '#9a3b1b', '#5a8022', '#2c7282'];

    //------------- Visitors chart -------------//
    $(function () {

        //some data
        var d1 = [[1, 3+randNum()], [2, 6+randNum()], [3, 9+randNum()], [4, 12+randNum()],[5, 15+randNum()],[6, 18+randNum()],[7, 21+randNum()],[8, 15+randNum()],[9, 18+randNum()],[10, 21+randNum()],[11, 24+randNum()],[12, 27+randNum()],[13, 30+randNum()],[14, 33+randNum()],[15, 24+randNum()],[16, 27+randNum()],[17, 30+randNum()],[18, 33+randNum()],[19, 36+randNum()],[20, 39+randNum()],[21, 42+randNum()],[22, 45+randNum()],[23, 36+randNum()],[24, 39+randNum()],[25, 42+randNum()],[26, 45+randNum()],[27,38+randNum()],[28, 51+randNum()],[29, 55+randNum()], [30, 60+randNum()]];
        var d2 = [[1, randNum()-5], [2, randNum()-4], [3, randNum()-4], [4, randNum()],[5, 4+randNum()],[6, 4+randNum()],[7, 5+randNum()],[8, 5+randNum()],[9, 6+randNum()],[10, 6+randNum()],[11, 6+randNum()],[12, 2+randNum()],[13, 3+randNum()],[14, 4+randNum()],[15, 4+randNum()],[16, 4+randNum()],[17, 5+randNum()],[18, 5+randNum()],[19, 2+randNum()],[20, 2+randNum()],[21, 3+randNum()],[22, 3+randNum()],[23, 3+randNum()],[24, 2+randNum()],[25, 4+randNum()],[26, 4+randNum()],[27,5+randNum()],[28, 2+randNum()],[29, 2+randNum()], [30, 3+randNum()]];
        //define placeholder class
        var placeholder = $(".visitors-chart");
        //graph options
        var options = {
            grid: {
                show: true,
                aboveData: true,
                color: "#3f3f3f" ,
                labelMargin: 5,
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
                grow: {
                    active: false,
                    stepMode: "linear",
                    steps: 50,
                    stepDelay: true
                },
                lines: {
                    show: true,
                    fill: true,
                    lineWidth: 4,
                    steps: false
                    },
                points: {
                    show:true,
                    radius: 5,
                    symbol: "circle",
                    fill: true,
                    borderColor: "#fff"
                }
            },
            legend: { 
                position: "ne", 
                margin: [0,-25], 
                noColumns: 0,
                labelBoxBorderColor: null,
                labelFormatter: function(label, series) {
                    // just add some space to labes
                    return label+'&nbsp;&nbsp;';
                 }
            },
            yaxis: { min: 0 },
            xaxis: {ticks:11, tickDecimals: 0},
            colors: chartColours,
            shadowSize:1,
            tooltip: true, //activate tooltip
            tooltipOpts: {
                content: "%s : %y.0",
                shifts: {
                    x: -30,
                    y: -50
                }
            }
        };   

        $.plot(placeholder, [ 

            {
                label: "Visits", 
                data: d1,
                lines: {fillColor: "#f2f7f9"},
                points: {fillColor: "#88bbc8"}
            }, 
            {   
                label: "Unique Visits", 
                data: d2,
                lines: {fillColor: "#fff8f2"},
                points: {fillColor: "#ed7a53"}
            } 

        ], options);

    });

    
    //------------- Sparkstats -------------//
    //sparklines (making loop with random data for all 7 sparkline)
    i=1;
    for (i=1; i<8; i++) {
        var data = [[1, 3+randNum()], [2, 5+randNum()], [3, 8+randNum()], [4, 11+randNum()],[5, 14+randNum()],[6, 17+randNum()],[7, 20+randNum()], [8, 15+randNum()], [9, 18+randNum()], [10, 22+randNum()]];
        placeholder = '.sparkLine' + i;
        $(placeholder).sparkline(data, { 
            width: 100,//Width of the chart - Defaults to 'auto' - May be any valid css width - 1.5em, 20px, etc (using a number without a unit specifier won't do what you want) - This option does nothing for bar and tristate chars (see barWidth)
            height: 30,//Height of the chart - Defaults to 'auto' (line height of the containing tag)
            lineColor: '#88bbc8',//Used by line and discrete charts to specify the colour of the line drawn as a CSS values string
            fillColor: '#f2f7f9',//Specify the colour used to fill the area under the graph as a CSS value. Set to false to disable fill
            spotColor: '#467e8c',//The CSS colour of the final value marker. Set to false or an empty string to hide it
            maxSpotColor: '#9FC569',//The CSS colour of the marker displayed for the maximum value. Set to false or an empty string to hide it
            minSpotColor: '#ED7A53',//The CSS colour of the marker displayed for the mimum value. Set to false or an empty string to hide it
            spotRadius: 3,//Radius of all spot markers, In pixels (default: 1.5) - Integer
            lineWidth: 2//In pixels (default: 1) - Integer
        });
    }

    //------------- Pie stats -------------//
    $(function () {
       var data = [
            { label: "%78.75 New Visitor",  data: 78.75, color: "#88bbc8"},
            { label: "%21.25 Returning Visitor",  data: 21.25, color: "#ed7a53"}
        ];
        
        $.plot($(".pieStats"), data, 
        {
            series: {
                pie: { 
                    show: true,
                    highlight: {
                        opacity: 0.1
                    },
                    stroke: {
                        color: '#fff',
                        width: 3
                    },
                    startAngle: 2,
                    label: {
                        radius:1
                    }
                },
                grow: { active: false}
            },
            legend: { 
                position: "ne", 
                labelBoxBorderColor: null
            },
            grid: {
                hoverable: true,
                clickable: true
            },
            tooltip: true, //activate tooltip
            tooltipOpts: {
                content: "%s : %y.1",
                shifts: {
                    x: -30,
                    y: -50
                }
            }
        });
    });

    //------------- Animated progress bars -------------//
    //animate bar only when reach the bottom of screen
    $('.animated-bar .progress-bar').waypoint(function(direction) {
        $(this).progressbar({display_text: 'fill'});
    }, { offset: 'bottom-in-view' });

    //------------- Autosize Text area -------------//
    $('.elastic').autosize();

    //------------- Add sortable function to todo widget -------------//
    $(function() {
        $( "#today, #tomorrow" ).sortable({
            connectWith: ".todo-list",
            placeholder: 'placeholder',  
            forcePlaceholderSize: true, 
        }).disableSelection();
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