using MilitarySuplierFilesConsoleApp.Helpers;
using MilitarySuplierFilesConsoleApp.Models;
using MilitarySuplierFilesConsoleApp.Services;
using Moq;

namespace MilitarySuplierFilesConsoleAppTests.Services.Supplier2
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
        private Supplier2Service _supplierService;

        [SetUp]
        public void Setup()
        {
            _mockFileWrapper = new Mock<IFileWrapper>();
            _supplierService = new Supplier2Service(_mockFileWrapper.Object);
        }

        [Test]
        public void GetFinalProducts_WithValidPaths_ReturnsCorrectFinalProducts()
        {
            // Arrange
            string path1 = "dummyPath1.xml";
            string path2 = "dummyPath2.xml";

            string xmlContent1 = Files.file1;
            string xmlContent2 = Files.file2;

            _mockFileWrapper.Setup(fw => fw.ReadTextFromFile(path1)).Returns(xmlContent1);
            _mockFileWrapper.Setup(fw => fw.ReadTextFromFile(path2)).Returns(xmlContent2);

            // Act
            List<FinalProduct> result = _supplierService.GetFinalProducts(path1, path2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Pędzelek Lens Pen", result[0].Name);
            Assert.AreEqual(6, result[0].stockQuantity);
            Assert.AreEqual(5, result[0].ImgUrls.Count);
            Assert.AreEqual("https://b2b.deltaoptical.pl/zasoby/import/l/lens-pen_4_1_2.jpg", result[0].ImgUrls[0]);
        }
    }
}
