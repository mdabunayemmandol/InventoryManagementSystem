$(document).ready(function () {
    PurchaseNo();
    loadSupplier();
    loadDatatable();
});

function PurchaseNo() {
    $.get("/api/Purchasemusters/GetPurchaseNo",
        function (data) {
            $("#PurchaseNo").val(data);
        });
}

function loadSupplier() {
    $.get("/api/Suppliers", function (data) {
        var $el = $("#SupplierId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>',
                {
                    value: key.id,
                    text: key.supplierName
                }));
        });
    });

}

$(document.body).on("click", "#btnSubmit", function () {
    var vm = {};
    var id = $("#Id").val();
    vm.purchaseNo = $("#PurchaseNo").val();
    vm.supplierId = $("#SupplierId").val();
    vm.date = $("#Date").val();
    vm.remark = $("#Remark").val();

    if (vm.code == "") {
        toastr.warning("Code Must Not Be Empty", "Warning!!!");
        return;
    }

    if (id == 0 || id == "" || id == null) {
        $.ajax({
            url: "/api/Purchasemusters",
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
            url: "/api/Purchasemusters/" + id,
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
    $("#PurchaseNo").val("");
    $("#SupplierId").val("");
    $("#Date").val("");
    $("#Remark").val("");
}

function loadDatatable() {
    $("#purchasemusterHistory").DataTable().destroy();
    $("#purchasemusterHistory").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/Purchasemusters",
            dataSrc: ""
        },
        columns: [
            {
                data: "purchaseNo"
            },
            {
                data: "supplierId"
            },
            {
                data: "date"
            },
            {
                data: "remark"
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
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn-link js-report' data-id=" + data + "><i class='fa fa-file-pdf-o fa-2x' aria-hidden='true' style='color:#d9534f;'></i></a>";
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
    $.get("/api/Purchasemusters?id=" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            $("#PurchaseNo").val(data.purchaseNo);
            $("#SupplierId").val(data.supplierId);
            $("#Date").val(data.date);
            $("#Remark").val(data.remark);
  
        });
}

$(document.body).on("click", ".js-delete", function () {
    var button = $(this);
    var id = button.attr("data-id");
    bootbox.confirm("Are You Delete This Data?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/Purchasemusters/" + id,
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


$(document.body).on("click",
    ".js-report",
    function () {

        var button = $(this);
        var salesId = button.attr("data-id");

        $.ajax({
            url: "/Purchasemuster/GetPurchaseReport?purchaseId=" + salesId,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data != "" && data != null) {
                    setTimeout(function () {
                        $("#pdf").attr("href", data);
                        var reportBox = $("#pdf").fancybox({
                            'frameWidth': 85,
                            'frameHeight': 495,
                            'overlayShow': true,
                            'hideOnContentClick': false,
                            'type': 'iframe',
                            helpers: {
                                // prevents closing when clicking OUTSIDE fancybox
                                overlay: { closeClick: false }
                            }
                        }).trigger('click');
                    }, 1000);
                }
            }
        });


    });