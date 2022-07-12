using Microsoft.AspNetCore.Mvc;
using static SMS.Code.Challenge.Service.Dtos.Dots;
using System.IO;
using SMS.Code.Challenge.Service.Dtos;
using System.Drawing;
using SMS.Code.Challenge.Common;
using SMS.Code.Challenge.Service.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SMS.Code.Challenge.Service.Controllers
{
    //https://localhost:5001/CityVisits
    [ApiController]
    [Route("CityVisits")]
    public class CityVisitsController : ControllerBase
    {
        private readonly IRepository<CityVisit> cityVisitsRepository;


        public CityVisitsController(IRepository<CityVisit> cityVisitsRepository)
        {
            this.cityVisitsRepository = cityVisitsRepository;
           
            //dbCollection.InsertManyAsync(seedData)
        }

        [HttpGet]
        public async Task<IEnumerable<CityVisitDto>> GetAsync()
        {
            return (await cityVisitsRepository.GetAllAsync()).Select(rec => rec.AsDto());
        }

        //Get /CityVisits/Id
        [HttpGet("id")]
        public async Task<ActionResult<CityVisitDto>> GetByIdAsync(int id)
        {
            var record = await cityVisitsRepository.GetAsync(id);
            if (record == null) return NotFound();
            return record.AsDto();
        }


        //Post //CityVisits
        [HttpPost]
        public async Task<ActionResult<CityVisitDto>> PostAsync(CreateCityVisitDto createCityVisitDto)
        {
            // var newId = 1;

            var newId = 1;
            var recs = await cityVisitsRepository.GetAllAsync();
            if (recs.Count > 0) newId = recs.Max(r => r.Id) + 1;

            var rec = new CityVisit
            {
                Id = newId,
                City = createCityVisitDto.City,
                Start_Date = createCityVisitDto.StartDate,
                End_Date = createCityVisitDto.EndDate,
                Price = createCityVisitDto.Price,
                Status = createCityVisitDto.Status,
                Color = createCityVisitDto.Color
            };
            await cityVisitsRepository.CreateAsync(rec);
            return CreatedAtAction(nameof(GetByIdAsync), new { Id = rec.Id }, rec);
        }

        //Put //CityVisits/id
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, UpdateCityVisitDto updateCityVisitDto)
        {
            var existingRecord = cityVisitsRepository.GetAsync(id);
            if (existingRecord == null) return NotFound();
            var updatedRecord = new CityVisit
            {
                Id = id,
                City = updateCityVisitDto.City,
                Start_Date = updateCityVisitDto.StartDate,
                End_Date = updateCityVisitDto.EndDate,
                Price = updateCityVisitDto.Price,
                Status = updateCityVisitDto.Status,
                Color = updateCityVisitDto.Color

            };
            await cityVisitsRepository.UpdateAsync(updatedRecord);
            return NoContent();
        }
        //Delete //CityVisits/id
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var rec = await cityVisitsRepository.GetAsync(id);
            if (rec == null) return NotFound();
            await cityVisitsRepository.RemoveAsync(id);
            return NoContent();
        }

    }
}
