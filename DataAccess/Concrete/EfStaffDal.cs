using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfStaffDal : EfEntityRepositoryBase<Staff, MoneyTrackingContext>, IStaffDal
    {
        public List<StaffDetailDto> GetAllStaffDetailByStatus(bool status)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from s in context.Staffs
                             join e in context.StaffEpisodes
                             on s.StaffEpisodeId equals e.StaffEpisodeId
                             join t in context.StaffTasks
                             on s.StaffTaskId equals t.StaffTaskId
                             where s.Status==status
                             select new StaffDetailDto
                             {
                                 StaffId = s.StaffId,
                                 IdentityNumber = s.IdentityNumber,
                                 NameSurname = s.NameSurname,
                                 Phone1 = s.Phone1,
                                 Phone2 = s.Phone2,
                                 Email = s.Email,
                                 Province = s.Province,
                                 District = s.District,
                                 Adress = s.Adress,
                                 DateOfEntryIntoWork = s.DateOfEntryIntoWork,
                                 DateOfDismissal = s.DateOfDismissal,
                                 StaffEpisodeId = e.StaffEpisodeId,
                                 StaffEpisodeName = e.StaffEpisodeName,
                                 StaffTaskId = t.StaffTaskId,
                                 StaffTaskName = t.StaffTaskName,
                                 Status = s.Status,

                             };
                return result.OrderBy(s=>s.DateOfEntryIntoWork).ThenBy(s=>s.NameSurname).ToList();
            }
        }

     
    }
}
