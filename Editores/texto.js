$(document).ready(function(){
    $('h1.title-text').dblclick(function(e){
        $(this).hide();
        $('#title-text').show();
        $('#title-text').focus();
    });

    $('#title-text').focusout(function(e){
        $('h1.title-text').html($(this).val());
        $(this).hide();
        $('h1.title-text').show();
    });
});