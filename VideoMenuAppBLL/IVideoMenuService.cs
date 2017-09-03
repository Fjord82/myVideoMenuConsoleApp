using System;
using System.Collections.Generic;
using VideoMenuAppBLL.BusinessObjects;

namespace VideoMenuAppBLL
{
    public interface IVideoMenuService
    {
        // C - Create a new element
        VideoBO Create(VideoBO Video);

        // R - Read all or a single element 
        List<VideoBO> GetAll();
        VideoBO Get(int id);

        // U - Update an existing element
        VideoBO Update(VideoBO video);

        // D - Delete an element by Id
        VideoBO Delete(int Id);

    }
}
