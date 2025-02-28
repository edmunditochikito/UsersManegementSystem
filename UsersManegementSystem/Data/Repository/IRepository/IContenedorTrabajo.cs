namespace UsersManegementSystem.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        IUserRepository User { get; }
        void Save();
    }
}
