using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Objects;

namespace JustBlog.Core
{
    public interface IBlogRepository
    {
        // used to return the latest published posts based on pagination values
        IList<Post> Posts(int pageNo, int pageSize);
        // returns the tital no. of published posts 
        int TotalPosts();
    }
}
