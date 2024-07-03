using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier1;
[XmlRoot("offer")]
    public class Offer
    {
        [XmlAttribute("file_format")]
        public string FileFormat { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("generated")]
        public string Generated { get; set; }

        [XmlElement("products")]
        public Products Products { get; set; }
    }

    public class Products
    {
        [XmlAttribute("currency")]
        public string Currency { get; set; }

        [XmlElement("product")]
        public List<Product> ProductList { get; set; }
    }

    public class Product
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("price")]
        public Price Price { get; set; }

        [XmlElement("srp")]
        public Price Srp { get; set; }

        [XmlElement("sizes")]
        public Sizes Sizes { get; set; }

        [XmlElement("description")]
        public Description description { get; set; }
        [XmlElement(ElementName = "images")]
        public Images Images { get; set; }
        [XmlElement(ElementName = "warranty")]
        public Warranty Warranty { get; set; }
    }

    public class Warranty
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "type", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "period", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
        public int Period { get; set; }
    }

    public class Images
    {
        [XmlElement(ElementName = "large")]
        public LargeImage LargeImages { get; set; }

        [XmlElement(ElementName = "icons")]
        public Icons Icons { get; set; }

        [XmlElement(ElementName = "iaiext:originals", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
        public Originals Originals { get; set; }
    }


    public class LargeImage
    {
        [XmlElement(ElementName ="image")]
        public List<Image> Images { get; set; }
    }

    public class Image
    {
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [XmlAttribute(AttributeName = "url2", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
        public string Url2 { get; set; }

        [XmlAttribute(AttributeName = "date_changed")]
        public string DateChanged { get; set; }

        [XmlAttribute(AttributeName = "hash")]
        public string Hash { get; set; }

        [XmlAttribute(AttributeName = "width", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
        public int Width { get; set; }

        [XmlAttribute(AttributeName = "height", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
        public int Height { get; set; }
    }

    public class Icons
    {
        [XmlElement(ElementName = "icon")]
        public List<Icon> IconList { get; set; }
    }

    public class Icon
    {
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [XmlAttribute(AttributeName = "url2", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
        public string Url2 { get; set; }

        [XmlAttribute(AttributeName = "date_changed")]
        public string DateChanged { get; set; }

        [XmlAttribute(AttributeName = "hash")]
        public string Hash { get; set; }

        [XmlAttribute(AttributeName = "width", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
        public int Width { get; set; }

        [XmlAttribute(AttributeName = "height", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
        public int Height { get; set; }
    }

    public class Originals
    {
        [XmlElement(ElementName = "iaiext:image", Namespace = "http://www.iai-shop.com/developers/iof/extensions.phtml")]
        public List<OriginalImage> OriginalImages { get; set; }
    }

    public class OriginalImage
    {
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [XmlAttribute(AttributeName = "width")]
        public int Width { get; set; }

        [XmlAttribute(AttributeName = "height")]
        public int Height { get; set; }
    }

    public class Price
    {
        [XmlAttribute("gross")]
        public decimal Gross { get; set; }

        [XmlAttribute("net")]
        public decimal Net { get; set; }

        [XmlAttribute("vat")]
        public decimal Vat { get; set; }
    }

    public class Sizes
    {
        [XmlElement("size")]
        public List<Size> SizeList { get; set; }
    }

    public class Size
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("code_producer")]
        public string CodeProducer { get; set; }

        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("weight")]
        public decimal Weight { get; set; }

        [XmlElement("stock")]
        public Stock Stock { get; set; }
    }

    public class Stock
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("quantity")]
        public int Quantity { get; set; }
    }

    public class Description
    {
        [XmlElement(ElementName = "name")]
        public List<Name> Names { get; set; }

        [XmlElement(ElementName = "version")]
        public Version Version { get; set; }

        [XmlElement(ElementName = "long_desc")]
        public List<LongDesc> LongDescs { get; set; }

        [XmlElement(ElementName = "short_desc")]
        public List<ShortDesc> ShortDescs { get; set; }
    }

    public class Name
    {
        [XmlAttribute(AttributeName = "xml:lang")]
        public string Lang { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class LongDesc
    {
        [XmlAttribute(AttributeName = "xml:lang")]
        public string Lang { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class ShortDesc
    {
        [XmlAttribute(AttributeName = "xml:lang")]
        public string Lang { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class Position
    {
        [XmlAttribute("xml:lang")]
        public string lang { get; set; }
        [XmlAttribute("__cdata")]
        public string data { get; set; }
    }


