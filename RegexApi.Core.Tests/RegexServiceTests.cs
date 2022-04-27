namespace RegexApi.Core.Tests
{
    using ApiTest.Core;
    using RegexApi.Contracts.DTO;
    using RegexApi.Contracts.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    public class RegexServiceTests
    {
        IRegexService regexService;
        public RegexServiceTests()
        {
            regexService = new RegexService();
        }

        [Fact]
        public void Should_Return_True_When_Text_Matches_Expression()
        {
            var text = "we are here here";
            var pattern = "\\b(?<word>\\w+)\\s+(\\k<word>)\\b";

            Assert.True(regexService.IsExpressionMatches(text, pattern));
        }

        [Fact]
        public void Should_Return_True_When_Text_Matches_Expression_With_IgnoreCaseFlag()
        {
            var text = "we are here Here";
            var pattern = "\\b(?<word>\\w+)\\s+(\\k<word>)\\b";

            Assert.True(regexService.IsExpressionMatches(text, pattern, new short[] { 1 }));
        }

        [Fact]
        public void Should_Return_False_When_Text_Does_Not_Matches_Expression()
        {
            var text = "we are here";
            var pattern = "\\b(?<word>\\w+)\\s+(\\k<word>)\\b";

            Assert.False(regexService.IsExpressionMatches(text, pattern));
        }

        [Fact]
        public void Should_Replace_Matched_Expressions()
        {
            var text = "we are here here";
            var pattern = "\\b(?<word>\\w+)\\s+(\\k<word>)\\b";
            var replacement = "replace";

            Assert.Equal("we are replace", regexService.Replace(text, pattern, replacement));
        }

        [Fact]
        public void Should_Return_Matched_Expressions()
        {
            var text = "we are here here";
            var pattern = "\\b(?<word>\\w+)\\s+(\\k<word>)\\b";

            var matchedResultExpected = new MatchResult("here here", 7, new List<MatchResult.Group> { new MatchResult.Group("here here", 7), new MatchResult.Group("here", 7), new MatchResult.Group("here", 12) });

            var matchedResult = regexService.GetMatchedExpressions(text, pattern);

            Assert.Equal(matchedResultExpected.FullMatch, matchedResult.FirstOrDefault().FullMatch);
            Assert.Equal(7, matchedResult.FirstOrDefault().Position);
            Assert.Equal(3, matchedResult.FirstOrDefault().Groups.Count());
        }

        [Fact]
        public void Should_Not_Return_Result_If_Invalid_Inputs()
        {
            Assert.Throws<RegexException>(() => regexService.IsExpressionMatches(null, null));
            Assert.Throws<RegexException>(() => regexService.IsExpressionMatches(null, "\\b(?<word>\\w+)\\s+(\\k<word>)\\b"));
            Assert.Throws<RegexException>(() => regexService.IsExpressionMatches("we are here here", null));

            Assert.Throws<RegexException>(() => regexService.Replace(null, null , null));
            Assert.Throws<RegexException>(() => regexService.Replace("we are here here", "\\b(?<word>\\w+)\\s+(\\k<word>)\\b", null));
            Assert.Throws<RegexException>(() => regexService.Replace(null, "\\b(?<word>\\w+)\\s+(\\k<word>)\\b", "replace"));

            Assert.Throws<RegexException>(() => regexService.GetMatchedExpressions(null, null));
            Assert.Throws<RegexException>(() => regexService.GetMatchedExpressions("we are here here", null));
            Assert.Throws<RegexException>(() => regexService.GetMatchedExpressions(null, "\\b(?<word>\\w+)\\s+(\\k<word>)\\b"));
        }
    }
}
