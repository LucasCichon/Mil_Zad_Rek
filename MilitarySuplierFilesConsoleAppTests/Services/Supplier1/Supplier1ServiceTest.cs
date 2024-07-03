using MilitarySuplierFilesConsoleApp.Helpers;
using MilitarySuplierFilesConsoleApp.Models;
using MilitarySuplierFilesConsoleApp.Services;
using Moq;
using static TddXt.AnyRoot.Root;


namespace MilitarySuplierFilesConsoleAppTests.Services.Supplier1
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
        private Supplier1Service _supplierService;

        [SetUp]
        public void Setup()
        {
            _mockFileWrapper = new Mock<IFileWrapper>();
            _supplierService = new Supplier1Service(_mockFileWrapper.Object);
        }

        [Test]
        public void GetFinalProducts_WithValidPaths_ReturnsCorrectFinalProducts()
        {
            // Arrange
            string path1 = Any.Instance<string>();
            string path2 = Any.Instance<string>();

            string xmlContent1 = Files.file1;
            string xmlContent2 = Files.file2;

            _mockFileWrapper.Setup(fw => fw.ReadTextFromFile(path1)).Returns(xmlContent1);
            _mockFileWrapper.Setup(fw => fw.ReadTextFromFile(path2)).Returns(xmlContent2);

            // Act
            List<FinalProduct> result = _supplierService.GetFinalProducts(path1, path2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Termos HONER 0.5 L", result[0].Name);
            Assert.AreEqual(60, result[0].stockQuantity);
            Assert.AreEqual(3, result[0].ImgUrls.Count);
            Assert.AreEqual("https://b2b.fjordnansen.pl/hpeciai/1a4abe5da61ab6e6ae9e2e894183cdc2/9944_1.webp", result[0].ImgUrls[0]);
            Assert.AreEqual("", result[1].Name);
            Assert.AreEqual(39, result[1].stockQuantity);
            Assert.IsTrue(!result[1].ImgUrls.Any());
        }
    }
}
