using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using TheCat.Application.Interfaces;
using TheCat.Application.ViewModels.Logger;

namespace TheCat.EntryPoint.Api.Controllers.V1
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class TheCatController : ControllerBase
    {
        private IBreedsAppServices _serviceBreeds;
        private ILoggerAppServices _serviceLogger;
        public TheCatController(
            IBreedsAppServices serviceBreeds,
            ILoggerAppServices serviceLogger)
        {
            _serviceBreeds = serviceBreeds;
            _serviceLogger = serviceLogger;
        }

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllBreed", Name = "GetAllBreed")]
        public async Task<IActionResult> GetAllBreed()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                return Ok(await _serviceBreeds.GetAllBreed().ConfigureAwait(true));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// GetBreed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBreed/{breed}", Name = "GetBreed")]
        public async Task<IActionResult> GetBreed(string breed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _serviceLogger.LogInformation(new LoggerRequestViewModel { ApplicationName = "TheCatApi", Message = $"GetBreed/{breed} " });

                return Ok(await _serviceBreeds.GetBreed(breed).ConfigureAwait(true));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// GetBreed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBreedForOrigin/{origin}", Name = "GetBreedForOrigin")]
        public async Task<IActionResult> GetBreedForOrigin(string origin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _serviceLogger.LogInformation(new LoggerRequestViewModel { ApplicationName = "TheCatApi", Message = $"GetBreedForOrigin/{origin} " });

                return Ok(await _serviceBreeds.GetBreedForOrigin(origin).ConfigureAwait(true));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// GetBreed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBreedForTemperament/{temperament}", Name = "GetBreedForTemperament")]
        public async Task<IActionResult> GetBreedForTemperament(string temperament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _serviceLogger.LogInformation(new LoggerRequestViewModel { ApplicationName = "TheCatApi", Message = $"GetBreedForTemperament/{temperament} " });

                return Ok(await _serviceBreeds.GetBreedForTemperament(temperament).ConfigureAwait(true));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }


        /// <summary>
        /// ImportBreeds
        /// </summary>
        /// <returns></returns>
        [HttpPost("ImportBreeds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ImportBreeds()
        {
            try
            {
                return Ok(await _serviceBreeds.ImportAllBreeds().ConfigureAwait(true));

            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
