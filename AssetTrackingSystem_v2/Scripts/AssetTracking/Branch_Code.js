
    $(document).ready(function () {
            
        /* Automatic Code generation from organization and shortname field */
        $('#OrganizationId, #ShortName').change(function() {
                
            var organizationId = $('#OrganizationId').val();
            var branchShortName = $('#ShortName').val();

            var jsonData = { id: organizationId };
            $.ajax({
                url: '/Loader/GetOrganizationById?id=' + organizationId,
                contentType: 'application/json',
                data: JSON.stringify(jsonData),
                success: function (organization) {
                    console.log(organization.Id);
                    var Code = organization.ShortName + "_" + branchShortName;
                    $('#Code').val(Code);
                }

            });
        });

        $('#Code').FOCUS(function() {
            var organizationId = $('#OrganizationId').val();
            var branchShortName = $('#ShortName').val();

            var jsonData = { id: organizationId };
            $.ajax({
                url: '/Loader/GetOrganizationById?id=' + organizationId,
                contentType: 'application/json',
                data: JSON.stringify(jsonData),
                success: function(organization) {
                    var Code = organization.ShortName + "_" + branchShortName;
                    $('#Code').val(Code);
                }

            });
        });

    });