﻿using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenuAppBE;
using VideoMenuAppDAL;

namespace VideoMenuAppBLL.Services
{
    public class VideoServices : IVideoMenuService
    {
        DALFacade facade;

        public VideoServices(DALFacade facade)
        {
            this.facade = facade;
        }

        public Video Create(Video video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(video);
                uow.Complete();
                return newVid;
            }
        }

        public Video Delete(int Id)
        {
			using (var uow = facade.UnitOfWork)
			{
                var newVid = uow.VideoRepository.Delete(Id);
				uow.Complete();
				return newVid;
			}
        }

        public Video Get(int Id)
        {
			using (var uow = facade.UnitOfWork)
			{
				return uow.VideoRepository.Get(Id);
			}
        }

        public List<Video> GetAll()
        {
			using (var uow = facade.UnitOfWork)
			{
				return uow.VideoRepository.GetAll();
			}
        }

        public Video Update(Video video)
        {
            using(var uow = facade.UnitOfWork)
            {
                var videoFromDB = uow.VideoRepository.Get(video.VideoID);
				if (videoFromDB == null)
				{
					throw new InvalidOperationException("Video not found");
				}
				videoFromDB.Title = video.Title;
				videoFromDB.Author = video.Author;
				videoFromDB.Genre = video.Genre;
                uow.Complete();
				return videoFromDB;
            }
        }
    }
}
