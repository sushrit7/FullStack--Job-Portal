// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function addEducation() {
 
    // Load _Experience.cshtml partial view and append to container
    $.ajax({
        url: '/ProfessionalProfile/AddEducation',
       
        success: function (partialView) {
            $('#education-container').append(partialView);
        }
    });
}

function previewImage(event) {
    var img = document.getElementById("preview");
    var reader = new FileReader();
    reader.onload = function () {
        img.src = reader.result;
    }
    if (event.target.files[0]) {
        reader.readAsDataURL(event.target.files[0]);
    } else {
        img.src = "https://via.placeholder.com/200x200.png?text=Preview+Image&bg=FFFFFF";
    }
}

function addSkill() {

    // Load _Experience.cshtml partial view and append to container
    $.ajax({
        url: '/ProfessionalProfile/AddSkill',

        success: function (partialView) {
            $('#skill-container').append(partialView);
        }
    });
}