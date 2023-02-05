using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class MoneyTrackingContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Database=MoneyTracking2022;Trusted_Connection=true");
        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Cancellation> Cancellations { get; set; }
        public DbSet<CardPayment> CardPayments { get; set; }
        public DbSet<CentralPay> CentralPayouts { get; set; }
        public DbSet<CustomerPay> CustomerPayouts { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<FutureMoney> FutureMoneys { get; set; }
        public DbSet<FutureMoneyCancellation> FutureMoneyCancellations { get; set; }
        public DbSet<IncomingMoney> IncomingMoneys { get; set; }
        public DbSet<MonetaryDeficit> MonetaryDeficits { get; set; }
        public DbSet<MoneyDeposited> MoneyDepositeds { get; set; }
        public DbSet<MoneyOutput> MoneyOutputs { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<SafeBox> SafeBoxes { get; set; }
        public DbSet<ShipmentList> ShipmentLists { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffTask> StaffTasks { get; set; }
        public DbSet<StaffEpisode> StaffEpisodes { get; set; }
        public DbSet<Satisfaction> Satisfactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<MenuClaim> MenuClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<UserMenuClaim> UserMenuClaims { get; set; }





    }
}
