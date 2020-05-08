$(document).ready(function () {
    $('#software').click(function () {
        $('#softwareDiv').show();
        $('#humanDiv').hide();
        $('#financeDiv').hide();
    });

    $('#human').click(function () {
        $('#softwareDiv').hide();
        $('#humanDiv').show();
        $('#financeDiv').hide();
    });

    $('#finance').click(function () {
        $('#softwareDiv').hide();
        $('#humanDiv').hide();
        $('#financeDiv').show();
    });

});

$('.service-catergory li').on('click', function () {
    $('li').removeClass('active');
    $(this).addClass('active');
});