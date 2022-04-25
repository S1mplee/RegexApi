namespace RegexApi.Contracts.Interfaces
{
    public interface IValidator
    {
        bool TryValidate(out string errors);
    }
}
