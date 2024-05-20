using Microsoft.AspNetCore.Mvc;
using RatingService.Bll.Services.Abstracts;
using RatingService.Dtos;

namespace RatingService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController(
        IRatingServices ratingServices)
        : ControllerBase
    {
        private readonly IRatingServices ratingServices = ratingServices;


        /// <summary>
        /// This endpoint saves the users rate point for the provider
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Rate(RatingDto request)
        {
            try
            {
                await ratingServices.RateAsync(request);

                return Created();
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// This endpoint returns the avarage rate of the specified provider
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        [HttpGet("{providerId}/avarage")]
        public async Task<IActionResult> Avarage(int providerId)
        {
            try
            {
                var avarageRate = await ratingServices.AvarageAsync(providerId);
                return Ok(avarageRate);
            }
            catch
            {
                throw;
            }
        }

      
    }
}
