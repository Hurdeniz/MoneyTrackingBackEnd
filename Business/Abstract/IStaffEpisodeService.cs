using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IStaffEpisodeService
    {
        IDataResult<List<StaffEpisode>> GetAll();
        IResult Add(StaffEpisode staffEpisode);
        IResult Update(StaffEpisode staffEepisode);
        IResult Delete(StaffEpisode staffEpisode);
    }
}
