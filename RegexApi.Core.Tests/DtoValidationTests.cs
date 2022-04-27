namespace RegexApi.Core.Tests
{
    using RegexApi.Contracts.DTO;
    using Xunit;

    public class DtoValidationTests
    {
        [Fact]
        public void Should_Return_True_If_Correct_Inputs()
        {
            var RegexInputs = new RegexInputs
            {
                Text = "text",
                RegularExpression = "test",
                RegexFlags = new short[] { 1 }
            };

            var ReplaceInputs = new ReplaceInputs
            {
                Text = "text",
                RegularExpression = "test",
                RegexFlags = new short[] { 1 },
                Replacement = "test"
            };

            Assert.True(RegexInputs.TryValidate(out var errors));
            Assert.True(ReplaceInputs.TryValidate(out var replaceErrors));
            Assert.Empty(errors);
            Assert.Empty(replaceErrors);
        }

        [Fact]
        public void Should_Return_False_If_InCorrect_Text()
        {
            var RegexInputs = new RegexInputs
            {
                Text = null,
                RegularExpression = "test",
                RegexFlags = new short[] { 1 }
            };

            var ReplaceInputs = new ReplaceInputs
            {
                Text = null,
                RegularExpression = "test",
                RegexFlags = new short[] { 1 },
                Replacement = "test"
            };

            Assert.False(RegexInputs.TryValidate(out var errors));
            Assert.False(ReplaceInputs.TryValidate(out var replaceErrors));
            Assert.Contains("Text cannot be null or empty;", errors);
            Assert.Contains("Text cannot be null or empty;", replaceErrors);
        }

        [Fact]
        public void Should_Return_False_If_InCorrect_RegularExpression()
        {
            var RegexInputs = new RegexInputs
            {
                Text = "text",
                RegularExpression = null,
                RegexFlags = new short[] { 1 }
            };

            var ReplaceInputs = new ReplaceInputs
            {
                Text = "text",
                RegularExpression = null,
                RegexFlags = new short[] { 1 },
                Replacement = "test"
            };

            Assert.False(RegexInputs.TryValidate(out var errors));
            Assert.False(ReplaceInputs.TryValidate(out var replaceErrors));
            Assert.Contains("Regular Expression cannot be null or empty;", errors);
            Assert.Contains("Regular Expression cannot be null or empty;", replaceErrors);
        }

        [Fact]
        public void Should_Return_False_If_InCorrect_RegexFlags()
        {
            var RegexInputs = new RegexInputs
            {
                Text = "text",
                RegularExpression = "test",
                RegexFlags = new short[] { 1, 99 }
            };

            var ReplaceInputs = new ReplaceInputs
            {
                Text = "text",
                RegularExpression = "test",
                RegexFlags = new short[] { 1, 5233 },
                Replacement = "test"
            };

            Assert.False(RegexInputs.TryValidate(out var errors));
            Assert.False(ReplaceInputs.TryValidate(out var replaceErrors));
            Assert.Contains("incorrect regex flags;", errors);
            Assert.Contains("incorrect regex flags;", replaceErrors);
        }

        [Fact]
        public void Should_Return_False_If_InCorrect_Replacement()
        {
            var ReplaceInputs = new ReplaceInputs
            {
                Text = "text",
                RegularExpression = "test",
                RegexFlags = new short[] { 1 },
                Replacement = null
            };

            Assert.False(ReplaceInputs.TryValidate(out var replaceErrors));
            Assert.Contains("Replacement cannot be null;", replaceErrors);
        }
    }
}
