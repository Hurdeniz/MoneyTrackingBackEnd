using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class NoteManager : INoteService
    {
        private INoteDal _noteDal;

        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }

        [SecuredOperation("Admin,Staff,Service,Note.GetAllByUser")]
        [CacheAspect]
        public IDataResult<List<Note>> GetAllByUser(int userId) => new SuccessDataResult<List<Note>>(_noteDal.GetAll(u => u.UserId == userId).OrderByDescending(d=>d.Date).ToList(), Messages.NoteListed);

        [SecuredOperation("Admin,Staff,Service,Note.Add")]
        [CacheRemoveAspect("INoteService.Get")]
        [ValidationAspect(typeof(NoteValidator))]
        public IResult Add(Note note)
        {
            _noteDal.Add(note);
            return new SuccessResult(Messages.NoteAdded);
        }

        [SecuredOperation("Admin,Staff,Service,Note.Update")]
        [CacheRemoveAspect("INoteService.Get")]
        [ValidationAspect(typeof(NoteValidator))]
        public IResult Update(Note note)
        {
            _noteDal.Update(note);
            return new SuccessResult(Messages.NoteUpdated);
        }

        [SecuredOperation("Admin,Staff,Service,Note.Delete")]
        [CacheRemoveAspect("INoteService.Get")]
        public IResult Delete(Note note)
        {
            _noteDal.Delete(note);
            return new SuccessResult(Messages.NoteDeleted);
        }

    }
}
