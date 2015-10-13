//------------- sliders.js -------------//
$(document).ready(function() {

	//------------- Bootstrap slider -------------//
    //Basic sliders
    $("#slider").bootstrapSlider({
        min: 0,
        max: 200,
        value: 60
    });

    //Primary color slider
    $("#slider-primary").bootstrapSlider({
        id: 'slider-primary',
        min:0,
        max: 200,
        value: 70
    });

    //info color slider
    $("#slider-info").bootstrapSlider({
        id: 'slider-info',
        min:0,
        max: 200,
        value: 80
    });

    //success color slider
    $("#slider-success").bootstrapSlider({
        id: 'slider-success',
        min:0,
        max: 200,
        value: 90
    });

    //danger color slider
    $("#slider-danger").bootstrapSlider({
        id: 'slider-danger',
        min:0,
        max: 200,
        value: 100
    });

    //warning color slider
    $("#slider-warning").bootstrapSlider({
        id: 'slider-warning',
        min:0,
        max: 200,
        value: 110
    });

    //range sliders
    $("#slider-range").bootstrapSlider({
        range: true,
        min: 0,
        max: 200,
        value: [40,160]
    }); 

    $("#slider-range-primary").bootstrapSlider({
        id: 'slider-primary',
        range: true,
        min: 0,
        max: 200,
        value: [50,150]
    }); 

    $("#slider-range-info").bootstrapSlider({
        id: 'slider-info',
        range: true,
        min: 0,
        max: 200,
        value: [60,140]
    });

    $("#slider-range-danger").bootstrapSlider({
        id: 'slider-danger',
        range: true,
        min: 0,
        max: 200,
        value: [70,130]
    });

    $("#slider-range-success").bootstrapSlider({
        id: 'slider-success',
        range: true,
        min: 0,
        max: 200,
        value: [80,120]
    });

    $("#slider-range-warning").bootstrapSlider({
        id: 'slider-warning',
        range: true,
        min: 0,
        max: 200,
        value: [90,110]
    });

    //Min value sliders
    $("#slider-minval").bootstrapSlider({
        min: 100,
        max: 200,
        value: 150
    });

    //Max value 100
    $("#slider-maxval").bootstrapSlider({
        min: 0,
        max: 100,
        value: 60
    });

    //custom step
    $("#slider-step").bootstrapSlider({
        id: 'slider-success',
        step: 10,
        max: 200,
        value: 60
    });

    $("#slider-show-val").bootstrapSlider({
        id: 'slider-danger',
        max: 200,
        value: 10,
        step: 10
    });
    $("#slider-show-val").on("slide", function(slideEvt) {
        $("#sum").text('$ ' + slideEvt.value);
    });

    //Vertical slider
    $("#vertical-slider").bootstrapSlider({
        orientation: 'vertical',
        reversed : true,
        min: 0,
        max: 200,
        value: 60
    });
    $("#vertical-slider1").bootstrapSlider({
        id: 'slider-primary',
        orientation: 'vertical',
        reversed : true,
        min: 0,
        max: 200,
        value: 70
    });
    $("#vertical-slider2").bootstrapSlider({
        id: 'slider-info',
        orientation: 'vertical',
        reversed : true,
        min: 0,
        max: 200,
        value: 80
    });
    $("#vertical-slider3").bootstrapSlider({
        id: 'slider-danger',
        orientation: 'vertical',
        reversed : true,
        min: 0,
        max: 200,
        value: 90
    });
    $("#vertical-slider4").bootstrapSlider({
        id: 'slider-success',
        orientation: 'vertical',
        reversed : true,
        min: 0,
        max: 200,
        value: 100
    });
    $("#vertical-slider5").bootstrapSlider({
        id: 'slider-warning',
        orientation: 'vertical',
        reversed : true,
        min: 0,
        max: 200,
        value: 110
    });

    //Vertical range slider
    $("#vertical-range-slider").bootstrapSlider({
        orientation: 'vertical',
        range: true,
        min: 0,
        max: 200,
        value: [40,160]
    });

    $("#vertical-range-slider1").bootstrapSlider({
        id: 'slider-primary',
        orientation: 'vertical',
        range: true,
        min: 0,
        max: 200,
        value: [50,150]
    });

    $("#vertical-range-slider2").bootstrapSlider({
        id: 'slider-info',
        orientation: 'vertical',
        range: true,
        min: 0,
        max: 200,
        value: [60,140]
    });

    $("#vertical-range-slider3").bootstrapSlider({
        id: 'slider-danger',
        orientation: 'vertical',
        range: true,
        min: 0,
        max: 200,
        value: [70,130]
    });

    $("#vertical-range-slider4").bootstrapSlider({
        id: 'slider-success',
        orientation: 'vertical',
        range: true,
        min: 0,
        max: 200,
        value: [80,120]
    });

    $("#vertical-range-slider5").bootstrapSlider({
        id: 'slider-warning',
        orientation: 'vertical',
        range: true,
        min: 0,
        max: 200,
        value: [90,110]
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