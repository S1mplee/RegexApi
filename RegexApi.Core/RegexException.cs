namespace ApiTest.Core
{
    using RegexApi.Contracts.Enum;
    using System;

    public class RegexException : Exception
    {
        public FailureReasonCode FailureReasonCode { get; }
        public RegexException(string reason, FailureReasonCode failureReason) : base(reason)
        {
            FailureReasonCode = failureReason;
        }
    }
}