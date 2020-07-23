$(document).ready(function () {

    $(".click").click(function () {

        var proName = $("#ProductName").val;
        var proBarcode = $("#ProductBarcode").val;
        var proExpiry = $("#exdatePicker").val;
        var proCartons = $("#cartonTxt").val;
        var proPerCart = $("#piecesTxt").val;
        var proBuying = $("#buyingTxt").val;

        var code = "<tr><td><input type='checkbox' name='chk'/></td><td>" + proName + "</td><td>" + proBarcode + "</td><td>" + proExpiry + "</td><td>" + proCartons + "</td><td>" + proPerCart + "</td><td>" + proBuying + "</td></tr>";

        $("table tbody").append(code);

    });

});