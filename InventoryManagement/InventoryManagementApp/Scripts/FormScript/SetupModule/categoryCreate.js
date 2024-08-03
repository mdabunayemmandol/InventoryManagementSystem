$(document).ready(function () {
    //alert("It's Worked");
    loadDatatable();
});

$(document.body).on("click", "#btnSubmit", function () {
    var vm = {};
    var id = $("#Id").val();
    vm.name = $("#Name").val();

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
            url: "/api/Categorys",
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
            url: "/api/Categorys/" + id,
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
    $("#Name").val("");

    if (!($("#IsActive:checked").length > 0)) {
        $("#IsActive").prop('checked', true);
        $(".icheckbox_minimal-blue").addClass('checked').attr('aria-checked', 'true');
    }
}


function loadDatatable() {
    $("#categoryHistory").DataTable().destroy();
    $("#categoryHistory").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/Categorys",
            dataSrc: ""
        },
        columns: [
            {
                data: "name"
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
    $.get("/api/Categorys?id=" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            $("#Name").val(data.name);

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
                    url: "/api/Categorys/" + id,
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