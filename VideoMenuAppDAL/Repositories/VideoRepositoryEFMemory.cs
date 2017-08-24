﻿using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenuAppBE;
using VideoMenuAppDAL.Context;

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
            this.context.SaveChanges();
            return video;

        }

        public Video Delete(int Id)
        {
            //var vid = VideoMenu.FirstOrDefault(x => x.VideoID == Id);
            var vid = Get(Id);
			
            this.context.Videos.Remove(vid);
            this.context.SaveChanges();
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
