//------------- charts-chartjs.js -------------//
$(document).ready(function() {

	//generate random number for charts
    randNum = function(){
        //return Math.floor(Math.random()*101);
        return (Math.floor( Math.random()* (1+40-20) ) ) + 20;
    }
    
    //------------- Line chart -------------//
    var lineData = {
        labels : ["January","February","March","April","May","June","July"],
        datasets : [
            {
                label: "PayPal",
                fillColor : "rgba(136,187,200,0.2)",
                strokeColor : "rgba(136,187,200,1)",
                pointColor : "rgba(136,187,200,1)",
                pointStrokeColor : "#fff",
                pointHighlightFill : "#fff",
                pointHighlightStroke : "rgba(136,187,200,1)",
                data : [3+randNum(),5+randNum(),8+randNum(),13+randNum(),17+randNum(),21+randNum(),23+randNum()]
            },
            {
                label: "Credit card",
                fillColor : "rgba(223,106,120,0.2)",
                strokeColor : "rgba(223,106,120,1)",
                pointColor : "rgba(223,106,120,1)",
                pointStrokeColor : "#fff",
                pointHighlightFill : "#fff",
                pointHighlightStroke : "rgba(223,106,120,1)",
                data : [randNum()-5,randNum()-2,randNum()-4,randNum()-1,randNum()-3,randNum()-2,randNum()-5]
            }
        ]

    }
    var ctx = document.getElementById("line-chartjs").getContext("2d");
    var myLineChart = new Chart(ctx).Line(lineData, {
        responsive: true,
        scaleShowGridLines : true,
        scaleGridLineColor : "#f3f3f3",
        scaleGridLineWidth : 0.2,
        bezierCurve : false,
        //points
        pointDot : false,
        datasetStroke : true,
        datasetStrokeWidth : 2,
        datasetFill : true,
        //animations
        animation: true,
        animationSteps: 60,
        animationEasing: "easeOutQuart",
        //scale
        showScale: true,
        scaleFontFamily: "'Open Sans'",
        scaleFontSize: 13,
        scaleFontStyle: "normal",
        scaleFontColor: "#333",
        //tooltips
        showTooltips: true,
        tooltipFillColor: "#344154",
        tooltipFontFamily: "'Open Sans'",
        tooltipFontSize: 13,
        tooltipFontColor: "#fff",
        tooltipYPadding: 8,
        tooltipXPadding: 10,
        tooltipCornerRadius: 2,
        tooltipTitleFontFamily: "'Open Sans'",
    });

    //------------- Line chart with dots -------------//
    var lineDotsData = {
        labels : ["January","February","March","April","May","June","July"],
        datasets : [
            {
                label: "PayPal",
                fillColor : "rgba(136,187,200,0.2)",
                strokeColor : "rgba(136,187,200,1)",
                pointColor : "rgba(136,187,200,1)",
                pointStrokeColor : "#fff",
                pointHighlightFill : "#fff",
                pointHighlightStroke : "rgba(136,187,200,1)",           
                data : [3+randNum(),5+randNum(),8+randNum(),13+randNum(),17+randNum(),21+randNum(),23+randNum()]
            },
            {
                label: "Credit card",
                fillColor : "rgba(223,106,120,0.2)",
                strokeColor : "rgba(223,106,120,1)",
                pointColor : "rgba(223,106,120,1)",
                pointStrokeColor : "#fff",
                pointHighlightFill : "#fff",
                pointHighlightStroke : "rgba(223,106,120,1)",    
                data : [randNum()-5,randNum()-2,randNum()-4,randNum()-1,randNum()-3,randNum()-2,randNum()-5]
            }
        ]

    }
    var ctxDots = document.getElementById("line-dots-chartjs").getContext("2d");
    var myLineDotsChart = new Chart(ctxDots).Line(lineDotsData, {
        responsive: true,
        scaleShowGridLines : true,
        scaleGridLineColor : "#f3f3f3",
        scaleGridLineWidth : 0.2,
        bezierCurve : false,
        bezierCurveTension : 0.4,
        //points
        pointDot : true,
        pointDotRadius : 4,
        pointDotStrokeWidth : 1,
        pointHitDetectionRadius : 20,
        datasetStroke : true,
        datasetStrokeWidth : 2,
        datasetFill : true,
        //animations
        animation: true,
        animationSteps: 60,
        animationEasing: "easeOutQuart",
        //scale
        showScale: true,
        scaleFontFamily: "'Open Sans'",
        scaleFontSize: 13,
        scaleFontStyle: "normal",
        scaleFontColor: "#333",
        //tooltips
        showTooltips: true,
        tooltipFillColor: "#344154",
        tooltipFontFamily: "'Open Sans'",
        tooltipFontSize: 13,
        tooltipFontColor: "#fff",
        tooltipYPadding: 8,
        tooltipXPadding: 10,
        tooltipCornerRadius: 2,
        tooltipTitleFontFamily: "'Open Sans'",
    });

    //------------- Line chart unfilled -------------//
    var lineData1 = {
        labels : ["January","February","March","April","May","June","July"],
        datasets : [
            {
                label: "PayPal",
                fillColor : "rgba(136,187,200,0.2)",
                strokeColor : "rgba(136,187,200,1)",
                pointColor : "rgba(136,187,200,1)",
                pointStrokeColor : "#fff",
                pointHighlightFill : "#a1a1a1",
                pointHighlightStroke : "#fff",
                data : [3+randNum(),5+randNum(),8+randNum(),13+randNum(),17+randNum(),21+randNum(),23+randNum()]
            },
            {
                label: "Credit card",
                fillColor : "rgba(223,106,120,0.2)",
                strokeColor : "rgba(223,106,120,1)",
                pointColor : "rgba(223,106,120,1)",
                pointStrokeColor : "#fff",
                pointHighlightFill : "#fff",
                pointHighlightStroke : "rgba(223,106,120,1)",
                data : [randNum()-5,randNum()-2,randNum()-4,randNum()-1,randNum()-3,randNum()-2,randNum()-5]
            }
        ]

    }
    var ctx1 = document.getElementById("line-unfilled-chartjs").getContext("2d");
    var myLineChart1 = new Chart(ctx1).Line(lineData1, {
        responsive: true,
        scaleShowGridLines : true,
        scaleGridLineColor : "#f3f3f3",
        scaleGridLineWidth : 0.2,
        bezierCurve : true,
        //points
        pointDot : false,
        datasetFill : false,
        //animations
        animation: true,
        animationSteps: 60,
        animationEasing: "easeOutQuart",
        //scale
        showScale: true,
        scaleFontFamily: "'Open Sans'",
        scaleFontSize: 13,
        scaleFontStyle: "normal",
        scaleFontColor: "#333",
        //tooltips
        showTooltips: true,
        tooltipFillColor: "#344154",
        tooltipFontFamily: "'Open Sans'",
        tooltipFontSize: 13,
        tooltipFontColor: "#fff",
        tooltipYPadding: 8,
        tooltipXPadding: 10,
        tooltipCornerRadius: 2,
        tooltipTitleFontFamily: "'Open Sans'",
    });

    //------------- Bar chart  -------------//
    var barChartData = {
        labels : ["January","February","March","April","May","June","July"],
        datasets : [
            {
                fillColor : "rgba(136,187,200,0.5)",
                strokeColor : "rgba(136,187,200,0.3)",
                highlightFill: "rgba(136,187,200,0.75)",
                highlightStroke: "rgba(136,187,200,1)",
                data : [3+randNum(),5+randNum(),8+randNum(),13+randNum(),17+randNum(),21+randNum(),23+randNum()]
            },
            {
                fillColor : "rgba(223,106,120,0.5)",
                strokeColor : "rgba(223,106,120,0.3)",
                highlightFill : "rgba(223,106,120,0.75)",
                highlightStroke : "rgba(223,106,120,1)",
                data : [randNum()-5,randNum()-2,randNum()-4,randNum()-1,randNum()-3,randNum()-2,randNum()-5]
            }
        ]
    }

    var ctxBar = document.getElementById("bar-chartjs").getContext("2d");
    myBar = new Chart(ctxBar).Bar(barChartData, {
        responsive : true,
        scaleShowGridLines : true,
        scaleGridLineColor : "#f3f3f3",
        scaleGridLineWidth : 0.2,
        //bar options
        barShowStroke : true,
        barStrokeWidth : 2,
        barValueSpacing : 5,
        barDatasetSpacing : 2,
        //animations
        animation: true,
        animationSteps: 60,
        animationEasing: "easeOutQuart",
        //scale
        showScale: true,
        scaleFontFamily: "'Open Sans'",
        scaleFontSize: 13,
        scaleFontStyle: "normal",
        scaleFontColor: "#333",
        scaleBeginAtZero : true,
        //tooltips
        showTooltips: true,
        tooltipFillColor: "#344154",
        tooltipFontFamily: "'Open Sans'",
        tooltipFontSize: 13,
        tooltipFontColor: "#fff",
        tooltipYPadding: 8,
        tooltipXPadding: 10,
        tooltipCornerRadius: 2,
        tooltipTitleFontFamily: "'Open Sans'",
    });

    //------------- Pie chart  -------------//
    var pieData = [
        {
            value: 300,
            color:"#88bbc8",
            highlight: "#db5565",
            label: "SEO"
        },
        {
            value: 50,
            color: "#ed7a53",
            highlight: "#0bacd3",
            label: "Coding"
        },
        {
            value: 100,
            color: "#9FC569",
            highlight: "#51bf87",
            label: "Hosting"
        },
        {
            value: 40,
            color: "#bbdce3",
            highlight: "#f4ad49",
            label: "Design"
        },
        {
            value: 120,
            color: "#9a3b1b",
            highlight: "#262d37",
            label: "Other"
        }

    ];

    var ctxPie = document.getElementById("pie-chartjs").getContext("2d");
    myPie = new Chart(ctxPie).Pie(pieData, {
        responsive : true,
        //pie options
        segmentShowStroke : true,
        segmentStrokeColor : "#fff",
        segmentStrokeWidth : 2,
        percentageInnerCutout : 0, // This is 0 for Pie charts
        //animations
        animation: true,
        animationSteps: 100,
        animationEasing: "easeOutBounce",
        animateRotate : true,
        animateScale : false,
        //tooltips
        showTooltips: true,
        tooltipFillColor: "#344154",
        tooltipFontFamily: "'Open Sans'",
        tooltipFontSize: 13,
        tooltipFontColor: "#fff",
        tooltipYPadding: 8,
        tooltipXPadding: 10,
        tooltipCornerRadius: 2,
        tooltipTitleFontFamily: "'Open Sans'",
    });

    //------------- Donut chart  -------------//
    var donutData = [
        {
            value: 300,
            color:"#88bbc8",
            highlight: "#db5565",
            label: "SEO"
        },
        {
            value: 50,
            color: "#ed7a53",
            highlight: "#0bacd3",
            label: "Coding"
        },
        {
            value: 100,
            color: "#9FC569",
            highlight: "#51bf87",
            label: "Hosting"
        },
        {
            value: 40,
            color: "#bbdce3",
            highlight: "#f4ad49",
            label: "Design"
        },
        {
            value: 120,
            color: "#9a3b1b",
            highlight: "#262d37",
            label: "Other"
        }

    ];

    var ctxDonut = document.getElementById("donut-chartjs").getContext("2d");
    myDonut = new Chart(ctxDonut).Doughnut(donutData, {
        responsive : true,
        //donut options
        segmentShowStroke : true,
        segmentStrokeColor : "#fff",
        segmentStrokeWidth : 2,
        percentageInnerCutout : 45, // This is 0 for Pie charts
        //animations
        animation: true,
        animationSteps: 100,
        animationEasing: "easeOutBounce",
        animateRotate : true,
        animateScale : true,
        //tooltips
        showTooltips: true,
        tooltipFillColor: "#344154",
        tooltipFontFamily: "'Open Sans'",
        tooltipFontSize: 13,
        tooltipFontColor: "#fff",
        tooltipYPadding: 8,
        tooltipXPadding: 10,
        tooltipCornerRadius: 2,
        tooltipTitleFontFamily: "'Open Sans'",
    });

    //------------- Radar chart -------------//
    var radarChartData = {
        labels: ["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],
        datasets: [
            {
                label: "My First dataset",
                fillColor: "rgba(136,187,200,0.2)",
                strokeColor: "rgba(136,187,200,1)",
                pointColor: "rgba(136,187,200,1)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(136,187,200,1)",
                data: [65,59,90,81,56,55,40]
            },
            {
                label: "My Second dataset",
                fillColor: "rgba(223,106,120,0.2)",
                strokeColor: "rgba(223,106,120,1)",
                pointColor: "rgba(223,106,120,1)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(223,106,120,1)",
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
        pointLabelFontFamily : "'Open Sans'",
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
        tooltipFontFamily: "'Open Sans'",
        tooltipFontSize: 13,
        tooltipFontColor: "#fff",
        tooltipYPadding: 8,
        tooltipXPadding: 10,
        tooltipCornerRadius: 2,
        tooltipTitleFontFamily: "'Open Sans'",
    });

    //------------- Polar area -------------//  
    var polarData = [
        {
            value: 300,
            color:"#88bbc8",
            highlight: "#db5565",
            label: "SEO"
        },
        {
            value: 50,
            color: "#ed7a53",
            highlight: "#0bacd3",
            label: "Coding"
        },
        {
            value: 100,
            color: "#9FC569",
            highlight: "#51bf87",
            label: "Hosting"
        },
        {
            value: 40,
            color: "#bbdce3",
            highlight: "#f4ad49",
            label: "Design"
        },
        {
            value: 120,
            color: "#9a3b1b",
            highlight: "#262d37",
            label: "Other"
        }

    ];

    var ctxPolar = document.getElementById("polar-chartjs").getContext("2d");
    myPolarArea = new Chart(ctxPolar).PolarArea(polarData, {
        responsive:true,
        //animations
        animation: true,
        animationSteps: 100,
        animationEasing: "easeOutBounce",
        animateRotate : true,
        animateScale : false,
        //tooltips
        showTooltips: true,
        tooltipFillColor: "#344154",
        tooltipFontFamily: "'Open Sans'",
        tooltipFontSize: 13,
        tooltipFontColor: "#fff",
        tooltipYPadding: 8,
        tooltipXPadding: 10,
        tooltipCornerRadius: 2,
        tooltipTitleFontFamily: "'Open Sans'",
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