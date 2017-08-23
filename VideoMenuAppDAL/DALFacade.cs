using System;
using VideoMenuAppDAL.Repositories;

namespace VideoMenuAppDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            get { return new VideoRepositoryFakeDB(); }
        }
    }
}
