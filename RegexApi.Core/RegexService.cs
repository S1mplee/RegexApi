namespace ApiTest.Core
{
    using RegexApi.Contracts.DTO;
    using RegexApi.Contracts.Enum;
    using RegexApi.Contracts.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class RegexService : IRegexService
    {
        public IEnumerable<MatchResult> GetMatchedExpressions(string text, string pattern, short[] regexFlags = null)
        {
            try
            {
                var result = Regex.Matches(text, pattern, regexFlags != null ? regexFlags.ConvertToRegexOptions() : RegexOptions.None);
                return result.ConvertMatchCollection();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
                    throw new RegexException("Invalid inputs", FailureReasonCode.InvalidInputs);

                throw new RegexException("unknown error", FailureReasonCode.None);
            }
        }

        public bool IsExpressionMatches(string text, string pattern, short[] regexFlags = null)
        {
            try
            {
                var result = Regex.IsMatch(text, pattern, regexFlags != null ? regexFlags.ConvertToRegexOptions() : RegexOptions.None);
                return result;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
                    throw new RegexException("Invalid inputs", FailureReasonCode.InvalidInputs);

                if (ex is RegexMatchTimeoutException)
                    throw new RegexException("Timeout exceeded", FailureReasonCode.Timeout);

                throw new RegexException("unknown error", FailureReasonCode.None);
            }
        }

        public string Replace(string text, string pattern, string replacement, short[] regexFlags = null)
        {
            try
            {
                var result = Regex.Replace(text, pattern, replacement, regexFlags != null ? regexFlags.ConvertToRegexOptions() : RegexOptions.None);
                return result;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
                    throw new RegexException("Invalid inputs", FailureReasonCode.InvalidInputs);

                if (ex is RegexMatchTimeoutException)
                    throw new RegexException("Timeout exceeded", FailureReasonCode.Timeout);

                throw new RegexException("unknown error", FailureReasonCode.None);
            }
        }
    }
}