using Microsoft.AspNetCore.Mvc;
using FeedbackSystem.API.Models;
using FeedbackSystem.API.Services.Interfaces;

namespace FeedbackSystem.API.Controllers;

[ApiController]
[Route("api/feedback")]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitFeedback([FromBody] Feedback feedback)
    {
        var result = await _feedbackService.SubmitFeedbackAsync(feedback);

        return Ok(new
        {
            message = "Feedback submitted successfully",
            data = result
        });
    }

}
