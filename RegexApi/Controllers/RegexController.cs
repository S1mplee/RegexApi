namespace ApiTest.Controllers
{
    using ApiTest.Core;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using RegexApi.Contracts.DTO;
    using RegexApi.Contracts.Interfaces;
    using System.Collections.Generic;
    using System.Net;

    [ApiController]
    [EnableCors("RegexCors")]
    [Route("api/regex")]
    public class RegexController : ControllerBase
    {
        private readonly IRegexService _regexService;
        public RegexController(IRegexService regexService)
        {
            _regexService = regexService;
        }

        [HttpPost("ismatch")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        public IActionResult IsMatch([FromBody] RegexInputs inputs)
        {
            if (!inputs.TryValidate(out var errors))
                return BadRequest(errors.ToErrorDTO());

            bool result;

            try
            {
                result = _regexService.IsExpressionMatches(inputs.Text, inputs.RegularExpression , inputs.RegexFlags);
            }
            catch (RegexException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,ex.ToErrorDTO());
            }

            return Ok(new { isMatch = result });
        }

        [HttpPost("match")]
        [ProducesResponseType(typeof(IEnumerable<MatchResult>), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        public IActionResult GetMatchedExpressions([FromBody] RegexInputs inputs)
        {
            if (!inputs.TryValidate(out var errors))
                return BadRequest(errors.ToErrorDTO());

            IEnumerable<MatchResult> result;

            try
            {
                result = _regexService.GetMatchedExpressions(inputs.Text, inputs.RegularExpression , inputs.RegexFlags);
            }
            catch (RegexException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToErrorDTO());
            }

            return Ok(result);
        }

        [HttpPost("replace")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        public IActionResult Replace([FromBody] ReplaceInputs inputs)
        {
            if (!inputs.TryValidate(out var errors))
                return BadRequest(errors.ToErrorDTO());

            string result;

            try
            {
                result = _regexService.Replace(inputs.Text, inputs.RegularExpression, inputs.Replacement , inputs.RegexFlags);
            }
            catch (RegexException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToErrorDTO());
            }

            return Ok( new { ReplacedText = result });
        }
    }
}
