namespace ApiTest.Core
{
    using RegexApi.Contracts.DTO;
    using RegexApi.Contracts.Enum;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class Extensions
    {
        public static RegexOptions ConvertToRegexOptions(this short[] flags)
        {
            RegexOptions regexOptions = RegexOptions.None;

            foreach (var flag in flags)
            {
                regexOptions = regexOptions | (RegexOptions)flag;
            }

            return regexOptions;
        }

        public static IEnumerable<MatchResult> ConvertMatchCollection(this MatchCollection matchColletion)
        {
            var result = new List<MatchResult>();

            foreach (Match elem in matchColletion)
            {
                result.Add(new MatchResult(elem.Value, elem.Index , elem.Groups.ConvertToResultGroup()));
            }

            return result;
        }

        public static IEnumerable<MatchResult.Group> ConvertToResultGroup(this GroupCollection groupCollection)
        {
            var result = new List<MatchResult.Group>();

            foreach (Group elem in groupCollection)
            {
                result.Add(new MatchResult.Group(elem.Value, elem.Index));
            }

            return result;
        }

        public static Error ToErrorDTO(this string errors)
        {
            return new Error(FailureReasonCode.InvalidInputs, errors.Split(';'));
        }

        public static Error ToErrorDTO(this RegexException regexException)
        {
            return new Error(regexException.FailureReasonCode, new string[] { regexException.Message });
        }
    }
}