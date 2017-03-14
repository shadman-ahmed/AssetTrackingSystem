$(document).ready(function () {

    $('#BranchId, #ShortName').change(function () {

        var branchId = $('#BranchId').val();
        var locationShortName = $('#ShortName').val();

        var jsonData = { id: branchId };
        $.ajax({
            url: '/Location/GetBranchById?id=' + branchId,
            contentType: 'application/json',
            data: JSON.stringify(jsonData),
            success: function (branch) {
                console.log(branch.Id);
                var Code = branch.Code + "_" + locationShortName;
                $('#Code').val(Code);
            }

        });
    });

    $('#Code').FOCUS(function () {
        var branchId = $('#BranchId').val();
        var branchShortName = $('#ShortName').val();

        var jsonData = { id: branchId };
        $.ajax({
            url: '/Location/GetBranchById?id=' + branchId,
            contentType: 'application/json',
            data: JSON.stringify(jsonData),
            success: function (branch) {
                var Code = branch.Code + "_" + locationShortName;
                $('#Code').val(Code);
            }

        });
    });

});