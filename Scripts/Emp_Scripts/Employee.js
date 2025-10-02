$(document).ready(function () {

    $("#btnSubmit").click(function () {
        $("#btnSubmit").text("Processing....!");
        $("#btnSubmit").prop("disabled", true);
        AddEmployee();
    });

    function AddEmployee() {
        var requestUrl = "/Home/AddEmployee";
        var EmployeeModel = getEmployeeModel();

        $.ajax({
            url: requestUrl,
            type: "POST",
            data: JSON.stringify(EmployeeModel),
            contentType: "application/json; charset=utf-8",
            success: function () {
                alert("Student Added successfully......!!");
                clearData();
               // getList();
                $("#btnSubmit").text("Submit");
                $("#btnSubmit").prop("disabled", false);
            },
            error: function (error) {
                console.error("Error Occour While Adding employee:", error);
                alert("Something wents wrong pls try Again Later");
                $("#btnSubmit").text("Submit");
                $("#btnSubmit").prop("disabled", false);
            }
        });
    }

    function getEmployeeModel() {
        return {
            Emp_Id: $("#hdnemployeeid").val(),
            Emp_Name: $("#name").val(),
            Emp_Designation: $("#designation").val(),
            Emp_Age: $("#age").val(),
            Emp_Salary: $("#salary").val(),
            Emp_MobileNo: $("#mobile").val(),
            Emp_Gender: $("input[type='radio'][name='gender']:checked").val(),
            Emp_Address: $("#address").val(),
        };
    }

    function clearData() {
        $('#hdnemployeeid').val('');
        $('#name').val('');
        $('#designation').val('');
        $('#age').val('');
        $('#salary').val('');
        $('#mobile').val('');
        $('#address').val('');
        $('#btnSubmit').text('Submit');
        $('#btnSubmit').prop('disabled', false);
    }


});
