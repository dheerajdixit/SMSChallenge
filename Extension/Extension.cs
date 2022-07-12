using SMS.Code.Challenge.Service.Entities;
using static SMS.Code.Challenge.Service.Dtos.Dots;

namespace SMS.Code.Challenge.Service
{
    public static class Extension
    {
        public static CityVisitDto AsDto(this CityVisit cityVisit)
        {
            return new CityVisitDto(cityVisit.Id, cityVisit.City, cityVisit.Start_Date, cityVisit.End_Date, cityVisit.Price, cityVisit.Status, cityVisit.Color);
        }
    }
}
