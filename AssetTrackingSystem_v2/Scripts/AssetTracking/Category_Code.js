
$(document).ready(function () {

    /* Automatic Code generation from general category and shortname field */
    $('#GeneralCategoryId, #ShortName').change(function () {

        var generalCategoryId = $('#GeneralCategoryId').val();
        var CategoryShortName = $('#ShortName').val();

        var jsonData = { id: generalCategoryId };
        $.ajax({
            url: '/Loader/GetgeneralCategoryById?id=' + generalCategoryId,
            contentType: 'application/json',
            data: JSON.stringify(jsonData),
            success: function (generalCategory) {
                console.log(generalCategory.Id);
                var Code = generalCategory.ShortName + "_" + CategoryShortName;
                $('#Code').val(Code);
            }

        });
    });

    $('#Code').FOCUS(function () {
        var generalCategoryId = $('#GeneralCategoryId').val();
        var CategoryShortName = $('#ShortName').val();

        var jsonData = { id: generalCategoryId };
        $.ajax({
            url: '/Loader/GetgeneralCategoryById?id=' + generalCategoryId,
            contentType: 'application/json',
            data: JSON.stringify(jsonData),
            success: function (generalCategory) {
                var Code = generalCategory.ShortName + "_" + CategoryShortName;
                $('#Code').val(Code);
            }

        });
    });

});