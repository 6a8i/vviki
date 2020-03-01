$(document).ready(function(){
    $('p.title-text').dblclick(function(){
        $(this).hide();
        $('#title-text').show();
        $('#title-text').focus();
    });

    $('#title-text').focusout(function(e){
        $('p.title-text').html($(this).val());
        $(this).hide();
        $('p.title-text').show();
    });

    $(function() {
        $("ul#paragraph-list").sortable();
    });

    $('#paragraph-input').change(function()
    {
        $('<li class="paragraph-item"><p>' + $(this).val() + '</p></li>').insertBefore(this);
        $(this).val('Type something to add a new paragraph');
    });
});