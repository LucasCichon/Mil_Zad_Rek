using System.Xml.Serialization;

namespace MilitarySuplierFilesConsoleApp.Dtos.suplier3
{
    [XmlRoot(ElementName = "produkty")]
    public class Produkty
    {
        [XmlElement(ElementName = "produkt")]
        public List<Produkt> ProduktyList { get; set; }
    }

    public class Produkt
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "nazwa")]
        public string Nazwa { get; set; }

        [XmlElement(ElementName = "nazwa_pl")]
        public string NazwaPl { get; set; }

        [XmlElement(ElementName = "nazwa_en")]
        public string NazwaEn { get; set; }

        [XmlElement(ElementName = "dlugi_opis")]
        public string DlugiOpis { get; set; }

        [XmlElement(ElementName = "dlugi_opis_pl")]
        public string DlugiOpisPl { get; set; }

        [XmlElement(ElementName = "dlugi_opis_en")]
        public string DlugiOpisEn { get; set; }

        [XmlElement(ElementName = "kod")]
        public string Kod { get; set; }

        [XmlElement(ElementName = "ean")]
        public string EAN { get; set; }

        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "cena_zewnetrzna_hurt")]
        public string CenaZewnetrznaHurt { get; set; }

        [XmlElement(ElementName = "cena_sugerowana")]
        public string CenaSugerowana { get; set; }

        [XmlElement(ElementName = "kod_dostawcy")]
        public string KodDostawcy { get; set; }

        [XmlElement(ElementName = "vat")]
        public string Vat { get; set; }

        [XmlElement(ElementName = "rozmiar")]
        public string Rozmiar { get; set; }

        [XmlElement(ElementName = "kolor")]
        public string Kolor { get; set; }

        [XmlElement(ElementName = "cat")]
        public string Cat { get; set; }

        [XmlElement(ElementName = "cat_pl")]
        public string CatPl { get; set; }

        [XmlElement(ElementName = "cat_en")]
        public string CatEn { get; set; }

        [XmlArray(ElementName = "zdjecia")]
        [XmlArrayItem(ElementName = "zdjecie")]
        public List<Zdjecie> Zdjecia { get; set; }
    }

    public class Zdjecie
    {
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }
}
