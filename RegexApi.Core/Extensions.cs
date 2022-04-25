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

        public static IEnumerable<MatchResultDTO> ConvertMatchCollection(this MatchCollection matchColletion)
        {
            var result = new List<MatchResultDTO>();

            foreach (Match elem in matchColletion)
            {
                result.Add(new MatchResultDTO(elem.Value, elem.Index , elem.Groups.ConvertToResultGroup()));
            }

            return result;
        }

        public static IEnumerable<MatchResultDTO.Group> ConvertToResultGroup(this GroupCollection groupCollection)
        {
            var result = new List<MatchResultDTO.Group>();

            foreach (Group elem in groupCollection)
            {
                result.Add(new MatchResultDTO.Group(elem.Value, elem.Index));
            }

            return result;
        }

        public static ErrorDTO ToErrorDTO(this string errors)
        {
            return new ErrorDTO(FailureReasonCode.InvalidInputs, errors.Split(';'));
        }

        public static ErrorDTO ToErrorDTO(this RegexException regexException)
        {
            return new ErrorDTO(regexException.FailureReasonCode, new string[] { regexException.Message });
        }
    }
}