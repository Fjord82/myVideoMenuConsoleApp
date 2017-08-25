using System;
using VideoMenuAppDAL.Repositories;
using VideoMenuAppDAL.UOW;

namespace VideoMenuAppDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            //get { return new VideoRepositoryFakeDB(); }
            get
            {
                return new VideoRepositoryEFMemory(
                    new Context.InMemoryContext());

            }
        }

        public IUnitOfWork UnitOfWork
		{
			get
			{
				return new UnitOfWorkMem();
			}
		}
    }
}
