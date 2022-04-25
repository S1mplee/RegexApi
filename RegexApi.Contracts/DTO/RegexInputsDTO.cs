namespace RegexApi.Contracts.DTO
{
    using RegexApi.Contracts.Interfaces;
    using System.Text;

    public class RegexInputsDTO : IValidator
    {
        public string Text { get; set; }
        public string RegularExpression { get; set; }
        public short[] RegexFlags { get; set; } = null;

        public virtual bool TryValidate(out string errors)
        {
            var stringBuilder = new StringBuilder();

            if (string.IsNullOrEmpty(Text))
                stringBuilder.Append("Text cannot be null or empty;");

            if (string.IsNullOrEmpty(RegularExpression))
                stringBuilder.Append("Regular Expression cannot be null or empty;");

            if (RegexFlags != null && !RegexFlags.IsValidRegexFlags())
                stringBuilder.Append("incorrect regex flags;");

            errors = stringBuilder.ToString();

            return stringBuilder.Length > 0 ? false : true;
        }
    }
}