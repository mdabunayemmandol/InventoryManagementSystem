﻿$(document).ready(function () {
    loadSale();
    loadItem();
    //loadDatatable();

});

$("#SaleId").change(function () {

    var id = $("#SaleId").val();

    $.get("/api/Sales?id=" + id,

        function (data) {
            $("#SalesNo").val(data.salesNo);
            $("#CustomerName").val(data.customer.customerName);
        });

    loadDatatable(id);

});
function loadSale() {
    $.get("/api/Sales", function (data) {
        var $el = $("#SaleId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>',
                {
                    value: key.id,
                    text: key.salesNo
                }));
        });
    });

}

function loadItem() {
    $.get("/api/Items", function (data) {
        var $el = $("#ItemId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>',
                {
                    value: key.id,
                    text: key.itemsName
                }));
        });
    });
}

$("#ItemId").change(function () {

    var id = $("#ItemId").val();

    $.get("/api/Items?id=" + id,

        function (data) {
            $("#Price").val(data.salePrice);
        });

});

$("#Quantity").keyup(function () {
    var quantity = $("#Quantity").val();
    var price = $("#Price").val();

    var totalPrice = quantity * price;

    $("#TotalPrice").val(totalPrice);

});

$(document.body).on("click", "#btnSubmit", function () {
    var vm = {};
    var id = $("#Id").val();
    vm.saleId = $("#SaleId").val();
    vm.itemId = $("#ItemId").val();
    vm.price = $("#Price").val();
    vm.quantity = $("#Quantity").val();
    vm.totalPrice = $("#TotalPrice").val();
    vm.remark = $("#Remark").val();

    if (vm.code == "") {
        toastr.warning("Code Must Not Be Empty", "Warning!!!");
        return;
    }

    if (id == 0 || id == "" || id == null) {
        $.ajax({
            url: "/api/Salesdetails",
            data: vm,
            type: "POST",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Save Success", "Success!!!");
                    refreshForm();
                    loadDatatable(vm.saleId);

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
            url: "/api/Salesdetails/" + id,
            data: vm,
            type: "PUT",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Update Success", "Success!!!");
                    loadDatatable(vm.saleId);

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
    $("#ItemId").val("");
    $("#Price").val("");
    $("#Quantity").val("");
    $("#TotalPrice").val("");
    $("#Remark").val("");
}

function loadDatatable(saleId) {
    $("#salesdetailHistory").DataTable().destroy();
    $("#salesdetailHistory").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/Salesdetails/GetBySaleId?saleId=" + saleId,
            dataSrc: ""
        },
        columns: [
            {
                data: "item.itemsName"
            },
            {
                data: "price"
            },
            {
                data: "quantity"
            },
            {
                data: "totalPrice"
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
    $.get("/api/Salesdetails?id=" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            $("#SaleId").val(data.saleId);
            $("#ItemId").val(data.itemId);
            $("#Price").val(data.price);
            $("#Quantity").val(data.quantity);
            $("#TotalPrice").val(data.totalPrice);
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
                    url: "/api/Salesdetails/" + id,
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