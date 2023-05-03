namespace DapperSample.Unit
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }

    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
