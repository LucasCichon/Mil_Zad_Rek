using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier2;


    [XmlRoot(ElementName = "products")]
    public class Products
    {
        [XmlAttribute(AttributeName = "elments")]
        public int Elements { get; set; }

        [XmlAttribute(AttributeName = "clientid")]
        public int ClientId { get; set; }

        [XmlAttribute(AttributeName = "lang")]
        public string Language { get; set; }

        [XmlAttribute(AttributeName = "datetime")]
        public string DateTime { get; set; }

        [XmlElement(ElementName = "product")]
        public List<Product> ProductList { get; set; }

        [XmlAttribute(AttributeName = "template")]
        public int Template { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }
    }

    public class Product
    {
        [XmlElement(ElementName = "ean")]
        public string EAN { get; set; }

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "sku")]
        public string SKU { get; set; }

        [XmlElement(ElementName = "inStock")]
        public string InStock { get; set; }

        [XmlElement(ElementName = "qty")]
        public int Quantity { get; set; }

        [XmlElement(ElementName = "availability")]
        public string Availability { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "desc")]
        public string Description { get; set; }

        [XmlElement(ElementName = "url")]
        public string URL { get; set; }

        [XmlArray(ElementName = "categories")]
        [XmlArrayItem(ElementName = "category")]
        public List<Category> Categories { get; set; }

        [XmlElement(ElementName = "attributes")]
        public string Attributes { get; set; }

        [XmlElement(ElementName = "unit")]
        public string Unit { get; set; }

        [XmlElement(ElementName = "weight")]
        public string Weight { get; set; }

        [XmlElement(ElementName = "PKWiU")]
        public string PKWiU { get; set; }

        [XmlElement(ElementName = "requiredBox")]
        public string RequiredBox { get; set; }

        [XmlElement(ElementName = "quantityPerBox")]
        public int QuantityPerBox { get; set; }

        [XmlElement(ElementName = "priceAfterDiscountNet")]
        public string PriceAfterDiscountNet { get; set; }

        [XmlElement(ElementName = "vat")]
        public int VAT { get; set; }

        [XmlElement(ElementName = "retailPriceGross")]
        public string RetailPriceGross { get; set; }

        [XmlArray(ElementName = "photos")]
        [XmlArrayItem(ElementName = "photo")]
        public List<Photo> Photos { get; set; }
    }
    public class Category
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Name { get; set; }
    }

    public class Photo
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "main")]
        public int Main { get; set; }

        [XmlText]
        public string URL { get; set; }
    }

