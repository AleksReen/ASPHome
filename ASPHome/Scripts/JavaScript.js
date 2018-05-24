var screenWidth = screen.width;

function onUpdate() { 
    $("#data").animate({ left: screenWidth + 'px' }, 1000);
}

function onSuccess() {
    $("#data").animate({ right: screenWidth + 'px', left: '0px' }, 1000);
}

(function () {
    //установка даты через WebApi
    $.ajax({
        url: "/api/HomeApi",
        type: "GET",
        success: function (data) {
            $("#date").text(data + " web api");
        },
        error: function (error) {
            console.warn(error.responseJSON.Message);
        }
    });

})();
