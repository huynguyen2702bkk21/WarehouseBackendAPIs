namespace WMS.APIs.Controllers
{
    [ApiController]
    public class ApiControllerBase : Controller
    {
        protected readonly IMediator _mediator;

        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> CommandAsync<T>(IRequest<T> request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (DuplicateRecordException ex)
            {
                var errorMessage = new ErrorResponse(ex);
                return BadRequest(errorMessage);
            }
            catch (EntityNotFoundException ex)
            {
                var errorMessage = new ErrorResponse(ex);
                return BadRequest(errorMessage);
            }
            catch (InvalidProductIssueQuantityException ex)
            {
                var errorMessage = new ErrorResponse(ex);
                return BadRequest(errorMessage);
            }
            catch (Exception ex)
            {
                var errorMessage = new ErrorResponse(ex);
                return BadRequest(errorMessage);
            }
        }
    }
}
