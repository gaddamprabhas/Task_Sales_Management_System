using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TaskSales.Infrastructure.Mongo;
using TaskSales.Infrastructure.MongoModels;
namespace TaskSales.Api.Controllers.Feedback
{
    [ApiController]
    [Route("api/feedback")]
    
    public class FeedbackController : ControllerBase
    {
        private readonly MongoDbService _mongoService;

        public FeedbackController(MongoDbService mongoService)
        {
            _mongoService = mongoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserFeedback feedback)
        {
            await _mongoService.UserFeedbacks.InsertOneAsync(feedback);
            return Ok("Feedback saved");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _mongoService.UserFeedbacks
                .Find(_ => true)
                .ToListAsync();

            return Ok(data);
        }
    }
}
