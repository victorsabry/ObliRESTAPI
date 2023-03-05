using Car_Unit_Test;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObliRESTAPI.Properties;

namespace ObliRESTAPI.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public CarsRepository _repository;

        public CarsController(CarsRepository repository)
        {
            _repository = repository;
        }

        // GET: Cars
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("all")]
        public ActionResult<List<Car>> Index()
        {
            return _repository.GetAll();
        }

        // GET: Cars/{id}
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<Car> Details(int id)
        {
            try
            {
                var car = _repository.GetById(id);
                return car;
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }

        }

        // POST: Cars
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]        
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                Car createdCar = _repository.Add(newCar);
                return Created($"api/cars/{createdCar.Id}", createdCar);
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: Cars/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Car> Edit(int id, [FromBody]Car car)
        {
            try
            {
                Car updatedCar = _repository.Update(car, id);
                return updatedCar;
            }
            catch(ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }



        // DELETE: Cars/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
               _repository.Delete(id);
                return Ok();
            }
            catch(ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
