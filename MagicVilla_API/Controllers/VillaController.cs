using MagicVilla_API.DataDbContext;
using MagicVilla_API.DTOs;
using MagicVilla_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {

        private readonly ILogger<VillaController> _logger;
        private readonly DbContextApp _dbContextApp;

        public VillaController( ILogger<VillaController> logger, DbContextApp dbContextApp) { 
            _logger = logger;
            _dbContextApp = dbContextApp;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  ActionResult<IEnumerable<Villa>> GetVillas()
        {
            try
            {
                List<Villa> villas = _dbContextApp.Villas.ToList();
                if (villas.Count <= 0)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "This List is Empty");
                }
                _logger.LogInformation("You are show all Villas");
                return Ok(_dbContextApp.Villas.ToList());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get List");
            }
            
        }

        [HttpGet("id")]
        
        public ActionResult<VillaDto> GetOnlyVilla(int id)
        {

            VillaDto villaDto = DataExamples.villaDtos.FirstOrDefault(v => v.Id == id);
            if (villaDto == null) {
                _logger.LogError("This " + id + "no exist");
                return NotFound("This Villa not Found");
            }
            return StatusCode(StatusCodes.Status202Accepted, villaDto) ;
        }

        [HttpPost]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto) {
            try
            {

                villaDto.Id = DataExamples.villaDtos.Count() + 1;
                DataExamples.villaDtos.Add(villaDto);
                return StatusCode(StatusCodes.Status201Created, new { Id = 99, Name = "Test" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to insert new Villa in Database");
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteVilla([FromQuery] int id) {
            VillaDto villaDto = DataExamples.villaDtos.FirstOrDefault(villa => villa.Id == id);
            if (villaDto == null)
            {
                return BadRequest("This Villa Not found");
            }            

            try
            {
                DataExamples.villaDtos.Remove(villaDto);
                return Ok("Deleted succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to Delete this villa"); ;
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDto villaDto) {

            if (villaDto.Id != id) {
                return BadRequest("This Villa Not Found");
            }

            VillaDto villaDtoAux = DataExamples.villaDtos.FirstOrDefault(villa => villa.Id == id);
            villaDtoAux.Name = villaDto.Name;
            return Ok();
        }
    }
}
