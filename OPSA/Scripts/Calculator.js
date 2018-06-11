/*

Ensure accurate calculation
Change colors
Ensure mobile friendly
Remove dec from convcomp
Round markup to .000 instead of .00
change colors for read only fields
Make markup depend on GP
Add GP selection buttons,
reimplement approval warnings
<22 CEO/COO RED
22-25 CEO YELLOW
26-28 VP YELLOW
29-31 Good GREEN
>31 VP RED

Admin able to add clients to the calculator with Option for markup and VMS values.

change copyright to OPS Labs
Calculator => GP Calc
Hide until logged in.
Email confirmation to admin for account verification/approval-rejection, as well as confirmation to user creating account.

Captcha / Im not a robot.
Email verification.


*/



/*
$(document).on("change", function () {

    var $inputs = $('#CalculatorForm :input');

    //$.post();
    $.ajax({
        type: "POST",
        url: "Calculate",
        data: $inputs,
        success: function (data) {

            console.log(data);
            console.log("This is Input Data");

        },
        error: function () {
            alert("Error, Mi coche es migrantiete en la basoon.");
        }
    });

});


sessionStorage.SessionName = "SessionData";

sessionStorage.getItem("SessionName");



*/
//Markup numbers for clients
var MarkupAlly = 1.55;
var MarkupFiserv = 1.42;
var MarkupNCR = 1.581;
var VMSAlly = 4.10;
var VMSFiserv = 2.05;
var VMSNCR = 0.0;

//Vars
var Payrate = 0;
var Billrate = 0;
var Loadedpay = 0;
var Markup = 0;
var Convcomp = 0;
var Billablehrs = 0;
var Burdenrate;
var Hourlyburden = 0;
var VMSRate = 0;
var VMSResult = 0;
var Grossprofit = 0;
var Grossprofitmargin = 0;
var Annualgrossprofit = 0;
var Costtoclient = 0;





//Hide VMS on start because client is generic
$(document).ready(function () {
    $('.vms').hide();
});

//Sets VMS and Markup and shows VMS for various clients
function clientChangeHandler() {

    var client = $('.clientdropdown option:selected').val();
    $('.burdenrate').prop("selectedIndex", 0);

    switch (client) {

        case 'Generic':
            reset();
            Markup = 0;
            VMSRate = 0;
            $('.markup').prop("readonly", false);
            //$('.markup').val(0);
            //$('.vmsrate').val(0);
            $('.vms').hide();
            $('.burdenrate').attr("disabled", false);
            break;
        case 'Ally':
            reset();
            Markup = MarkupAlly;
            VMSRate = VMSAlly;
            $('.markup').prop("readonly", true);
            //$('.markup').val(MarkupAlly);
            //$('.vmsrate').val(VMSAlly);
            $('.vms').show();
            $('.burdenrate').attr("disabled", true);

            break;
        case 'Fiserv':
            reset();
            Markup = MarkupFiserv;
            VMSRate = VMSFiserv;
            $('.markup').prop("readonly", true);
            //$('.markup').val(MarkupFiserv);
            //$('.vmsrate').val(VMSFiserv);
            $('.vms').show();
            $('.burdenrate').attr("disabled", true);
            break;
        case 'NCR':
            reset();
            Markup = MarkupNCR;
            VMSRate = VMSNCR;
            $('.markup').prop("readonly", true);
            //$('.markup').val(MarkupNCR);
            //$('.vmsrate').val(VMSNCR);
            $('.vms').show();
            $('.burdenrate').attr("disabled", true);
            break;
        default:
            break;
    }
    $('.markup').val(Markup);
    $('.vmsrate').val(VMSRate);
}

