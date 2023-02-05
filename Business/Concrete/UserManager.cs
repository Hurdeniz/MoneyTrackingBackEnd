using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private ITokenHelper _tokenHelper;
        private IOperationService _operationService;
        private IMenuClaimService _menuClaimService;
        private IUserOperationService _userOperationService;
        private IUserMenuService _userMenuService;


        public UserManager(IUserDal userDal, ITokenHelper tokenHelper, IOperationService operationService, IUserOperationService userOperationService, IMenuClaimService menuClaimService , IUserMenuService userMenuService)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _operationService = operationService;
            _menuClaimService = menuClaimService;
            _userOperationService = userOperationService;
            _userMenuService = userMenuService;
        }


        //  [SecuredOperation("Admin,User.GetAllUserByStatus")]
        // [CacheAspect]
        public IDataResult<List<User>> GetAllUserByStatus(bool status)
        {

            if (status == true)
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Status == status), Messages.UserActiveListed);
            }
            else
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Status == status), Messages.UserPassiveListed);
            }
        }   
        public IDataResult<List<UserOperationClaimDto>> GetAllUserOperationClaims(int userId) => new SuccessDataResult<List<UserOperationClaimDto>>(_userDal.GetAllUserOperationClaims(userId), Messages.UserOperationListed);

        public IDataResult<List<UserMenuClaimDto>> GetAllUserMenuClaims(int userId) => new SuccessDataResult<List<UserMenuClaimDto>>(_userDal.GetAllUserMenuClaims(userId), Messages.UserMenuListed);

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userDal.GetOperationClaims(user.UserId);
            var menuClaims = _userDal.GetMenuClaims(user.UserId);
            var accessToken = _tokenHelper.CreateToken(user, operationClaims, menuClaims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> GetByMail(string email) => new SuccessDataResult<User>(_userDal.Get(e => e.Email == email));


        //[SecuredOperation("Admin,User.Add")]
        // [CacheRemoveAspect("IUserService.Get")]
        [ValidationAspect(typeof(UserValidator))]
        [TransactionScopeAspect]
        public IResult Add(UserForAddDto userForAddDto, string password)
        {
            IResult result = BusinessRules.Run(
            CheckIfEmailExists(userForAddDto.Email));

            if (result != null)
            {
                return result;
            }


            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {

                Email = userForAddDto.Email,
                FirstName = userForAddDto.FirstName,
                LastName = userForAddDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true

            };

            _userDal.Add(user);


            var operationList = _operationService.GetAll().Data;

            if (userForAddDto.OperationClaimId == 1)
            {
                var userOperation = new UserOperationClaim
                {
                    UserId = user.UserId,
                    OperationClaimId = userForAddDto.OperationClaimId,
                    Status = true

                };

                _userOperationService.Add(userOperation);
            }
            else if (userForAddDto.OperationClaimId == 2)
            {
                foreach (var operation in operationList)
                {
                    if (operation.OperationClaimId > 27)
                    {
                        var userOperation = new UserOperationClaim
                        {
                            UserId = user.UserId,
                            OperationClaimId = operation.OperationClaimId,
                            Status = false

                        };
                       _userOperationService.Add(userOperation);
                    }
                    else if (operation.OperationClaimId == 2)
                    {
                        var userOperation = new UserOperationClaim
                        {
                            UserId = user.UserId,
                            OperationClaimId = operation.OperationClaimId,
                            Status = true
                        };
                        _userOperationService.Add(userOperation);
                    }
                }
            }
            else if (userForAddDto.OperationClaimId == 3)
            {
                foreach (var operation in operationList)
                {
                    if (operation.OperationClaimId > 11 && operation.OperationClaimId < 86)
                    {
                        var userOperation = new UserOperationClaim
                        {
                            UserId = user.UserId,
                            OperationClaimId = operation.OperationClaimId,
                            Status = false

                        };
                        _userOperationService.Add(userOperation);
                    }
                    else if (operation.OperationClaimId == 3)
                    {
                        var userOperation = new UserOperationClaim
                        {
                            UserId = user.UserId,
                            OperationClaimId = operation.OperationClaimId,
                            Status = true
                        };
                        _userOperationService.Add(userOperation);
                    }
                }

            }
            else if (userForAddDto.OperationClaimId == 4)
            {
                foreach (var operation in operationList)
                {
                    if (operation.OperationClaimId >3)
                    {
                        var userOperation = new UserOperationClaim
                        {
                            UserId = user.UserId,
                            OperationClaimId = operation.OperationClaimId,
                            Status = false

                        };
                        _userOperationService.Add(userOperation);
                    }               
                }
            }
            else
            {
                return new ErrorResult(Messages.UserOperationError);
            }

            var menuList = _menuClaimService.GetAll().Data;

            if (userForAddDto.MenuClaimId == 1)
            {
                var userMenuClaim = new UserMenuClaim
                {
                    UserId = user.UserId,
                    MenuClaimId = userForAddDto.MenuClaimId,
                    Status = true

                };

                _userMenuService.Add(userMenuClaim);
            }
            else if (userForAddDto.MenuClaimId == 2)
            {
                foreach (var menuClaim in menuList)
                {
                    if (menuClaim.MenuClaimId > 12)
                    {
                        var userMenuClaim = new UserMenuClaim
                        {
                            UserId = user.UserId,
                            MenuClaimId = menuClaim.MenuClaimId,
                            Status = false

                        };

                        _userMenuService.Add(userMenuClaim);
                    }
                    else if (menuClaim.MenuClaimId == 2)
                    {
                        var userMenuClaim = new UserMenuClaim
                        {
                            UserId = user.UserId,
                            MenuClaimId = menuClaim.MenuClaimId,
                            Status = true

                        };

                        _userMenuService.Add(userMenuClaim);
                    }
                }
            }
            else if (userForAddDto.MenuClaimId == 3)
            {
                foreach (var menuClaim in menuList)
                {
                    if (menuClaim.MenuClaimId > 8 && menuClaim.MenuClaimId < 27)
                    {
                        var userMenuClaim = new UserMenuClaim
                        {
                            UserId = user.UserId,
                            MenuClaimId = menuClaim.MenuClaimId,
                            Status = false

                        };

                        _userMenuService.Add(userMenuClaim);
                    }
                    else if (menuClaim.MenuClaimId == 3)
                    {
                        var userMenuClaim = new UserMenuClaim
                        {
                            UserId = user.UserId,
                            MenuClaimId = menuClaim.MenuClaimId,
                            Status = true

                        };

                        _userMenuService.Add(userMenuClaim);
                    }
                }

            }
            else if (userForAddDto.OperationClaimId == 4)
            {
                foreach (var menuClaim in menuList)
                {
                    if (menuClaim.MenuClaimId > 3)
                    {
                        var userMenuClaim = new UserMenuClaim
                        {
                            UserId = user.UserId,
                            MenuClaimId = menuClaim.MenuClaimId,
                            Status = false

                        };

                        _userMenuService.Add(userMenuClaim);
                    }
                }
            }
            else
            {
                return new ErrorResult(Messages.UserMenuError);
            }

      
            return new SuccessResult(Messages.UserAdded);
        }


        //  [SecuredOperation("Admin,User.Update")]
        // [CacheRemoveAspect("IUserService.Get")]
        // [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {

            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }



        //    [SecuredOperation("Admin,User.UpdatePassword")]
        //   [CacheRemoveAspect("IUserService.Get")]
        //   [ValidationAspect(typeof(UserValidator))]
        public IResult UpdatePassword(UserForPassworUpdateDto userForPassworUpdatedDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserId = userForPassworUpdatedDto.UserId,
                Email = userForPassworUpdatedDto.Email,
                FirstName = userForPassworUpdatedDto.FirstName,
                LastName = userForPassworUpdatedDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userDal.Update(user);
            return new SuccessResult(Messages.UserPasswordUpdated);
        }


        [SecuredOperation("Admin,User.Delete")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }


        private IResult CheckIfEmailExists(string email)
        {
            var result = _userDal.GetAll(u => u.Email == email).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserEmailAlreadyExists);
            }
            return new SuccessResult();
        }





    }
}
