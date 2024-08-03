var dtlRowCount = 1;

$(document.body).ready(function () {
    generateVoucher();

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
    purchasemstload() ;
    getEmptyDtlTable();  
})

function purchasemstload() {
    $.get("/api/Purchasemst", function (data) {
        var $el = $("#InvId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>', {
                value: key.id,
                text: key.purchasemstNo
            }));
        });
    });

}
$(document.body).on("change", "#ItemId", function () {
    // Refresh All Dropdown
    var itemId = $("#ItemId").val();
    if (itemId > 0) {
        $.ajax({
            type: "GET",
            url: "/api/Items",
            contentType: "application/json; charset=utf-8",
            data: { id: itemId },
            success: function (data) {
                $("#Price").val(data.purchasePrice);
            }
        });
    }

});

$("#Weight").keyup(function () {

    var price = $("#Price").val();

    if (price > 0) {
        var quantity = $("#Weight").val();
        var total = price * quantity;
        $("#UnitPrice").val(total);
    }
});

$(document.body).on("change", "#SupplierId", function () {
    // Refresh All Dropdown
    var supplierId = $("#SupplierId").val();
    if (supplierId > 0) {
        $.ajax({
            type: "GET",
            url: "/api/Suppliers",
            contentType: "application/json; charset=utf-8",
            data: { id: supplierId },
            success: function (data) {
                $("#SearchName").val(data.supplierName);
                $("#SearchPhoneNo").val(data.mobile);
            }
        });
    }

});

function getEmptyDtlTable() {
    $("#dtlTable").DataTable().destroy();
    var t = $('#dtlTable').DataTable({
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [2],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [6],
                "data": null,
                "defaultContent":
                    "<a class='btn btn-info btn-sm js-dtlEdit'><i class='fa fa-edit' aria-hidden='true'></i></a>" +
                    "<a class='btn btn-danger btn-sm js-dtlDelete'><i class='fa fa-trash' aria-hidden='true'></i></a>"
            }
        ],
        "searching": false,
        "paging": false,
        "ordering": false,
        "info": false
    });
    t.clear().draw();
}

$(document.body).on("click", "#btnAdd", function () {
    var rowId = $("#dtlRowHiden").val();
    var dtlId = $("#dtlIdHiden").val();
    var itemId = $("#ItemId").val();
    var item = $("#ItemId option:selected").text();
    var price = $("#Price").val();
    var weight = $("#Weight").val();
    var unitPrice = $("#UnitPrice").val();

    if (itemId > 0) {
        var t = $('#dtlTable').DataTable();
        if (rowId > 0) {
            var temp = t.row(rowId - 1).data();
            temp[1] = dtlId;
            temp[2] = itemId;
            temp[3] = item;
            temp[4] = weight;
            temp[5] = unitPrice;
            temp[6] = price;
            $('#dtlTable').dataTable().fnUpdate(temp, rowId - 1, undefined, false);
        }
        else {
            t.row.add([
                dtlRowCount,
                dtlId,
                itemId,
                item,
                weight,
                unitPrice,
                price
            ]).draw(false);
        }
        refreshDtlInputFiled();
        var totalAmount = t.column(5).data().sum();
        $("#TotalBill").val(totalAmount);
        $("#PayAble").val(totalAmount);
        $("#PayAmount").val(totalAmount);
    }

});

function refreshDtlInputFiled() {
    $("#dtlRowHiden").val("");
    $("#dtlIdHiden").val(0);
    $("#ItemId").val('');
    $("#Item").val('');
    $("#Weight").val("");
    $("#UnitPrice").val("");
    $("#Price").val("");
}

$(document.body).on("click", ".js-dtlEdit", function () {
    var t = $('#dtlTable').DataTable();
    var data = t.row($(this).parents('tr')).data();
    $("#dtlRowHiden").val(data[0]);
    $("#dtlIdHiden").val(data[1]);
    var itemId = data[2];
    $("#ItemId").val(itemId);
    $("#Item").val(data[3]);
    $("#Weight").val(data[4]);
    $("#UnitPrice").val(data[5]);
    $("#Price").val(data[6]);
})

$(document.body).on("click", ".js-dtlDelete", function () {
    var button = $(this);
    var t = $('#dtlTable').DataTable();
    t.row(button.parents("tr")).remove().draw(false);
    toastr.success("Data successfully delete");
});

function generateVoucher() {
    $.get("/api/Purchasemst/GetVoucherNumber")
        .done(function (data) {
            $("#PurchasemstNo").val(data);
        });
}


$("#TransportCost").on("keyup change",
    function (e) {

        var transport = parseFloat($("#TransportCost").val());
        payable(transport);
    });
function payable(transport) {
    var totalBill = parseFloat($("#TotalBill").val());
    if (transport > 0) {
        totalBill = totalBill + transport;
    }
    $("#PayAble").val(totalBill);
    $("#PayAmount").val(totalBill);

};

$(document.body).on("click", "#btnSubmit", function () {

    var dto = {
        salesDetails: []
    };
    var id = $("#Id").val();
    dto.supplierId = $("#SupplierId").val();
    dto.purchasemstNo = $("#PurchasemstNo").val();
    dto.purchaseDate = $("#PurchaseDate").val();
    dto.totalBill = $("#TotalBill").val();
    dto.transportCost = $("#TransportCost").val();
    dto.payable = $("#Payable").val();
    dto.payAmount = $("#Payamount").val();

    var dtlTable = $('#dtlTable').DataTable();
    var dtls = dtlTable.rows().data();


    for (var r = 0; r < dtls.length; r++) {
        dto.salesDetails.push({
            id: dtls.cell(r, 1).data(),
            itemId: dtls.cell(r, 2).data(),
            quantity: dtls.cell(r, 4).data(),
            unitPrice: dtls.cell(r, 5).data()
        });
    }

    if (id == "" || id == 0 || id == null) {
        $.ajax({
            url: "/api/Purchasemst/",
            data: dto,
            type: "POST",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Data Save Success", "Success!!!");
                    refreshForm();
                    getEmptyDtlTable();
                    generateVoucher();
                    invoiceload();

                } else {
                    toastr.warning("Data Save Fail.", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.errorMassage, "Error");
            }
        });
    }
    else {
        dto.id = id;

        $.ajax({
            url: "/api/Purchasemst/" + id,
            data: dto,
            type: "PUT",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Data Update Success", "Success!!!");
                    refreshForm();
                    getEmptyDtlTable();
                    generateVoucher();

                } else {
                    toastr.warning("Data Update Fail.", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.errorMassage, "Error");
            }
        });
    }
});

function refreshForm() {
    $("#SupplierId").val("");
    $("#SupplierName").val("");
    $("#PhoneNo").val("");
    $("#TotalBill").val("");
    $("#TransportCost").val("");
    $("#PayAble").val("");
    $("#PayAmount").val("");
}