function getInfo() {
    var Letter = document.getElementById('Letter').value;
    var num = document.getElementById('Number').value;
    console.log(Letter, num);

    var source = '/Words/Generate?Letter=' + Letter + '&num=' + num;
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: source,
        success: showSentences,
        error: errorOnAjax
    });
}

function showSentences(data) {
    console.log(data);
    $('#SentenceTable').empty();
    $('#SentenceTable').append(`
        <table class="table table-fixed" >
        <thead>
            <tr>
                <th scope="col" class="col-3">#</th>
                <th scope="col" class="col-9">Sentence</th>

            </tr>
        </thead>
<tbody id="Guts">

 </tbody>  
 </table>
`);
    for (var i = 0; i < data.length; i++) {

        $('#Guts').append(`
         
            <tr>
                <th scope="row" class="col-3">${i+1}</th>
                <td class="col-9">${data[i]}</td>

            </tr>

        

        `);


    }


   
        
   
}
function errorOnAjax() {
    console.log("Error on Ajax Return");

}