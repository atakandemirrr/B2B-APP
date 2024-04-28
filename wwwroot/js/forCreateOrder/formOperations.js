
/*siprariş formu için 08.04.2024 tarihind Atakan yaptı*/


/*stok seçildiğinde kullanılan*/
$(document).ready(function () {
    $("#stockSelect").change(function () {
        var stockCode = $(this).val();

        if (stockCode.trim() !== '') {
            $.get("/Order/ProductSelection", { stockCode: stockCode }, function (data) {

                $("#stockPrice").val(data);
            });
        } else {
            // Seçilen değer boş ise, fiyat alanını temizle
            $("#stockPrice").val('');
        }
    });
})





