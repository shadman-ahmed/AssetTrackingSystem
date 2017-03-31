$(document).ready(function () {

    var categoryId = $('#CategoryId').val();

    var jsonData = { id: categoryId };

    $.ajax({
        url: '/Loader/GetCategoryById?id=' + categoryId,
        contentType: 'application/json',
        data: JSON.stringify(jsonData),
        success: function (category) {
            console.log(category.Id);

            var categoryName = category.Name;


            $('#category').text(categoryName);

        }

    });
});