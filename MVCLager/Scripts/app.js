var currentId = -1;

function main() {
    $('.delete').click(function (e) {
        e.stopPropagation();
        e.preventDefault();
        var data = $(this).data();
        var modalel = $('#confirmModal')
        var p = modalel.find('.modal-body>p');
        var msg = "Är du säker på att du vill radera " + data.name + "?";
        p.text = msg;
        currentId = data.id;
        modalel.modal('show');
    });

    $('#confirmDelete').click(function () {
        alert("Raderar " + currentId);
        //location.href = "/items/delete/" + data.id;
    });

    //$('#searchString').keypress(function (e) {
    //    if (e.which == 13) {
    //        goSearch();
    //    }
    //});
}

//function goSearch() {
//    console.log("Söker..");
//    var searchString = $("#searchString").val();
//    var queryString = "searchString=" + searchString;
//    //alert("Yo you want to search for " + searchString);
//    //$.post("/Items/Search", queryString, callBackSearch, "_default");
//    //$.post("/Items/Search/" + queryString, callBackSearch, "_default");
//    $.post("/Items/Search/" + queryString, cb);
//}

//function cb(body) {
//    //console.log("im the callback " + error);
//    //$(document).body.load(body);
//    $("body").first().load(body);
//}

window.onload = function() {
    $(document).ready(function () {
        main();
    });
}