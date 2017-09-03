﻿using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenuAppBLL.BusinessObjects;
using VideoMenuAppDAL;
using VideoMenuAppDAL.Entities;

namespace VideoMenuAppBLL.Services
{
    public class VideoServices : IVideoMenuService
    {
        DALFacade facade;

        public VideoServices(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(Convert(video));
                uow.Complete();
                return Convert(newVid);
            }
        }

        public VideoBO Delete(int Id)
        {
			using (var uow = facade.UnitOfWork)
			{
                var newVid = uow.VideoRepository.Delete(Id);
				uow.Complete();
                return Convert(newVid);
			}
        }

        public VideoBO Get(int Id)
        {
			using (var uow = facade.UnitOfWork)
			{
                return Convert(uow.VideoRepository.Get(Id));
			}
        }

        public List<VideoBO> GetAll()
        {
			using (var uow = facade.UnitOfWork)
			{
                //Video -> VideoBO
                //return uow.VideoRepository.GetAll();
                return uow.VideoRepository.GetAll().Select(vid => Convert(vid)).ToList();
			}
        }

        public VideoBO Update(VideoBO video)
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
                return Convert(videoFromDB);
            }
        }

        private Video Convert(VideoBO vid)
        {
            return new Video()
            {
                VideoID = vid.VideoID,
                Title = vid.Title,
                Author = vid.Author,
                Genre = vid.Genre
            };
        }

		private VideoBO Convert(Video vid)
		{
			return new VideoBO()
			{
				VideoID = vid.VideoID,
				Title = vid.Title,
				Author = vid.Author,
				Genre = vid.Genre
			};
		}
    }
}
