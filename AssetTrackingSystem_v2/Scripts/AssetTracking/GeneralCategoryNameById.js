$(document).ready(function () {

    var generalCategoryId = $('#GeneralCategoryId').val();

    var jsonData = { id: generalCategoryId };

    $.ajax({
        url: '/Loader/GetGeneralCategoryById?id=' + generalCategoryId,
        contentType: 'application/json',
        data: JSON.stringify(jsonData),
        success: function (generalCategory) {
            console.log(generalCategory.Id);

            var generalCategoryName = generalCategory.Name;


            $('#GeneralCategory').text(generalCategoryName);

        }

    });
});