namespace DapperSample.Dapper
{
    public interface IContext : IDisposable
    {
        bool IsTransactionStarted { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}