$(document).ready(function () {

    getList();

    function getList() {
        var requestUrl = "/Home/getList";
        $.ajax({
            url: requestUrl,
            type: "GET",
            success: function (data) {
                renderGrid(data);
            }
        });
    }

    function renderGrid(data) {
        var html = '';
        $.each(data, function (index, row) {
            const Emp_Name = row.Emp_Name || '';
            const Emp_Designation = row.Emp_Designation || '';
            const Emp_Age = row.Emp_Age || '';
            const Emp_Salary = row.Emp_Salary || '';
            const Emp_MobileNo = row.Emp_MobileNo || '';
            const Emp_Gender = row.Emp_Gender || '';
            const Emp_Address = row.Emp_Address || '';
            var SrNo = index + 1;

            html += '<tr class="hover:bg-blue-50">';
            html += '<td class="px-4 py-2">' + SrNo + '</td>';
            html += '<td class="px-4 py-2">' + Emp_Name + '</td>';
            html += '<td class="px-4 py-2">' + Emp_Designation + '</td>';
            html += '<td class="px-4 py-2">' + Emp_Age + '</td>';
            html += '<td class="px-4 py-2">' + Emp_Salary + '</td>';
            html += '<td class="px-4 py-2">' + Emp_MobileNo + '</td>';
            html += '<td class="px-4 py-2">' + Emp_Gender + '</td>';
            html += '<td class="px-4 py-2">' + Emp_Address + '</td>';
            // Actions column
            html += '<td class="px-4 py-2 text-center flex gap-2 justify-center">' +
                '<button class="px-3 py-1 text-xs bg-yellow-400 hover:bg-yellow-500 text-white rounded-lg shadow edit-icon" data-id="' + row.Emp_Id + '">Edit</button>' +
                '<button class="px-3 py-1 text-xs bg-red-500 hover:bg-red-600 text-white rounded-lg shadow delete-icon" data-id="' + row.Emp_Id + '">Delete</button>' +
                '</td>';
        });
        $('#tblemployeebody').html(html);
        $('#tblemployee').DataTable();
    }


    // Click event for delete button
    $(document).on('click', '.delete-icon', function () {
        var Emp_Id = $(this).data('id');   // ✅ get data-id correctly
        Delete(Emp_Id);
    });

    function Delete(Emp_Id) {
        if (confirm("Are you sure, you want to delete this Record?")) {
            $.ajax({
                url: '/Home/DeleteEmployee', // ✅ cleaner URL
                type: 'POST',
                data: { Emp_Id: Emp_Id },   // ✅ send parameter properly
                success: function (response) {
                    alert(response.message || "Record deleted successfully.");
                    getList();
                },
                error: function () {
                    alert("Error while deleting record.");
                }
            });
        }
    }





    // Handle Edit button click
    $(document).on("click", ".edit-icon", function () {
        var Emp_Id = $(this).data("id");
        Edit(Emp_Id);
    });

    // Edit function
    function Edit(Emp_Id) {
        window.location.href = '/Home/UpdateEmployee?Emp_Id=' + Emp_Id;
    }









});