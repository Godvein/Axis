$(function () {
    $('#editform').validate({
        errorClass: "text-danger",
        rules: {
            Username: "required",
            FullName: "required",
            RoleId: "required",
            DepartmentId: "required"
        }
    });
});
