$(document).ready(function () {

    var manufacturerId = $('#ManufacturerId').val();

    var jsonData = { id: manufacturerId };

    $.ajax({
        url: '/Loader/GetManufacturerById?id=' + manufacturerId,
        contentType: 'application/json',
        data: JSON.stringify(jsonData),
        success: function (manufacturer) {
            console.log(manufacturer.Id);

            var manufacturerName = manufacturer.Name;


            $('#manufacturer').text(manufacturerName);

        }

    });
});