//------------- forms-wizard.js -------------//
$(document).ready(function() {

	//------------- Form wizard -------------//

    //add validation to wizard
    var $validator = $("#wizard form").validate({
        errorPlacement: function( error, element ) {
            var place = element.closest('.input-group');
            if (!place.get(0)) {
                place = element;
            }
            if (place.get(0).type === 'checkbox') {
                place = element.parent();
            }
            if (error.text() !== '') {
                place.after(error);
            }
        },
        errorClass: 'help-block',
        rules: {
            firstname: {
                required: true
            },
            email: {
                required: true,
                email: true
            },
            username: {
                required: true
            },
            password: {
                required: true,
                minlength: 5
            },
            password_2: {
                required: true,
                minlength: 5,
                equalTo: "#password"
            }
        },
        messages: {
            firstname: {
                required: "I need to know your first name Sir"
            },
            email: {
                required: "You email is required Sir"
            }
        },
        highlight: function( label ) {
            $(label).closest('.form-group').removeClass('has-success').addClass('has-error');
        },
        success: function( label ) {
            $(label).closest('.form-group').removeClass('has-error');
            label.remove();
        }
    });
    
    //init first wizard
    $('#wizard').bootstrapWizard({
        tabClass: 'bwizard-steps',
        nextSelector: 'ul.pager li.next',
        previousSelector: 'ul.pager li.previous',
        firstSelector: null,
        lastSelector: null,
        onNext: function( tab, navigation, index, newindex ) {
            var validated = $('#wizard form').valid();
            if( !validated ) {
                $validator.focusInvalid();
                return false;
            }
        },
        onTabClick: function( tab, navigation, index, newindex ) {
            if ( newindex == index + 1 ) {
                return this.onNext( tab, navigation, index, newindex);
            } else if ( newindex > index + 1 ) {
                return false;
            } else {
                return true;
            }
        },
        onTabShow: function( tab, navigation, index ) {
            tab.prevAll().addClass('completed');
            tab.nextAll().removeClass('completed');
            var $total = navigation.find('li').length;
            var $current = index+1;
            // If it's the last tab then hide the last button and show the finish instead
            if($current >= $total) {
                $('#wizard').find('.pager .next').hide();
                $('#wizard').find('.pager .finish').show();
                $('#wizard').find('.pager .finish').removeClass('disabled');
            } else {
                $('#wizard').find('.pager .next').show();
                $('#wizard').find('.pager .finish').hide();
            }
        }
    });

    //wizard is finish
    $('#wizard .finish').click(function() {
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Done !!!',
            // (string | mandatory) the text inside the notification
            text: 'You successfull submit form wizard',
            // (int | optional) the time you want it to be alive for before fading out
            time: '',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
            // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
            icon: 'icomoon-icon-checkmark',
            // (string | optional) the class name you want to apply to that specific message
            class_name: 'success-notice'
        });   
    });

    //------------- Wizard with progressbar -------------//
    //init first wizard
    $('#wizard1').bootstrapWizard({
        tabClass: 'bwizard-steps',
        nextSelector: 'ul.pager li.next',
        previousSelector: 'ul.pager li.previous',
        firstSelector: null,
        lastSelector: null,
        onTabShow: function( tab, navigation, index ) {
            tab.prevAll().addClass('completed');
            tab.nextAll().removeClass('completed');
            var $total = navigation.find('li').length;
            var $current = index+1;
            var $percent = ($current/$total) * 100;
            $('#wizard1').find('.progress-bar').css({width:$percent+'%'});
            // If it's the last tab then hide the last button and show the finish instead
            if($current >= $total) {
                $('#wizard1').find('.pager .next').hide();
                $('#wizard1').find('.pager .finish').show();
                $('#wizard1').find('.pager .finish').removeClass('disabled');
            } else {
                $('#wizard1').find('.pager .next').show();
                $('#wizard1').find('.pager .finish').hide();
            }
        }
    });

    //wizard is finish
    $('#wizard1 .finish').click(function() {
        //show message
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Done !!!',
            // (string | mandatory) the text inside the notification
            text: 'You successfull submit form wizard',
            // (int | optional) the time you want it to be alive for before fading out
            time: '',
            // (string) specify font-face icon  class for close message
            close_icon: 'entypo-icon-cancel s12',
            // (string) specify font-face icon class for big icon in left. if are specify image this will not show up.
            icon: 'icomoon-icon-checkmark',
            // (string | optional) the class name you want to apply to that specific message
            class_name: 'success-notice'
        });    
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