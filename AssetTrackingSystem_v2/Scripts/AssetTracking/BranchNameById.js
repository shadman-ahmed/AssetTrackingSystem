$(document).ready(function () {


    var branchId = $('#BranchId').val();

    var jsonData = { id: branchId };
    $.ajax({
        url: '/Loader/GetOrganizationById?id=' + branchId,
        contentType: 'application/json',
        data: JSON.stringify(jsonData),
        success: function (branch) {
            console.log(branch.Id);

            var branchName = branch.Name;


            $('#Branch').text(branchName);

        }

    });
});