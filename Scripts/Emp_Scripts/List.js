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

            html += '</tr>';
        });
        $('#tblemployeebody').html(html);
    }
});