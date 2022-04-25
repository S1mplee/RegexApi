namespace RegexApi.Contracts.Interfaces
{
    using RegexApi.Contracts.DTO;
    using System.Collections.Generic;

    public interface IRegexService
    {
        bool IsExpressionMatches(string text, string pattern, short[] regexFlags = null);
        IEnumerable<MatchResultDTO> GetMatchedExpressions(string text, string pattern, short[] regexFlags = null);
        string Replace(string text, string pattern, string replacement, short[] regexFlags = null);
    }
}
