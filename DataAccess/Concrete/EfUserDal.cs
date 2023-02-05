using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, MoneyTrackingContext>, IUserDal
    {
        public List<OperationClaim> GetOperationClaims(int userId)
        {
            using (var context = new MoneyTrackingContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId ==userId && userOperationClaim.Status==true
                             select new OperationClaim
                             {
                                 OperationClaimId = operationClaim.OperationClaimId,
                                 OperationClaimName = operationClaim.OperationClaimName,
                                 Description=operationClaim.Description
                             };
                return result.ToList();
            }
        }

        public List<MenuClaim> GetMenuClaims(int userId)
        {
            using (var context = new MoneyTrackingContext())
            {
                var result = from menuClaim in context.MenuClaims
                             join userMenuClaim in context.UserMenuClaims
                                 on menuClaim.MenuClaimId equals userMenuClaim.MenuClaimId
                             where userMenuClaim.UserId == userId && userMenuClaim.Status == true
                             select new MenuClaim
                             {
                                 MenuClaimId = menuClaim.MenuClaimId,
                                 MenuClaimName = menuClaim.MenuClaimName,
                                 Description=menuClaim.Description
                             };
                return result.ToList();
            }
        }


        public List<UserOperationClaimDto> GetAllUserOperationClaims(int userId)
        {

            using (var context = new MoneyTrackingContext())
            {               
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == userId
                             select new UserOperationClaimDto
                             {
                                 UserOperationClaimId =userOperationClaim.UserOperationClaimId,
                                 OperationClaimId = operationClaim.OperationClaimId,
                                 UserId=userOperationClaim.UserId,
                                 OperationClaimName = operationClaim.OperationClaimName,
                                 Description=operationClaim.Description,
                                 Status=userOperationClaim.Status
                               
                             };
                return result.ToList();
            }
        }

        public List<UserMenuClaimDto> GetAllUserMenuClaims(int userId)
        {

            using (var context = new MoneyTrackingContext())
            {
                var result = from menuClaim in context.MenuClaims
                             join userMenuClaim in context.UserMenuClaims
                                 on menuClaim.MenuClaimId equals userMenuClaim.MenuClaimId
                             where userMenuClaim.UserId == userId
                             select new UserMenuClaimDto
                             {
                                 UserMenuClaimId = userMenuClaim.UserMenuClaimId,
                                 MenuClaimId = menuClaim.MenuClaimId,
                                 UserId = userMenuClaim.UserId,
                                 MenuClaimName = menuClaim.MenuClaimName,
                                 Description = menuClaim.Description,
                                 Status = userMenuClaim.Status

                             };
                return result.ToList();
            }
        }
    }
}
