//------------- modals.js -------------//
$(document).ready(function() {

    //------------- Bootbox modals -------------//
    //Alert modal
    $('#alert-modal').click(function() {
        bootbox.dialog({
            message: "This is custom alert",
            title: "Alert!!!",
            buttons: {
                success: {
                  label: "Ok i got it",
                  className: "btn-primary btn-alt",
                  callback: function() {
                    //callback result
                  }
                }
            }
        });
    });

    //Confirm modal
    $('#confirm-modal').click(function() {
        bootbox.confirm({
            message: "Confirm results:",
            title: "Are you sure ?",
            callback: function(result) {
                //callback result
                alert(result);
            }
        });
    });

    //Prompt modal
    $('#prompt-modal').click(function() {
        bootbox.prompt({
            title: "What is your name ?",
            callback: function(result) {
                //callback result
                alert(result);
            }
        });
    });

    //------------- Modals -------------//
    $('#remote-modal').click(function(){
        $('#ajax-modal').modal({
            show:true,
            remote: 'ajax/remoteModal.html'
        });
    });

    //------------- Autoplay video -------------//
    function autoPlayYouTubeModal(){
      var trigger = $("body").find('[data-toggle="modal"]');
      trigger.click(function() {
        var theModal = $(this).data( "target" ),
        videoSRC = $(this).attr( "data-theVideo" ), 
        videoSRCauto = videoSRC+"?autoplay=1" ;
        $(theModal+' iframe').attr('src', videoSRCauto);
        $(theModal+' button.close').click(function () {
            $(theModal+' iframe').attr('src', videoSRC);
        });   
      });
    }
    autoPlayYouTubeModal();
	
	
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