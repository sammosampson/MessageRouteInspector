//------------- forms-advanced.js -------------//
$(document).ready(function() {

    //------------- Fancy select -------------//
    $('.fancy-select').fancySelect();
    //custom templating
    $('.fancy-select1').fancySelect({
        optionTemplate: function(optionEl) {
            return optionEl.text() + '<i class="pull-left ' + optionEl.data('icon') + '"></i>';
        }
    });

    //------------- Select 2 -------------//
    $('.select2').select2({placeholder: 'Select state'});

    //minumum 2 symbols input
    $('.select2-minimum').select2({
        placeholder: 'Select state',
        minimumInputLength: 2,
    });

    //------------- Masked input fields -------------//
    $("#mask-phone").mask("(999) 999-9999", {completed:function(){alert("Callback action after complete");}});
    $("#mask-phoneExt").mask("(999) 999-9999? x99999");
    $("#mask-phoneInt").mask("+40 999 999 999");
    $("#mask-date").mask("99/99/9999");
    $("#mask-ssn").mask("999-99-9999");
    $("#mask-productKey").mask("a*-999-a999", { placeholder: "*" });
    $("#mask-eyeScript").mask("~9.99 ~9.99 999");
    $("#mask-percent").mask("99%");

    //------------- Dual list box -------------//
    $('.duallistbox').bootstrapDualListbox({
        nonSelectedListLabel: 'Non-selected',
        selectedListLabel: 'Selected',
        preserveSelectionOnMove: 'moved',
        moveOnSelect: false,
    });

    //------------- Spinners -------------//
    $("#basic-spinner").TouchSpin({
        min: 0,
        max: 100
    });
    //with postfix
    $("#postfix-spinner").TouchSpin({
        min: 0,
        max: 100,
        postfix: '%'
    });
    //with prefix
    $("#prefix-spinner").TouchSpin({
        min: 0,
        max: 100,
        prefix: '$'
    });
    //decimal spinner
    $("#decimal-spinner").TouchSpin({
        min: 1,
        max: 10,
        step: 0.1,
        decimals: 2
    });
    //vertical buttons
    $("#vertical-spinner").TouchSpin({
        verticalbuttons: true,
        verticalupclass: 'fa fa-angle-up s12',
        verticaldownclass: 'fa fa-angle-down s12'
    });

    //------------- Datepicker -------------//
    $("#basic-datepicker").datepicker();
    //multiple date
    $("#multiple-datepicker").datepicker({
        multidate: true
    });
    //date range
    $(".input-daterange").datepicker();
    //inline
    $("#inline-datepicker").datepicker();

    //------------- Timepicker -------------//
    $('#default-timepicker').timepicker({
        upArrowStyle: 'fa fa-angle-up',
        downArrowStyle: 'fa fa-angle-down',
    });
    //custom time
    $('#customtime-timepicker').timepicker({
        upArrowStyle: 'fa fa-angle-up',
        downArrowStyle: 'fa fa-angle-down',
        defaultTime: '22:45 AM'
    });
    //custom minute step
    $('#minute-step-timepicker').timepicker({
        upArrowStyle: 'fa fa-angle-up',
        downArrowStyle: 'fa fa-angle-down',
        minuteStep: 30
    });
    //show seconds
    $('#show-seconds-timepicker').timepicker({
        upArrowStyle: 'fa fa-angle-up',
        downArrowStyle: 'fa fa-angle-down',
        showSeconds: true
    });

    //------------- Colorpicker -------------//
    $('#default-colorpicker').colorpicker();
    //as component
    $('#component-colorpicker').colorpicker({
        color: '#1fba5d'
    });
    //horizontal
    $('#horizontal-colorpicker').colorpicker({
        horizontal: true
    });
    //inline
     $('#inline-colorpicker').colorpicker({
        inline: true,
        container: '.inline-picker'
    });

    //------------- Tags -------------//
    //from json
    var citynames = new Bloodhound({
      datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
      queryTokenizer: Bloodhound.tokenizers.whitespace,
      prefetch: {
        url: 'ajax/citynames.json',
        filter: function(list) {
          return $.map(list, function(cityname) {
            return { name: cityname }; });
        }
      }
    });
    citynames.initialize();

    $('#json-tags').tagsinput({
        typeaheadjs: {
            name: 'citynames',
            displayKey: 'name',
            valueKey: 'name',
            source: citynames.ttAdapter()
        }
    });

    //------------- WYSIWYG summernote -------------//
    $('#summernote').summernote({
        height: 200
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