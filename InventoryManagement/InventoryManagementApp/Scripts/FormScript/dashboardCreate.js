$(document).ready(function () {

    dataLoad();

});


function dataLoad() {
    $.get("/api/DashBoards/GetData", function (data) {
        $("#TotalPurchase").text(data.totalPurchase);
        $("#TotalSales").text(data.totalSales);
        $("#TotalCustomer").text(data.totalCustomer);
        $("#TotalSupplier").text(data.totalSupplier);


    });
}

//function SalesNo() {
//    $.get("/api/Sales/GetSalesNo",
//        function (data) {
//            $("#SalesNo").val(data);
//        });
//}