
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
});

/*adet değiştiğinde kullanılan*/
$(document).ready(function () {
    // Adet alanının değişimini dinle
    $("#quantity").on("input", function () {
        calculateTotal();
    });
        
    function calculateTotal() {

        var quantity = parseFloat($("#quantity").val());
        var stockPrice = parseFloat($("#stockPrice").val());

        // Eğer adet veya birim fiyat boşsa veya NaN ise, toplam alanını temizle
        if (isNaN(quantity) || isNaN(stockPrice)) {
            $("#total").val('');
            return;
        }

        // Toplamı hesapla ve total alanına yaz
        var total = quantity * stockPrice;
        $("#total").val(total.toFixed(2)); // İki ondalık basamakla sınırla
    }
});

//ekle butonuna tılayınca çalışan işlemler veritabanına kayıt işlemi yapılıyor.
$(document).ready(function () {
   /* const ekle = document.querySelector("#ekle");*/
    const liste = document.querySelector("#SipTable");

    ekle.onclick = function () {
        const stokSelect = document.querySelector("#stockSelect");
        const selectedOption = stokSelect.options[stokSelect.selectedIndex];
        const stok = selectedOption.textContent;
        const birimfiyat = document.querySelector("#stockPrice");
        const adet = document.querySelector("#quantity");
        const toplam = document.querySelector("#total");
        const CreateDate = document.querySelector("#CreDate");
        const UpdateDate = document.querySelector("#CreDate");
        const CariKod = document.querySelector("#CariKod");
        const SipSira = document.querySelector("#SipSira");
        const SipSeri = document.querySelector("#SipSeri");
        const Statu = document.querySelector("#Statu");

        var data = {
            stok: stokSelect.value,
            birimFiyat: birimfiyat.value,
            adet: adet.value,
            toplam: toplam.value,
            CreateDate: CreateDate.value,
            UpdateDate: UpdateDate.value,
            CariKod: CariKod.value,
            SipSira: SipSira.value,
            SipSeri: SipSeri.value,
            Statu: Statu.value

        };

        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/Order/CreateOrder", true);
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.send(JSON.stringify(data));



        //tablo satırları oluşuyor.
        let tr = document.createElement("tr");
        tr.innerHTML = "<td>" + stok + "</td><td>" + adet.value + "</td><td>" + birimfiyat.value + "</td><td>" + toplam.value + "</td><td><button id='silButton' readonly class='badge bg-danger text-white'>Sil</button></td>";
        liste.appendChild(tr);
        //alanları temizle
        stokSelect.value = "";
        birimfiyat.value = "";
        toplam.value = "";
        adet.value = "";

    }
});

////sil butonuna tılayınca çalışan işlemler veritabanındam silme işlemi yapılıyor.
//$(document).ready(function () {
//    /* const ekle = document.querySelector("#ekle");*/
//    const liste = document.querySelector("#SipTable");

//    ekle.onclick = function () {
//        const stokSelect = document.querySelector("#stockSelect");
//        const selectedOption = stokSelect.options[stokSelect.selectedIndex];
//        const stok = selectedOption.textContent;
//        const birimfiyat = document.querySelector("#stockPrice");
//        const adet = document.querySelector("#quantity");
//        const toplam = document.querySelector("#total");
//        const CreateDate = document.querySelector("#CreDate");
//        const UpdateDate = document.querySelector("#CreDate");
//        const CariKod = document.querySelector("#CariKod");
//        const SipSira = document.querySelector("#SipSira");
//        const SipSeri = document.querySelector("#SipSeri");
//        const Statu = document.querySelector("#Statu");

//        var data = {
//            stok: stokSelect.value,
//            birimFiyat: birimfiyat.value,
//            adet: adet.value,
//            toplam: toplam.value,
//            CreateDate: CreateDate.value,
//            UpdateDate: UpdateDate.value,
//            CariKod: CariKod.value,
//            SipSira: SipSira.value,
//            SipSeri: SipSeri.value,
//            Statu: Statu.value

//        };

//        var xhr = new XMLHttpRequest();
//        xhr.open("POST", "/Order/DeleteOrder", true);
//        xhr.setRequestHeader("Content-Type", "application/json");

//        xhr.send(JSON.stringify(data));



//        //tablo satırları oluşuyor.
//        let tr = document.createElement("tr");
//        tr.innerHTML = "<td>" + stok + "</td><td>" + adet.value + "</td><td>" + birimfiyat.value + "</td><td>" + toplam.value + "</td><td><button id='silButton' readonly class='badge bg-danger text-white'>Sil</button></td>";
//        liste.appendChild(tr);
//        //alanları temizle
//        stokSelect.value = "";
//        birimfiyat.value = "";
//        toplam.value = "";
//        adet.value = "";

//    }
//});








