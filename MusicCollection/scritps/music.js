var commentTemplate = '<tr><td><div class="comment"><span class="cBody">"{body}"</span><span class="cName">{name}</span><span class="cEmail"><a href="mailto:{emailto}">{email}</a></span></div></td></tr>';

$(document).ready(function () {

    $('input[name$="btnSeeComments"]').click(function (event) {
        event.preventDefault();

        var postId = $(this).closest('div._photoInfo').find('input[name$="hfPhotoId"]').val();
        $.get(commentEndpoint.replace('{postId}', postId), function (data) {
            // fillComments(JSON.parse(data));
            fillComments(jQuery.parseJSON(JSON.stringify(data)));
        });
    });

    function fillComments(comments) {

        if (comments.length === 0) {
            alert('No hay comentarios para este álbum');
        }

        $('#tbComments tr').remove();
        var $tbComments = $('#tbComments');

        comments.forEach(function (c) {
            let $htmlCommentRow = $(commentTemplate.replace('{body}', c.body)
                .replace('{name}', c.name)
                .replace('{emailto}', c.email)
                .replace('{email}', c.email));
            $tbComments.append($htmlCommentRow);
        });
    }

});
