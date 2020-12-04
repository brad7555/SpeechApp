/*window.onload = function () {
    window.location.assign(window.location.reload());
    }*/

function DeleteFile(id) {
    //Sending the ID to the console for testing 
    console.log(id);

    //Making the user confrim that they want the file deleted
    if (confirm("Delete File?")) {
        //Crafting the URL to contain the ID so it can be 
        //sent back to the controller function
        var URL = "/Record/DeleteFile?ID=" + id;
        //Ajax call to controller, sending the ID
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: URL,
            
            success: function (response) {
                location.reload(); 
                console.log("Success")

            },
            error: errorOnAjax,
            
        });
    }

}
//Function to send an error message back to the console
function errorOnAjax() {
    console.log("Error on Ajax Return"); 

}

