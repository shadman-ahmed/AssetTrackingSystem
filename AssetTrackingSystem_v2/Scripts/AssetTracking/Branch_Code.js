
    $(document).ready(function () {
        
        /* Global variable */
        var OrganizationShortName;

        /* Automatic Code generation from organization and shortname field */
        $('#OrganizationId').change(function() {
                
            var organizationId = $('#OrganizationId').val();
            //var branchShortName = $('#ShortName').val();

            var jsonData = { id: organizationId };
            $.ajax({
                url: '/Loader/GetOrganizationById?id=' + organizationId,
                contentType: 'application/json',
                data: JSON.stringify(jsonData),
                success: function (organization) {

                    OrganizationShortName = organization.ShortName;// + "_" + branchShortName;
                    $('#Code').val(OrganizationShortName);
                }

            });
        });

        $('#ShortName').keyup(function () {
            var shortName = $('#ShortName').val();
            $('#Code').val(OrganizationShortName + "_" + shortName);
        });

    });