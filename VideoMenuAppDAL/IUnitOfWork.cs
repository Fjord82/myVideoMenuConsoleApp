using System;
namespace VideoMenuAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }

        int Complete();
    }
}
