using MilitarySuplierFilesConsoleApp.Helpers;
using MilitarySuplierFilesConsoleApp.Models;
using MilitarySuplierFilesConsoleApp.Services;
using Moq;

namespace MilitarySuplierFilesConsoleAppTests.Services.Supplier3
{
    public class FileWrapper : IFileWrapper
    {
        public string ReadTextFromFile(string path)
        {
            return File.ReadAllText(path);
        }
    }

    [TestFixture]
    public class Supplier1ServiceTests
    {
        private Mock<IFileWrapper> _mockFileWrapper;
        private Supplier3Service _supplierService;

        [SetUp]
        public void Setup()
        {
            _mockFileWrapper = new Mock<IFileWrapper>();
            _supplierService = new Supplier3Service(_mockFileWrapper.Object);
        }

        [Test]
        public void GetFinalProducts_WithValidPaths_ReturnsCorrectFinalProducts()
        {
            // Arrange
            string path1 = "dummyPath1.xml";
            string path2 = "dummyPath2.xml";

            string xmlContent1 = Files.file1;
           
            _mockFileWrapper.Setup(fw => fw.ReadTextFromFile(path1)).Returns(xmlContent1);

            // Act
            List<FinalProduct> result = _supplierService.GetFinalProducts(path1, path2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Softshell Falcon grey M", result[0].Name);
            Assert.AreEqual(0, result[0].stockQuantity);
            Assert.AreEqual(1, result[0].ImgUrls.Count);
            Assert.AreEqual("https://texar.info.pl/img/towary/1/2019_03/softshell-falcon-grey.jpg", result[0].ImgUrls[0]);
        }
    }
}
