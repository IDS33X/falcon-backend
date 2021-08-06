using System.Threading.Tasks;
using Repository.Context;
using Repository.Repository;
using Repository.RepositoryImpl;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //Fields
        private readonly FalconDbContext context;

        //Constructor
        public UnitOfWork(FalconDbContext context){
            this.context = context;
            Employees = new EmployeeRepository(this.context);
        }

        //Properties
        public IEmployeeRepository Employees { get; private set;}

        //Methods
        public int Complete()
        {
            return context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}