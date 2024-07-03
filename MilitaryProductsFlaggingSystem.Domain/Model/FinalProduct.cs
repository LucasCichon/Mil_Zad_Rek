
namespace MilitaryProductsFlaggingSystem.Domain.Model
{
    public class FinalProduct
    {
        private FinalProduct()
        {

        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public List<Description> Descriptions { get; private set; } = new List<Description>();
        public List<string> ImgUrls { get; private set; }
        public int stockQuantity { get; private set; }
        public bool isFlagged { get; private set; }

        public class Builder()
        {
            private string _id;
            private string _name;
            private List<Description> _descriptions = new List<Description>();
            private List<string> _imgUrl = new List<string>();
            private int _stockQuantity = 0;
            private bool _isFlagged = false;

            public Builder(string id) : this()
            {
                _id = id;
            }

            public void WithName(string name)
            {
                _name = name;
            }

            public void WithDescriptions(List<Description> descriptions)
            {
                _descriptions = descriptions;
            }

            public void WithImgUrls(List<string> imgUrls)
            {
                _imgUrl = imgUrls;
            }

            public void WithStockQuantity(int stockQuantity)
            {
                _stockQuantity = stockQuantity;
            }

            public void WithIsFlagged(bool isFlagged)
            {
                _isFlagged = isFlagged;
            }

            public FinalProduct Build()
            {
                return new FinalProduct()
                {
                    Id = _id,
                    Name = _name,
                    Descriptions = _descriptions,
                    ImgUrls = _imgUrl,
                    stockQuantity = _stockQuantity,
                    isFlagged = _isFlagged
                };
            }
        }
    }

    public class Description
    {
        public string Lang { get; set; }
        public string Desc { get; set; }
    }
}
