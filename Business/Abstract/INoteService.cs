using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface INoteService
    {
        IDataResult<List<Note>> GetAllByUser(int userId);
        IResult Add(Note note);
        IResult Update(Note note);
        IResult Delete(Note note);
    }
}
