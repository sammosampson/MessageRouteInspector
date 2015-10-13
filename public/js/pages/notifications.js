//------------- notifications.js -------------//
$(document).ready(function() {

	//------------- Title notifications -------------//
    $('#add-notification').click(function(){
        titlenotifier.add();
    });
    $('#subsctract-notification').click(function(){
        titlenotifier.sub();
    });
    $('#number-notification').click(function(){
        titlenotifier.set(5);
    });
    $('#reset-notification').click(function(){
        titlenotifier.reset();
    });

    //------------- Gritter notices -------------//

    //info notice
    $('#regular-notice').click(function() {
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Jonh Doe',
            // (string | mandatory) the text inside the notification
            text: 'User is just logged into system.',
            // (string | optional) the image to display on the left
            image: 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
        });     
    });

    //info notice
    $('#info-notice').click(function() {
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Email send',
            // (string | mandatory) the text inside the notification
            text: 'Just let you know, you send last email without problems',
            // (int | optional) the time you want it to be alive for before fading out
            time: '',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
            // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
            icon: 'fa fa-envelope',
            // (string | optional) the class name you want to apply to that specific message
            class_name: 'info-notice'
        });     
    });

    //success notice
    $('#success-notice').click(function() {
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Done !!!',
            // (string | mandatory) the text inside the notification
            text: 'You successfull delete 13 files.<br> <a href="#" class="btn btn-xs btn-default mt10">Roll back</a>',
            // (int | optional) the time you want it to be alive for before fading out
            time: '',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
            // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
            icon: 'eco-trashcan',
            // (string | optional) the class name you want to apply to that specific message
            class_name: 'success-notice'
        });     
    });

    //warning notice
    $('#warning-notice').click(function() {
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Warrning !!!',
            // (string | mandatory) the text inside the notification
            text: '22 users closed their accounts, due to spam issues on server.',
            // (int | optional) the time you want it to be alive for before fading out
            time: '',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
            // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
            icon: 'icomoon-icon-user',
            // (string | optional) the class name you want to apply to that specific message
            class_name: 'warning-notice'
        });
    });

    //error notice
    $('#error-notice').click(function() {
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Error',
            // (string | mandatory) the text inside the notification
            text: 'User Jonh Doe is not added to database.',
            // (int | optional) the time you want it to be alive for before fading out
            time: '',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
            // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
            icon: 'icomoon-icon-user-plus-2',
            // (string | optional) the class name you want to apply to that specific message
            class_name: 'error-notice'
        });
    });

    //sticky notice
    $('#sticky-notice').click(function() {
        var unique_id = $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Jonh Doe',
            // (string | mandatory) the text inside the notification
            text: 'I just send you email, please check it out and tell me what you think',
            // (string | optional) the image to display on the left
            image: 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg',
            // (bool | optional) if you want it to fade out on its own or just sit there
            sticky: true,
            // (int | optional) the time you want it to be alive for before fading out
            time: '',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
            // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
        });
    });

    $('#topleft-notice').click(function() {
        $.extend($.gritter.options, { 
            position: 'top-left',
        });
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Jonh Doe',
            // (string | mandatory) the text inside the notification
            text: 'User is just logged into system.',
            // (string | optional) the image to display on the left
            image: 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
            sticky: true,
        });     
    });

    $('#bottomleft-notice').click(function() {
        $.extend($.gritter.options, { 
            position: 'bottom-left',
        });
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Jonh Doe',
            // (string | mandatory) the text inside the notification
            text: 'User is just logged into system.',
            // (string | optional) the image to display on the left
            image: 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
        });     
    });

    $('#bottomright-notice').click(function() {
        $.extend($.gritter.options, { 
            position: 'bottom-right',// possibilities: bottom-left, bottom-right, top-left, top-right
        });
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Jonh Doe',
            // (string | mandatory) the text inside the notification
            text: 'User is just logged into system.',
            // (string | optional) the image to display on the left
            image: 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
        });     
    });

    //------------- Sweet alerts -------------//
    document.querySelector('.sweet-1').onclick = function(){
        swal("Here's a message!");
    };

    document.querySelector('.sweet-2').onclick = function(){
        swal("Here's a message!", "It's pretty, isn't it?");
    };

    document.querySelector('.sweet-3').onclick = function(){
        swal("Good job!", "You clicked the button!", "success");
    };

    document.querySelector('.sweet-4').onclick = function(){
        swal({
          title: "Are you sure?",
          text: "You will not be able to recover this imaginary file!",
          type: "warning",
          showCancelButton: true,
          confirmButtonClass: 'btn-danger',
          confirmButtonText: 'Yes, delete it!',
          closeOnConfirm: false
        },
        function(){
          swal("Deleted!", "Your imaginary file has been deleted!", "success");
        });
    };

    document.querySelector('.sweet-5').onclick = function(){
        swal({
          title: "Are you sure?",
          text: "You will not be able to recover this imaginary file!",
          type: "warning",
          showCancelButton: true,
          confirmButtonClass: 'btn-danger',
          confirmButtonText: 'Yes, delete it!',
          cancelButtonText: "No, cancel plx!",
          closeOnConfirm: false,
          closeOnCancel: false
        },
        function(isConfirm){
          window.console.log('fuck', isConfirm);
          if (isConfirm){
            swal("Deleted!", "Your imaginary file has been deleted!", "success");
          } else {
            swal("Cancelled", "Your imaginary file is safe :)", "error");
          }
        });
    };

    document.querySelector('.sweet-6').onclick = function(){
        swal({
          title: "Sweet!",
          text: "Here's a custom image.",
          imageUrl: 'img/thumbs-up.jpg'
        });
    };
	
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