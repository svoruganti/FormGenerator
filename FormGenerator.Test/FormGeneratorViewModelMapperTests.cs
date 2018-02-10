using FormGenerator.Mapper;
using FormGenerator.ViewModel;
using Xunit;

namespace FormGenerator.Test
{
    public class FormGeneratorViewModelMapperTests
    {
        [Fact]
        public void ShouldConvertViewModelToDictionary()
        {
            var mapper = new FormGeneratorViewModelMapper();
            var formViewModel = new FormViewModel
            {
                Id = 1,
                FormCode = "Test code",
                Description = "Test description",
                LoadUrl = "Test load url",
                SaveUrl = "Test save url"
            };
            var dictionary = mapper.ConvertToDictionary(formViewModel);
            Assert.Equal(6, dictionary.Count);
            Assert.Equal(1, dictionary["Id"]);
            Assert.Equal("Test code", dictionary["Code"]);
            Assert.Equal("Test description", dictionary["Description"]);
            Assert.Equal("Test load url", dictionary["LoadUrl"]);
            Assert.Equal("Test save url", dictionary["SaveUrl"]);
        }
    }
}