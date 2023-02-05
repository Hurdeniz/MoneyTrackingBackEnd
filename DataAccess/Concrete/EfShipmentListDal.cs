using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfShipmentListDal: EfEntityRepositoryBase<ShipmentList, MoneyTrackingContext>, IShipmentListDal
    {

        public List<ShipmentListDetailDto> GetAllShipmentListDetailByStatusAndDate(bool status, DateTime startDate, DateTime endDate)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from s in context.ShipmentLists
                             join u in context.Users
                             on s.UserId equals u.UserId
                             where s.Status==status && s.Date >= startDate && s.Date <= endDate
                             select new ShipmentListDetailDto
                             {
                                 ShipmentListId = s.ShipmentListId,
                                 ShipmentNumber=s.ShipmentNumber,
                                 UserId = u.UserId,
                                 UserNameSurname = $"{u.FirstName} {u.LastName}",
                                 CustomerCode = s.CustomerCode,
                                 CustomerNameSurname = s.CustomerNameSurname,
                                 PromissoryNumber = s.PromissoryNumber,
                                 Adress=s.Adress,
                                 Date=s.Date,
                                 Result=s.Result,
                                 Description = s.Description,
                                 Status = s.Status,
                             };
                return result.OrderByDescending(s => s.Date).ThenBy(s => s.ShipmentNumber).ThenBy(s => s.CustomerNameSurname).ToList();
            }
        }


        public GetCountDto GetCountByDate(DateTime date , bool status)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var count = context.ShipmentLists.Where(s => s.Date == date && s.Status==status).Count();

                GetCountDto getCountDto = new GetCountDto
                {
                    Count = count
                };
                return getCountDto;

            }
        }




    }
}