//Input validation handler
$('body').on('keydown keyup keypress change blur focus paste', 'input[type="text"]', function () {
    var target = $(this);

    var prev_val = target.val();

    setTimeout(function () {
        var chars = target.val().split("");


        var decimal_exist = false;
        var remove_char = false;

        $.each(chars, function (key, value) {
            switch (value) {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '.':
                    if (value === '.') {
                        if (decimal_exist === false) {
                            decimal_exist = true;
                        }
                        else {
                            remove_char = true;
                            chars['' + key + ''] = '';
                        }
                    }
                    break;
                default:
                    remove_char = true;
                    chars['' + key + ''] = '';
                    break;
            }
        });

        if (prev_val != target.val() && remove_char === true) {
            target.val(chars.join(''))
        }
    }, 0);
});

//Reset to default values.
function reset() {

    var Payrate = 0;
    var Billrate = 0;
    var Loadedpay = 0;
    var Convcomp = 0;
    var Billablehrs = 0;
    var Hourlyburden = 0;
    var VMSResult = 0;
    var Grossprofit = 0;
    var Grossprofitmargin = 0;
    var Annualgrossprofit = 0;
    var Costtoclient = 0;

    $('.payrate').val(0);
    $('.billrate').val(0);
    $('.loadedpay').val(0);
    $('.convcomp').val(0);
    $('.billablehrs').val(0);
    $('.hourlyburden').val(0);
    $('.vmsresult').val(0);
    $('.grossprofit').val(0);
    $('.grossprofitmargin').val(0);
    $('.annualgrossprofit').val(0);
    $('.costtoclient').val(0);
    $(".billrate").prop("readonly", false);
    $(".payrate").prop("readonly", false);

}

//ConvComp change handler
$(document).ready($('.convcomp').change(function () {

    if (parseFloat($('.convcomp').val()) === 0 || $('.convcomp').val() === '' || $('.convcomp').val() === null) {
        //$('.billablehrs').prop("readonly", false);
        $('.billablehrs').val(0);
        $('.convcomp').val(0);
    }
    else if (parseFloat($('.convcomp').val()) !== 0) {
        //$('.billablehrs').prop("readonly", true);
        $('.convcomp').val(parseFloat($('.convcomp').val()).toFixed(2));
        $('.billablehrs').val((168 * parseFloat($('.convcomp').val())).toFixed(0));
    }

    update();

}));

//BillableHrs change handler
$(document).ready($('.billablehrs').change(function () {
    if (parseFloat($('.billablehrs').val()) === 0 || $('.billablehrs').val() === '' || $('.billablehrs').val() === null) {
        //$('.convcomp').prop("readonly", false);
        $('.convcomp').val(0);
        $('.billablehrs').val(0);
    }
    else if (parseFloat($('.billablehrs').val()) !== 0) {
        $('.billablehrs').val(parseFloat($('.billablehrs').val()).toFixed(0));
        $('.convcomp').val((parseFloat($('.billablehrs').val()) / 168).toFixed(2));
    }

    update();
}));

//Calculation Update method
function update() {

    if ($('.billrate').val() === '0' || $('.payrate').val() === '0' || $('.markup').val() === '0') {
        $('.annualgrossprofit').val(0);
        $('.costtoclient').val(0);
        $('.vmsresult').val(0);
        $('.grossprofit').val(0);
        $('.grossprofitmargin').val(0);
        $('.loadedpay').val(0);
        $('.hourlyburden').val(0);
    }
    else {
        $('.hourlyburden').val(((parseFloat($('.burdenrate').val() / 100)) * parseFloat($('.payrate').val())).toFixed(2));
        $('.loadedpay').val((parseFloat($('.hourlyburden').val()) + parseFloat($('.payrate').val())).toFixed(2));
        $('.vmsresult').val((parseFloat($('.billrate').val()) * (1 - (parseFloat($('.vmsrate').val() / 100)))).toFixed(2));
        $('.grossprofit').val((parseFloat($('.vmsresult').val()) - parseFloat($('.loadedpay').val())).toFixed(2));
        $('.grossprofitmargin').val(((parseFloat($('.grossprofit').val()) / parseFloat($('.vmsresult').val())) * 100).toFixed(2));
        $('.annualgrossprofit').val((parseFloat($('.grossprofit').val()) * parseFloat($('.billablehrs').val())).toFixed(2));
        $('.costtoclient').val((parseFloat($('.billrate').val()) * parseFloat($('.billablehrs').val())).toFixed(2));
    }
}

