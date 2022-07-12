using SMS.Code.Challenge.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SMS.Code.Challenge.Service.Dtos
{
   
    public class Dots
    {
        public record CityVisitDto(int Id, String City, DateTime StartDate, DateTime EndDate, decimal Price, VisitStatus Status, String Color);
        public record CreateCityVisitDto([Required] String City, [Required] DateTime StartDate, [Required] DateTime EndDate, [Range(0, 1000)] decimal Price,[Required] VisitStatus Status, String Color);
        public record UpdateCityVisitDto([Required] String City, [Required] DateTime StartDate, [Required] DateTime EndDate, [Range(0, 1000)] decimal Price, [Required] VisitStatus Status, String Color);


    }
}
