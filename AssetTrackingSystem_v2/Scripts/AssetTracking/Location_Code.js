$(document).ready(function () {

    $('#OrganizationId, #BranchId, #ShortName').change(function () {
        $('#Code').val('');
        var branchId = $('#BranchId').val();
        var locationShortName = $('#ShortName').val();

        var jsonData = { id: branchId };
        $.ajax({
            url: '/Location/GetBranchById?id=' + branchId,
            contentType: 'application/json',
            data: JSON.stringify(jsonData),
            success: function (branch) {
                var code = branch.Code + "_" + locationShortName;
                $('#Code').val(code);
            }

        });
    });

    $('#Code').focus(function () {
        var branchId = $('#BranchId').val();
        var locationShortName = $('#ShortName').val();

        var jsonData = { id: branchId };
        $.ajax({
            url: '/Location/GetBranchById?id=' + branchId,
            contentType: 'application/json',
            data: JSON.stringify(jsonData),
            success: function (branch) {
                var code = branch.Code + "_" + locationShortName;
                $('#Code').val(code);
            }

        });
    });

});