﻿using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenuAppBE;
using VideoMenuAppDAL;

namespace VideoMenuAppBLL.Services
{
    public class VideoServices : IVideoMenuService
    {
        IVideoRepository vidRepo;

        public VideoServices(IVideoRepository vidRepo)
        {
            this.vidRepo = vidRepo;
        }

        public Video Create(Video video)
        {
            return this.vidRepo.Create(video);
        }

        public Video Delete(int Id)
        {
            return this.vidRepo.Delete(Id);
        }

        public Video Get(int Id)
        {
           return this.vidRepo.Get(Id);
        }

        public List<Video> GetAll()
        {
            return this.vidRepo.GetAll();
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
