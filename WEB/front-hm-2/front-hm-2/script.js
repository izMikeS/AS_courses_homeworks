var apiUrl = 'https://petstore.swagger.io/v2';
var currentId = 0;

$(document).ready(function () {

    $("#showAddForm").click(showAddForm);
    $(".show-update-button").click(showUpdateForm);

    $(".add-button").click(addUser);
    $(".update-button").click(updateUser);
    $(".remove-button").click(removeUser);


});

function showAddForm() {
    $('#addForm').css('display', 'block');
}

function showUpdateForm() {
    $('#updateForm').css('display', 'block');
    var usernameForUpdate = $(this).attr('name');
    $(".update-button").attr('name', usernameForUpdate);

    $.ajax({
        type: "GET",
        url: apiUrl + "/user/" + usernameForUpdate,
        complete: function (data) {
            var obj = data.responseJSON;
            $('#first-name-update').val(obj.firstName);
            $('#last-name-update').val(obj.lastName);
            $('#password-update').val(obj.password);
            $('#email-update').val(obj.email);
            $('#phone-update').val(obj.phone);
            $('#userstatus-update').val(obj.userStatus);
        }
    });

}

function isFormValid() {
      return $('#username').val() != '' &&
        $('#first-name').val() != '' &&
        $('#last-name').val() != '' &&
        $('#password').val() != '' &&
        $('#email').val() != '' &&
        $('#phone').val() != '' &&
        $('#userstatus').val() != '';
}

function clearForm() {
    $('#username').val('');
    $('#first-name').val('');
    $('#last-name').val('');
    $('#password').val('');
    $('#email').val('');
    $('#phone').val('');
    $('#userstatus').val('');
    $('#first-name-update').val('');
    $('#last-name-update').val('');
    $('#password-update').val('');
    $('#email-update').val('');
    $('#phone-update').val('');
    $('#userstatus-update').val('');
}

function addUser() {
    if (!isFormValid()) {
        alert("Form doesn\'t correct");
        return;
    }
    var usernameVal = $('#username').val()
    var firstNameVal = $('#first-name').val();
    var lastNameVal = $('#last-name').val();
    $.ajax({
        type: "POST",
        url: apiUrl + "/user",
        data: JSON.stringify({ id: currentId++, username: usernameVal, firstName: firstNameVal, lastName: lastNameVal, email: $('#email').val(), password: $('#password').val(), phone: $('#phone').val(), userStatus: $('#userstatus').val() }),
        contentType: "application/json",
        complete: function () {
            $('#user-container').append(`<div id="${usernameVal}" class= "user"><span class= "username-span" >${usernameVal} - ${firstNameVal} ${lastNameVal}</span ><button name="${usernameVal}" class="button show-update-button">🌠</button><button name="${usernameVal}" class="button remove-button">❌</button></div >`);
            $(".show-update-button").click(showUpdateForm);
            $(".remove-button").click(removeUser);
        }
    });
    clearForm();
    $('#addForm').css('display', 'none');
}

function removeUser() {
    var usernameForDelete = $(this).attr('name');
    $.ajax({
        type: "DELETE",
        url: apiUrl + "/user/" + usernameForDelete,
        complete: function (data) {
            $('#' + usernameForDelete).remove();
        }
    });
    $(this).attr("disabled", true);
}

function updateUser() {
    var usernameForUpdate = $(this).attr('name');
    var firstNameVal = $('#first-name-update').val();
    var lastNameVal = $('#last-name-update').val();
    $.ajax({
        type: "PUT",
        url: apiUrl + "/user/" + usernameForUpdate,
        data: JSON.stringify({ id: currentId++, username: usernameForUpdate, firstName: firstNameVal, lastName: $('#last-name-update').val(), email: $('#email-update').val(), password: $('#password-update').val(), phone: $('#phone-update').val(), userStatus: $('#userstatus-update').val() }),
        contentType: "application/json",
        complete: function (data) {
            $('#' + usernameForUpdate).remove();
            $('#user-container').append(`<div id="${usernameForUpdate}" class= "user"><span class= "username-span" >${usernameForUpdate} - ${firstNameVal} ${lastNameVal}</span ><button name="${usernameForUpdate}" class="button show-update-button">🌠</button><button name="${usernameForUpdate}" class="button remove-button">❌</button></div >`);
            $(".show-update-button").click(showUpdateForm);
            $(".remove-button").click(removeUser);
        }
    });
    clearForm();
    $('#updateForm').css('display', 'none');

}