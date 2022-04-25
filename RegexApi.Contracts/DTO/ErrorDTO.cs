namespace RegexApi.Contracts.DTO
{
    using RegexApi.Contracts.Enum;
    public class ErrorDTO
    {
        public ErrorDTO(FailureReasonCode failureReasonCode,string[] errors)
        {
            FailureReasonCode = failureReasonCode;
            Errors = errors;
        }
        public FailureReasonCode FailureReasonCode { get; set; }
        public string[] Errors { get; set; }
    }
}