//Payrate change handler
$(document).ready($('.payrate').change(function () {

    if ($('.clientdropdown option:selected').val() !== 'Generic') {

        if (parseFloat($('.payrate').val()) === 0 || $('.payrate').val() === '' || $('.payrate').val() === null || $('.payrate').val() === '.') {
            $('.payrate').val(0);
            $('.billrate').prop("readonly", false);
            $('.billrate').val(0);
        }
        else if (parseFloat($('.payrate').val()) !== 0) {
            $('.payrate').val(parseFloat($('.payrate').val()).toFixed(2));
            $('.billrate').prop("readonly", true);
            $('.billrate').val((parseFloat($('.payrate').val()) * parseFloat($('.markup').val())).toFixed(2));
        }
    }
    else if ($('.clientdropdown option:selected').val() === 'Generic') {

        if (parseFloat($('.payrate').val()) === 0 || $('.payrate').val() === '' || $('.payrate').val() === null || $('.payrate').val() === '.') {
            $('.payrate').val(0);

            if ($('.billrate').prop("readonly") === true) {
                $('.billrate').prop("readonly", false);
                $('.billrate').val(0);
            }
            if ($('.markup').prop("readonly") === true) {
                $('.markup').prop("readonly", false);
                $('.markup').val(0);
            }
        }
        else if (parseFloat($('.payrate').val()) !== 0) {

            $('.payrate').val(parseFloat($('.payrate').val()).toFixed(2));

            if (parseFloat($('.billrate').val()) !== 0 && $('.billrate').prop("readonly") === false) {

                $('.markup').prop("readonly", true);
                $('.markup').val((parseFloat($('.billrate').val()) / parseFloat($('.payrate').val())).toFixed(2));
            }
            else if (parseFloat($('.markup').val()) !== 0 && $('.markup').prop("readonly") === false) {
                $('.billrate').prop("readonly", true);
                $('.billrate').val((parseFloat($('.payrate').val()) * parseFloat($('.markup').val())).toFixed(2));
            }
        }
    }
    update();
}));

//Billrate change handler
$(document).ready($('.billrate').change(function () {
    if ($('.clientdropdown option:selected').val() !== 'Generic') {
        if (parseFloat($('.billrate').val()) === 0 || $('.billrate').val() === '' || $('.billrate').val() === null || $('.billrate').val() === '.') {
            $('.payrate').prop("readonly", false);
            $('.payrate').val(0);
            $('.billrate').val(0);

        }
        else if (parseFloat($('.billrate').val()) !== 0) {
            $('.billrate').val(parseFloat($('.billrate').val()).toFixed(2));
            $('.payrate').prop("readonly", true);
            $('.payrate').val((parseFloat($('.billrate').val()) / parseFloat($('.markup').val())).toFixed(2));
        }
    }
    else if ($('.clientdropdown option:selected').val() === 'Generic') {

        if (parseFloat($('.billrate').val()) === 0 || $('.billrate').val() === '' || $('.billrate').val() === null || $('.billrate').val() === '.') {
            $('.billrate').val(0);

            if ($('.payrate').prop("readonly") === true) {
                $('.payrate').prop("readonly", false);
                $('.payrate').val(0);
            }
            if ($('.markup').prop("readonly") === true) {
                $('.markup').prop("readonly", false);
                $('.markup').val(0);
            }
        }
        else if (parseFloat($('.billrate').val()) !== 0) {

            $('.billrate').val(parseFloat($('.billrate').val()).toFixed(2));

            if (parseFloat($('.payrate').val()) !== 0 && $('.payrate').prop("readonly") === false) {
                $('.markup').prop("readonly", true);
                $('.markup').val((parseFloat($('.billrate').val()) / parseFloat($('.payrate').val())).toFixed(2));
            }
            else if (parseFloat($('.markup').val()) !== 0 && $('.markup').prop("readonly") === false) {
                $('.payrate').prop("readonly", true);
                $('.payrate').val((parseFloat($('.billrate').val()) / parseFloat($('.markup').val())).toFixed(2));
            }
        }
    }
    update();
}));

