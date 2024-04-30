namespace B2B_Deneme.ViewModels
{
    public class SiparisView
    {
        public string Stok { get; set; }
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; }
        public decimal Toplam { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public string CariKod { get; set; }
        public int SipSira { get; set; }
        public string SipSeri { get; set; }
        public int Statu { get; set; }
    }
}
