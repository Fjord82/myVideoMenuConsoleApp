using System.Collections.Generic;
using VideoMenuAppDAL.Entities;

namespace VideoMenuAppDAL
{
    public interface IVideoRepository
    {
		// C - Create a new element
		Video Create(Video Video);

		// R - Read all or a single element 
		List<Video> GetAll();
		Video Get(int id);

		/** U - Update an existing element
		 * NO update for the repository as this will be a task for Unit Of Work
		 * Video Update(Video video);
		**/

		// D - Delete an element by Id
		Video Delete(int Id);
    }
}
