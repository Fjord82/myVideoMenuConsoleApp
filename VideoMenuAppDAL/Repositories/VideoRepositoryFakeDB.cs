using System.Collections.Generic;
using System.Linq;
using VideoMenuAppDAL.Entities;

namespace VideoMenuAppDAL.Repositories
{
    public class VideoRepositoryFakeDB : IVideoRepository
    {
		private static int Id = 1;

		private static List<Video> VideoMenu = new List<Video>();

        public Video Create(Video video)
        {
			Video newVideo;
			VideoMenu.Add(newVideo = new Video()
			{
				VideoID = Id++,
				Title = video.Title,
				Author = video.Author,
				Genre = video.Genre
			});
			return newVideo;
        }

        public Video Delete(int Id)
        {
			var vid = VideoMenu.FirstOrDefault(x => x.VideoID == Id);
			// var vid = Get(Id);
			VideoMenu.Remove(vid);
			return vid;
        }

        public Video Get(int id)
        {
            return VideoMenu.FirstOrDefault(x => x.VideoID == id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(VideoMenu);
        }
    }
}
