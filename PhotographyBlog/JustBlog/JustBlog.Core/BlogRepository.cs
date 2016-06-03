using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Objects;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Transform;

namespace JustBlog.Core
{
    public class BlogRepository : IBlogRepository
    {
        //Nhibernate object 
        private readonly ISession _session;

        //ISession is the persistence manager interface that is used to store and retrieve entities to and from the database.

        public BlogRepository(ISession session)
        {
            _session = session;
        }

        // This method uses the interface to return the latest published posts based on pagination values
        public IList<Post> Posts(int pageNo, int pageSize)
        {
            //we've queried database twice to get the posts because we've to eager load all the associated tags.
            //We can't use FetchMany along with Skip and Take methods in the Linq query. 
            //So, first we've fetched all the posts then from their ids we've queried again to get them with their tags.
            var posts = _session.Query<Post>()
                                .Where(p => p.Published)
                                .OrderByDescending(p => p.PostedOn)
                                .Skip(pageNo * pageSize)
                                .Take(pageSize)
                                .Fetch(p => p.Category)
                                .ToList();

            // this assigns the posts in the Ilist to their respective Id
            var postIds = posts.Select(p => p.Id).ToList();

            return _session.Query<Post>()
                   .Where(p => postIds.Contains(p.Id))
                   .OrderByDescending(p => p.PostedOn)
                   .FetchMany(p => p.Tags)
                   .ToList();
        }
        // returns the total number of published posts 
        public int TotalPosts()
        {
            return _session.Query<Post>().Where(p => p.Published).Count();
        }

    }
}
