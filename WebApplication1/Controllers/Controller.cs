using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Model.Dto;

namespace WebApplication1.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class Example : ControllerBase
        {
        [HttpGet]
        public ActionResult<IEnumerable<DtoExample>> GetExamples()
            {
            return Ok(StoreExample.exampleList);
            }

        [HttpGet("id:{int}", Name = "GetExample")]
        //[ProducesResponseType(200, Type = typeof(DtoExample))]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DtoExample> GetExamples(int id)
            {
            if (!ModelState.IsValid)
                {
                return BadRequest(ModelState);
                }

            if (id == 0)
                {
                return BadRequest();
                }

            var example = StoreExample.exampleList.FirstOrDefault(u => u.Id == id);

            if (example == null)
                {
                return NotFound();
                }
            ;

            return Ok(example);
            }

        [HttpPost]
        public ActionResult<DtoExample> CreateExample([FromBody] DtoExample exampleDTO)
            {
            //if (exampleDTO == null)
            //    {
            //    return BadRequest(exampleDTO);
            //    }

            if (
                StoreExample.exampleList.FirstOrDefault(
                    u => u.Name.ToLower() == exampleDTO.Name.ToLower()
                ) != null
            )
                {
                ModelState.AddModelError("Custom Error", "Example already exist");
                return BadRequest(ModelState);
                }

            if (exampleDTO.Id > 1)
                {
                return StatusCode(StatusCodes.Status500InternalServerError);
                }

            exampleDTO.Id = StoreExample.exampleList
                .OrderByDescending(u => u.Id)
                .FirstOrDefault()
                .Id;
            StoreExample.exampleList.Add(exampleDTO);

            return CreatedAtRoute("GetExample", new { id = exampleDTO.Id }, exampleDTO);
            }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id: int}", Name = "DeleteExample")]
        public IActionResult DeleteExample(int id)
            {
            if (id == 0)
                {
                return BadRequest();
                }

            var example = StoreExample.exampleList.FirstOrDefault(u => u.Id == id);

            if (example == null)
                {
                return NotFound();
                }

            StoreExample.exampleList.Remove(example);

            return NoContent();
            }

        //[HttpPut("{id: int}", Name = "UpdateExample")]
        //public IActionResult UpdateVilla(int id, [FromBody] DtoExample dtoExample)
        //    {
        //    if (dtoExample == null || id != dtoExample.Id)
        //        {
        //        return BadRequest();
        //        }
        //    var example = StoreExample.exampleList.FirstOrDefault(u => u.Id == id);

        //    example.Name = dtoExample.Name;
        //    example.Sqft = dtoExample.Sqft;
        //    example.Occupancy = dtoExample.Occupancy;

        //    return NoContent();

        //    }

        }



    }
