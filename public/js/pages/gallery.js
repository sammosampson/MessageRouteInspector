//------------- gallery.js -------------//
$(document).ready(function() {

    //------------- Gallery example functions -------------//

    //check all checkboxes
    $('#checkAll-active').checkAll({
        masterCheckbox: '.check-all',
        otherCheckboxes: '.check',
        highlightElement: {
            active: true,
            elementClass: '.panel',
            highlightClass: 'highlight-panel'
        }
    })

    //update edit image modal
    $('#edit-image').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var panel = button.closest('.panel');
        var imageName = panel.find('.panel-title').text();
        var image = panel.find('img').attr("src");
        var modal = $(this)
        modal.find('.modal-title').text(imageName);
        modal.find('img').attr("src", image);
        //center modal via method
        $('body').data('supr').centerModal();   
    });

    //delete image
    $('.delete-image').click(function(e) {
        var panel = $(this).closest('.panel');
        bootbox.confirm({
            message: "Delete image",
            title: "Are you sure ?",
            className: "modal-style2",
            callback: function(result) {
                if (result) {
                    panel.remove();
                }
            }
        }); 
        //center modal via method
        $('body').data('supr').centerModal();                  
    });
	
});

$(document).delegate('*[data-toggle="lightbox"]', 'click', function(event) {
    event.preventDefault();
    $(this).ekkoLightbox();
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