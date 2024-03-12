using WCApp;
namespace WcAppTests.UtilizingFilePathMockAndTests
{
    [TestFixture]
    public class Tests
    {
        [TestFixture]
        public class FileExistance
        {
            [TestCase(".")]
            [TestCase(null)]
            [TestCase("")]
            public void GivenIncorrectFilePath_ShouldReturnErrorMessage(string path)
            {
                //Arranage
                var sut = CreateSut();
                sut.path = path;
                //Act
                var actual = sut.InputExists();
                //Assert
                Assert.False(actual);
            }

            [TestCase(@"file a")]
            [TestCase(@"file b")]
            [TestCase(@"file c")]
            public void GivenCorrectFilePath_ShouldReturnSuccessMessage(string path)
            {
                //Arrage
                var sut = CreateSut();
                sut.path = path;
                //Act
                var actual = sut.InputExists();
                //Assert
                Assert.True(actual);

            }
        }

        [TestFixture]
        public class ReadFile
        {
            [TestCase(@"file a")]
            [TestCase(@"file b")]
            [TestCase(@"file c")]
            public void ShouldReturnNumberOfCharacters(string path)
            {
                var sut = CreateSut();
                sut.path = path;
                int actual = sut.NumberOfCharacters();
                int expected = File.ReadAllText(sut.path).Length;
                Assert.That(actual, Is.EqualTo(expected));
            }

            [TestCase(@"file a")]
            [TestCase(@"file b")]
            [TestCase(@"file c")]

            public void ShouldReturnNumberOfLines(string path)
            {
                //Arrange
                var sut = CreateSut();
                sut.path = path;
                //Act
                int actual = sut.NumberOfLines();
                int expected = File.ReadAllLines(sut.path).Length;
                //Assert
                Assert.That(actual, Is.EqualTo(expected));
            }

            [TestCase(@"file a")]
            [TestCase(@"file b")]
            [TestCase(@"file c")]
            public void ShouldReturnNumberOfWords(string path)
            {
                //Arrange
                var sut = CreateSut();
                sut.path = path;
                //Act
                int actual = sut.NumberOfWords();
                int expected = 0;
                using (var sr = new StreamReader(sut.path))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        expected += line.Split(" ").Length;
                    }
                }
                //Assert
                Assert.That(actual, Is.EqualTo(expected));
            }

            [TestCase(@"file a")]
            [TestCase(@"file b")]
            [TestCase(@"file c")]
            public void ShouldReturnFileSizeInBytes(string path)
            {
                //Arrange
                var sut = CreateSut();
                sut.path = path;
                //Act
                int actual = sut.NumberOfBytes();
                long expected = new FileInfo(sut.path).Length;
                //Assert
                Assert.That(actual, Is.EqualTo(Convert.ToInt16(expected)));

            }
        }
        private static TwoArgHandlerMock CreateSut()
        {
            return new TwoArgHandlerMock();
        }
    }
}