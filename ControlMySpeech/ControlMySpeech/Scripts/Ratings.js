function getRatings(id) {
    var tension = document.getElementById('Tension').value;
    var relax = document.getElementById('Relax').value;
    var Comments = document.getElementById('comments').value;
    

    console.log(id);
    var source = '/Record/SaveRatings?tension=' + tension + '&relax=' + relax + '&AudioID=' + id; 
    $.ajax({
        type: 'POST',
        dataType: 'json',
        data: { "Comments": Comments },
        url: source,
        success: success,
        error: errorOnAjax
    });
    window.location.href = "/Record/Index";
}
function success() {
   
}
function errorOnAjax() {
    console.log("Error on Ajax Return");

}
