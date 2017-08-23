using System;
using System.Collections.Generic;

using VideoMenuAppBE;

namespace VideoMenuAppBLL
{
    public interface IVideoMenuService
    {
        // C - Create a new element
        Video Create(Video Video);

        // R - Read all or a single element 
        List<Video> GetAll();
        Video Get(int id);

        // U - Update an existing element
        Video Update(Video video);

        // D - Delete an element by Id
        Video Delete(int Id);

    }
}
