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
    
    $('#paragraph-input').on('keypress',function(e) {
        // 13 is the code for the 'enter' key.
        if(e.shiftKey && e.which == 13) {
            var paragraphs = $(this).val().split(/(\r\n|\n\r|\r|\n)/);
            paragraphs.forEach(element => {
                $('<li class="paragraph-item"><p>' + element + '</p></li>').insertBefore('li.paragraph-input-item');
            });
            $(this).val('');
        }
    });

    // the two functions below are to hide or show the grab icon
    $('li.paragraph-item p').mouseover(function() {
        $(this).parent().addClass('draggable');
    });

    $('li.paragraph-item p').mouseout(function() {
        $(this).parent().removeClass('draggable');
    });
    // the two functions above are to hide or show the grab icon
});