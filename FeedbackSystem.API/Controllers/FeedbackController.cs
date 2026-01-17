using Microsoft.AspNetCore.Mvc;
using FeedbackSystem.API.Services.Interfaces;
using FeedbackSystem.Contracts.DTO;
using FeedbackSystem.API.Enum;

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
    public async Task<IActionResult> SubmitFeedback([FromBody] FeedbackDTO feedbackDto)
    {
        try
        {
            Console.WriteLine("Received feedback submission request.");
            var result = await _feedbackService.SubmitFeedbackAsync(feedbackDto);
            return Ok(new
            {
                message = "Feedback submitted successfully",
                data = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "An error occurred while submitting feedback",
                error = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetFeedbacks()
    {
        try
        {
            var feedbacks = await _feedbackService.GetAllFeedbacks();
            return Ok(new
            {
                message = "Feedbacks retrieved successfully",
                data = feedbacks
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "An error occurred while retrieving feedbacks",
                error = ex.Message
            });
        }
    }

    [HttpPut("{id:int}/{status:int}")]
    public async Task<IActionResult> UpdateFeedbackStatus(int id, int status)
    {
        // Validate status value
        if (status != 0 && status != 1)
            return BadRequest("Invalid status value. Allowed values: 0 = New, 1 = Reviewed.");

        // Map int to enum
        var enumStatus = (FeedBackStatus)status;

        // Call service
        var updatedFeedback = await _feedbackService.UpdateFeedbackStatusAsync(id, enumStatus);

        if (updatedFeedback == null)
            return NotFound($"Feedback with ID {id} not found.");

        return Ok(updatedFeedback);
    }

}