//Markup change handler
$(document).ready($('.markup').change(function () {
    if ($('.clientdropdown option:selected').val() === 'Generic') {

        if (parseFloat($('.markup').val()) === 0 || $('.markup').val() === '' || $('.markup').val() === null || $('.markup').val() === '.') {
            Markup = 0;
            $('.markup').val(0);

            if ($('.payrate').prop("readonly") === true) {
                $('.payrate').prop("readonly", false);
                Payrate = 0;
                $('.payrate').val(0);
            }
            if ($('.billrate').prop("readonly") === true) {
                $('.billrate').prop("readonly", false);
                Billrate = 0;
                $('.billrate').val(0);
            }
        }
        else if (parseFloat($('.markup').val()) !== 0) {
            Markup = parseFloat($('.markup').val());
            $('.markup').val(Markup.toFixed(2));

            if (parseFloat($('.payrate').val()) !== 0 && $('.payrate').prop("readonly") === false) {
                $('.billrate').prop("readonly", true);
                $('.billrate').val((parseFloat($('.payrate').val()) * parseFloat($('.markup').val())).toFixed(2));
            }
            else if (parseFloat($('.billrate').val()) !== 0 && $('.billrate').prop("readonly") === false) {
                $('.payrate').prop("readonly", true);
                $('.payrate').val((parseFloat($('.billrate').val()) / parseFloat($('.markup').val())).toFixed(2));
            }
        }
    }
    update();
}));

    /*
    $(document).ready($('.generic').change(function () {

        if ($('.clientdropdown option:selected').val() === 'Generic') {

            if (parseFloat($('.payrate').val()) === 0 || $('.payrate').val() === '' || $('.payrate').val() === null || $('.payrate').val() === '.') {
                $('.payrate').val(0);
                if ($('.billrate').val() === '0' && $('.markup').prop("readonly") === ) {

                }
            }
            if (parseFloat($('.billrate').val()) === 0 || $('.billrate').val() === '' || $('.billrate').val() === null || $('.billrate').val() === '.') {
                $('.billrate').val(0);
            }
            if (parseFloat($('.markup').val()) === 0 || $('.markup').val() === '' || $('.markup').val() === null || $('.markup').val() === '.') {
                $('.markup').val(0);
            }
            update();
        }
    }));
    */

    //$(document).ready(function () {
    //    $(".clientdropdown option[value=@@Model.SelectedGPM]").attr('selected', 'selected');
    //});

    /*jQuery(document).ready(function () {

        var gpbox = $("#gpms");

        //BJR added default value for GPM
        //var value = parseFloat($('#selVal').val());
        //$('#gpm').val(value);

        var approval = $("#Approval");
        var approvalvalue = approval.val();

        if (approvalvalue == "Good") {
            gpbox.removeClass("CEOApproval");
            gpbox.removeClass("VPApproval");
            gpbox.addClass("Good");
        }

        if (approvalvalue == "Needs CEO Approval") {
            gpbox.removeClass("Good");
            gpbox.removeClass("VPApproval");
            gpbox.addClass("CEOApproval");
        }

        if (approvalvalue == "Needs VP Approval") {
            gpbox.removeClass("CEOApproval");
            gpbox.removeClass("Good");
            gpbox.addClass("VPApproval");
        }
        //if (approvalvalue == "ERROR" || gpbox.val() == 0) {
        //    gpbox.removeClass("CEOApproval");
        //    gpbox.removeClass("Good");
        //    gpbox.removeClass("VPApproval");
        //}
    });*/