$.validator.addMethod("matchPassword", function (value, element) {
    console.log("called");
    return value == $("#Password").val();
}, "Passwords do not match");

$(function () {
    $('#createuserform').validate({
        errorClass: "text-danger",
        rules: {
        Username: "required",
        FullName: "required",
            Password: {
                required: true,
                minlength: 5
            },
            ConfirmPassword: {
                required: true,
                matchPassword: true
            },
            RoleId: "required",
            DepartmentId: "required"
    }
    });
});
