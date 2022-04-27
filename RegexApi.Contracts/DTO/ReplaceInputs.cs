namespace RegexApi.Contracts.DTO
{
    using System.Text;
    public class ReplaceInputs : RegexInputs
    {
        public string Replacement { get; set; }

        public override bool TryValidate(out string errors)
        {
            base.TryValidate(out var baseErrors);

            var stringBuilder = new StringBuilder(baseErrors);


            if (Replacement == null)
                stringBuilder.Append("Replacement cannot be null;");

            errors = stringBuilder.ToString();

            return stringBuilder.Length > 0 ? false : true;
        }
    }
}
