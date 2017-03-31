$(document).ready(function () {


    var organizationId = $('#OrganizationId').val();

    var jsonData = { id: organizationId };
    $.ajax({
        url: '/Loader/GetOrganizationById?id=' + organizationId,
        contentType: 'application/json',
        data: JSON.stringify(jsonData),
        success: function (organization) {
            console.log(organization.Id);
            
            var organizationName = organization.Name;
            

            $('#Organization').text(organizationName);
           
        }

    });
});