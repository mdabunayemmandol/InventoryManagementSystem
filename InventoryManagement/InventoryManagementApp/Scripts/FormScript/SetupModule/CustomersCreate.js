$(document).ready(function () {
    loadDatatable();
});

$(document.body).on("click", "#btnSubmit", function () {
    var vm = {};
    var id = $("#Id").val();
    vm.customerName = $("#CustomerName").val();
    vm.address = $("#Address").val();
    vm.mobile = $("#Mobile").val();
    vm.email = $("#Email").val();

    if ($("#IsActive:checked").val().length > 0) {
        vm.isActive = true;
    } else {
        vm.isActive = false;
    }

    if (vm.code == "") {
        toastr.warning("Code Must Not Be Empty", "Warning!!!");
        return;
    }

    if (id == 0 || id == "" || id == null) {
        $.ajax({
            url: "/api/Customers",
            data: vm,
            type: "POST",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Save Success", "Success!!!");
                    loadDatatable();

                    refreshForm();

                } else {
                    toastr.warning("Save Fail", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    }
    else {
        vm.id = id;

        $.ajax({
            url: "/api/Customers/" + id,
            data: vm,
            type: "PUT",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Update Success", "Success!!!");
                    loadDatatable();

                    refreshForm();

                } else {
                    toastr.warning("Update Fail", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    }
});

function refreshForm() {
    $("#Id").val("");
    $("#CustomerName").val("");
    $("#Address").val("");
    $("#Mobile").val("");
    $("#Email").val("");

    if (!($("#IsActive:checked").length > 0)) {
        $("#IsActive").prop('checked', true);
        $(".icheckbox_minimal-blue").addClass('checked').attr('aria-checked', 'true');
    }
}

function loadDatatable() {
    $("#customerHistory").DataTable().destroy();
    $("#customerHistory").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/Customers",
            dataSrc: ""
        },
        columns: [
            {
                data: "customerName"
            },
            {
                data: "address"
            },
            {
                data: "mobile"
            },
            {
                data: "email"
            },
            {
                data: "isActive",
                render: function (data) {
                    if (data) {
                        return "Active";
                    } else {
                        return "DeActive";
                    }
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class = 'btn btn-info btn-sm js-edit' data-id = " + data + "><i class ='fa fa-pencil-square fa-2x' aria-hidden='false'></i></a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn-link js-delete' data-id=" + data + "><i class='fa fa-trash fa-2x' aria-hidden='true' style='color:#d9534f;'></i></a>";
                }
            }
        ]
    });
}

$(document.body).on("click", ".js-edit", function () {
    refreshForm();
    var button = $(this);
    var id = button.attr("data-id");

    getData(id);

});

function getData(id) {
    $.get("/api/Customers?id=" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            $("#CustomerName").val(data.customerName);
            $("#Address").val(data.address);
            $("#Mobile").val(data.mobile);
            $("#Email").val(data.email);

            if (data.isActive == 1) {
                $("#IsActive").prop('checked', true);
                $(".icheckbox_minimal-blue").addClass('checked').attr('aria-checked', 'true');
            }
            else {
                $("#IsActive").prop('checked', false);
                $(".icheckbox_minimal-blue").removeClass('checked').attr('aria-checked', 'false');
            }

        });
}

$(document.body).on("click", ".js-delete", function () {
    var button = $(this);
    var id = button.attr("data-id");
    bootbox.confirm("Are You Delete This Data?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/Customers/" + id,
                    method: "DELETE",
                    success: function () {
                        button.parents("tr").remove();
                        toastr.success("Delete Success");
                    },
                    error: function (request, status, error) {
                        var response = jQuery.parseJSON(request.responseText);
                        toastr.error(response.message, "Error");
                    }
                });
            }
        });
});