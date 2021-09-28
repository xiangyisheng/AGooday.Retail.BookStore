var l = abp.localization.getResource('AbpIdentity');

/* Entity Action Extensions for ASP.NET Core UI */
var clickMeAction = {
    text: 'Click Me!',
    action: function (data) {
        //TODO: Write your custom code
        alert(data.record.userName);
    }
};

abp.ui.extensions.entityActions
    .get('identity.user')
    .addContributor(function (actionList) {
        console.log(actionList);
        actionList.addTail(clickMeAction);
    });

var clickMe2Action = {
    text: 'Click Me 2!',
    icon: 'fas fa-hand-point-right',
    action: function (data) {
        //TODO: Write your custom code
        alert(data.record.userName);
    }
};

abp.ui.extensions.entityActions
    .get('identity.user')
    .addContributor(function (actionList) {
        // Remove an item from actionList
        // actionList.dropHead();

        // Add the new item to the actionList
        actionList.addHead(clickMe2Action);
    });
/* End Entity Action Extensions for ASP.NET Core UI */

/* Data Table Column Extensions for ASP.NET Core UI */
abp.ui.extensions.tableColumns
    .get('identity.user')
    .addContributor(function (columnList) {
        console.log(columnList);

        columnList.addTail({ //add as the last column
            title: 'Phone confirmed?',
            data: 'phoneNumberConfirmed',
            render: function (data, type, row) {
                console.log({ data, type, row });
                if (row.phoneNumberConfirmed) {
                    return '<strong style="color: green">YES<strong>';
                } else {
                    return '<i class="text-muted">NO</i>';
                }
            }
        });

        columnList.addManyTail([ //add many last column
            {
                title: 'Social security no',
                data: 'extraProperties.SocialSecurityNumber',
                orderable: false,
                render: function (data, type, row) {
                    if (row.extraProperties.SocialSecurityNumber) {
                        return '<strong>' +
                            row.extraProperties.SocialSecurityNumber +
                            '<strong>';
                    } else {
                        return '<i class="text-muted">undefined</i>';
                    }
                }
            },
            {
                title: 'Custom column' + l('PhoneNumber'),
                data: {},
                orderable: false,
                render: function (data) {
                    if (data.phoneNumber) {
                        return "call: " + data.phoneNumber;
                    } else {
                        return '';
                    }
                }
            }
        ]);
    });

var myColumnDefinition = {
    title: 'Email confirmed?',
    data: 'emailConfirmed',
    render: function (data, type, row) {
        if (row.emailConfirmed) {
            return '<strong style="color: green">YES<strong>';
        } else {
            return '<i class="text-muted">NO</i>';
        }
    }
};

abp.ui.extensions.tableColumns
    .get('identity.user')
    .addContributor(function (columnList) {
        // Remove an item from actionList
        // columnList.dropHead();

        // Add a new item to the actionList
        //columnList.addHead(myColumnDefinition);

        columnList.addTail(myColumnDefinition);
    }, 1);
/* End Data Table Column Extensions for ASP.NET Core UI */

/* Page Toolbar Extensions for ASP.NET Core UI */
$(function () {
    $('#ImportUsersFromExcel').click(function (e) {
        e.preventDefault();
        alert('TODO: import users from excel');
    });
});
/* End Page Toolbar Extensions for ASP.NET Core UI */