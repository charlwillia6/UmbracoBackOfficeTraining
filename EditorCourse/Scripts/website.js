$(function () {

    $('#doc-history').click(function () {

        var id = $(this).attr('data-doc-id');
        
        $.get("/umbraco/api/DocumentationHistory/Versions/" + id,

            function (data) {
                $(data).each(function (i, item) {
                    var d = new Date(item.publishDate);

                    $("#doc-history-list")
                        .append("<dt><a>" + item.name + "</a><dt>")
                        .append("<dd><small>" + d.getUTCDate() + "/" + d.getUTCMonth()+1 + " - " + d.getFullYear() + "</small></dd>");
                });

            });

        return false;
    });

});