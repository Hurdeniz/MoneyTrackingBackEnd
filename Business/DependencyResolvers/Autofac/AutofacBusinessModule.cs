using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BankManager>().As<IBankService>().SingleInstance();
            builder.RegisterType<EfBankDal>().As<IBankDal>().SingleInstance();

            builder.RegisterType<CancellationManager>().As<ICancellationService>().SingleInstance();
            builder.RegisterType<EfCancellationDal>().As<ICancellationDal>().SingleInstance();

            builder.RegisterType<CardPaymentManager>().As<ICardPaymentService>().SingleInstance();
            builder.RegisterType<EfCardPaymentDal>().As<ICardPaymentDal>().SingleInstance();

            builder.RegisterType<CentralPayManager>().As<ICentralPayService>().SingleInstance();
            builder.RegisterType<EfCentralPayDal>().As<ICentralPayDal>().SingleInstance();

            builder.RegisterType<CustomerPayManager>().As<ICustomerPayService>().SingleInstance();
            builder.RegisterType<EfCustomerPayDal>().As<ICustomerPayDal>().SingleInstance();

            builder.RegisterType<ExpenditureManager>().As<IExpenditureService>().SingleInstance();
            builder.RegisterType<EfExpenditureDal>().As<IExpenditureDal>().SingleInstance();

            builder.RegisterType<FutureMoneyManager>().As<IFutureMoneyService>().SingleInstance();
            builder.RegisterType<EfFutureMoneyDal>().As<IFutureMoneyDal>().SingleInstance();

            builder.RegisterType<FutureMoneyCancellationManager>().As<IFutureMoneyCancellationService>().SingleInstance();
            builder.RegisterType<EfFutureMoneyCancellationDal>().As<IFutureMoneyCancellationDal>().SingleInstance();

            builder.RegisterType<IncomingMoneyManager>().As<IIncomingMoneyService>().SingleInstance();
            builder.RegisterType<EfIncomingMoneyDal>().As<IIncomingMoneyDal>().SingleInstance();

            builder.RegisterType<MenuClaimManager>().As<IMenuClaimService>().SingleInstance();
            builder.RegisterType<EfMenuClaimDal>().As<IMenuClaimDal>().SingleInstance();

            builder.RegisterType<MonetaryDeficitManager>().As<IMonetaryDeficitService>().SingleInstance();
            builder.RegisterType<EfMonetaryDeficitDal>().As<IMonetaryDeficitDal>().SingleInstance();

            builder.RegisterType<MoneyDepositedManager>().As<IMoneyDepositedService>().SingleInstance();
            builder.RegisterType<EfMoneyDepositedDal>().As<IMoneyDepositedDal>().SingleInstance();

            builder.RegisterType<MoneyOutputManager>().As<IMoneyOutputService>().SingleInstance();
            builder.RegisterType<EfMoneyOutputDal>().As<IMoneyOutputDal>().SingleInstance();

            builder.RegisterType<NoteManager>().As<INoteService>().SingleInstance();
            builder.RegisterType<EfNoteDal>().As<INoteDal>().SingleInstance();

            builder.RegisterType<OperationManager>().As<IOperationService>().SingleInstance();
            builder.RegisterType<EfOperationDal>().As<IOperationDal>().SingleInstance();

            builder.RegisterType<SafeBoxManager>().As<ISafeBoxService>().SingleInstance();
            builder.RegisterType<EfSafeBoxDal>().As<ISafeBoxDal>().SingleInstance();

            builder.RegisterType<SatisfactionManager>().As<ISatisfactionService>().SingleInstance();
            builder.RegisterType<EfSatisfactionDal>().As<ISatisfactionDal>().SingleInstance();

            builder.RegisterType<ShipmentListManager>().As<IShipmentListService>().SingleInstance();
            builder.RegisterType<EfShipmentListDal>().As<IShipmentListDal>().SingleInstance();

            builder.RegisterType<StaffManager>().As<IStaffService>().SingleInstance();
            builder.RegisterType<EfStaffDal>().As<IStaffDal>().SingleInstance();

            builder.RegisterType<StaffEpisodeManager>().As<IStaffEpisodeService>().SingleInstance();
            builder.RegisterType<EfStaffEpisodeDal>().As<IStaffEpisodeDal>().SingleInstance();

            builder.RegisterType<StaffTaskManager>().As<IStaffTaskService>().SingleInstance();
            builder.RegisterType<EfStaffTaskDal>().As<IStaffTaskDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<UserOperationManager>().As<IUserOperationService>().SingleInstance();
            builder.RegisterType<EfUserOperationDal>().As<IUserOperationDal>().SingleInstance();

            builder.RegisterType<UserMenuManager>().As<IUserMenuService>().SingleInstance();
            builder.RegisterType<EfUserMenuDal>().As<IUserMenuDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
