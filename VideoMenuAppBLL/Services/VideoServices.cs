using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenuAppBE;
using VideoMenuAppDAL;

namespace VideoMenuAppBLL.Services
{
    public class VideoServices : IVideoMenuService
    {

        public Video Create(Video video)
        {
            Video newVideo;
            FakeDB.VideoMenu.Add(newVideo = new Video()
            {
                VideoID = FakeDB.Id++,
                Title = video.Title,
                Author = video.Author,
                Genre = video.Genre
            });
            return newVideo;
        }

        public Video Delete(int Id)
        {
            var vid = FakeDB.VideoMenu.FirstOrDefault(x => x.VideoID == Id);
            // var vid = Get(Id);
            FakeDB.VideoMenu.Remove(vid);
            return vid;
        }

        public Video Get(int id)
        {
            return FakeDB.VideoMenu.FirstOrDefault(x => x.VideoID == id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(FakeDB.VideoMenu);
        }

        public Video Update(Video video)
        {
            var videoFromDB = Get(video.VideoID);
            if (videoFromDB == null)
            {
                throw new InvalidOperationException("Video not found");
            }
            videoFromDB.Title = video.Title;
            videoFromDB.Author = video.Author;
            videoFromDB.Genre = video.Genre;
            return videoFromDB;
        }
    }
}
