﻿using System;
using VideoMenuAppBLL.Services;
using VideoMenuAppDAL;

namespace VideoMenuAppBLL
{
    public class BLLFacade
    {
        /**
        public IVideoMenuService GetVideoServices()
        {
            return new VideoServices();
        }**/

        public IVideoMenuService VideoServices
        {
            get { return new VideoServices(new DALFacade().VideoRepository); }
        }

    }
}
