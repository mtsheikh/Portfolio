using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using JustBlog.Core.Objects;

namespace JustBlog.Core.Mappings
{
    public class PostMap: ClassMap<Post>
    {
        public PostMap()
        {
            Id(x => x.Id);

            Map(x => x.Title)
                .Length(500)
                .Not.Nullable();

            Map(x => x.ShortDescription)
                .Length(5000)
                .Not.Nullable();

            Map(x => x.Description)
                .Length(5000)
                .Not.Nullable();

            Map(x => x.Meta)
                .Length(1000)
                .Not.Nullable();

            Map(x => x.UrlSlug)
                .Length(200)
                .Not.Nullable();

            Map(x => x.Published)
                .Not.Nullable();

            Map(x => x.PostedOn)
                .Not.Nullable();

            Map(x => x.Modified);

            // References method is used to represent the
            // many to one relationship between Post and
            // category through a foreign key cloumn category
            // in the post table

            References(x => x.Category)
                .Column("Category")
                .Not.Nullable();
            
            // many to many relationship between post and tag
            HasManyToMany(x => x.Tags)
                .Table("PostTagMap");

            Table("tbl_posts");
            Map(x => x.Title).Column("post_title");
        }
    }
}
