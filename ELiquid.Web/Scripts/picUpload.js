function fileChange() {
    var file = document.getElementById('input_img');
    var form = new FormData();
    form.append("image", file.files[0])

    var settings = {
        "url": "https://api.imgbb.com/1/upload?key=7d6d6bfa746c21daf765df502feaa8b4",
        "method": "POST",
        "timeout": 0,
        "processData": false,
        "mimeType": "multipart/form-data",
        "contentType": false,
        "data": form
    };


    $.ajax(settings).done(function (response) {
        
        var jx = JSON.parse(response);
        document.getElementById("Image").setAttribute('value', jx.data.url);

    });
};

function AddEdit() {
    var imageString = document.getElementById("Image");
    if (imageString.getAttribute('value') === "")
        imageString.setAttribute('value', '/Content/Images/No-image-available.png');
    
    
};

function PgVgChange() {
    var valuePG = document.getElementById("PG");
    var valueVG = document.getElementById("VG");

    valuePG.setAttribute('value', Math.abs(valueVG.value - 100));
    valueVG.setAttribute('value', Math.abs(valuePG.value - 100));

    //var valuePGDisplayed = document.getElementById("PG-slider-value");
    //valuePGDisplayed.setAttribute('value', valuePG.value);

    var valuePGDisplayed = document.getElementById("PG-slider-value");
    valuePGDisplayed.innerHTML = valuePG.value + '%';

    var valueVGDisplayed = document.getElementById("VG-slider-value");
    valueVGDisplayed.innerHTML = valueVG.value + '%';


};




