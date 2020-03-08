$(document).ready(function(){
    $(function() {
        $( "#sortable" ).sortable({
            placeholder: {
                element: function(currentItem) {
                    return $('<li><div class="paragraph-drop"></div></li>');
                },
                update: function(container, p) {
                    return;
                }
            }
          });
          $( "#sortable" ).disableSelection();
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
});


$(document).on('dblclick', 'p.title-text', function(){
    $(this).hide();
    $('#title-text').show();
    $('#title-text').focus();
});

$(document).on('focusout', '#title-text', function(e){
    $('p.title-text').html($(this).val());
    $(this).hide();
    $('p.title-text').show();
});

$(document).on('keypress', '#title-text', function(e) {
    // 13 is the code for the 'enter' key.
    if(e.shiftKey && e.which == 13) {
        $('p.title-text').html($(this).val());
        $(this).hide();
        $('p.title-text').show();
    }
});

$(document).on('dblclick', '.paragraph-item p', function(){
    var val = $(this).html();
    var li = $(this).parent();
    li.html('<textarea id="paragraph-editor">' + val + '</textarea>');
    $('#paragraph-editor').focus;
});

$(document).on('keypress', '#paragraph-editor', function(e) {
    // 13 is the code for the 'enter' key.
    if(e.shiftKey && e.which == 13) {
        var val = $(this).val();
        var li = $(this).parent();
        li.html('<li class="paragraph-item"><p>' + val + '</p></li>');
    }
});

// the two functions below are to hide or show the grab icon
$(document).on('mouseover', 'li.paragraph-item p', function() {
    $(this).parent().addClass('draggable');
});

$(document).on('mouseout', 'li.paragraph-item p', function() {
    $(this).parent().removeClass('draggable');
});
// the two functions above are to hide or show the grab icon
