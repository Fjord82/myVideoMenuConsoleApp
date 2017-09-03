using System.Collections.Generic;
using System.Linq;
using VideoMenuAppDAL.Context;
using VideoMenuAppDAL.Entities;

namespace VideoMenuAppDAL.Repositories
{
    public class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {

            this.context = context;
        }

        public Video Create(Video video)
        {
            
            this.context.Videos.Add(video);

            return video;

        }

        public Video Delete(int Id)
        {
            //var vid = VideoMenu.FirstOrDefault(x => x.VideoID == Id);
            var vid = Get(Id);
			
            this.context.Videos.Remove(vid);

			return vid;
        }

        public Video Get(int id)
        {
            return this.context.Videos.FirstOrDefault(x => x.VideoID == id);
        }

        public List<Video> GetAll()
        {
            return this.context.Videos.ToList();
        }
    }
}
