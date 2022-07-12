using SMS.Code.Challenge.Common;
using SMS.Code.Challenge.Common.Enums;
using SMS.Code.Challenge.Service.Dtos;

namespace SMS.Code.Challenge.Service.Entities
{
    public class CityVisit : IEntity
    {
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        public decimal Price { get; set; }
        public VisitStatus Status { get; set; }
        public string Color { get; set; }

    }
}
