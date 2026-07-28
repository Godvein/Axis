$(function () {
    $('#loginform').validate({
    rules: {
        Username: "required",
        Password: "required"
    },
    messages: {
        Username: "Username is required",
        Password: "Password is required"
    }
});
});
