using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Data.Contexts;
using TatBlog.Core.Entities;

namespace TatBlog.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;
        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();
            if (_dbContext.Posts.Any()) return;
            var authors = AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts = AddPosts(authors, categories, tags);
        }

        private IList<Author> AddAuthors()
        {
            var authors = new List<Author>()
            {
                new()
                {
                    FullName = "Jason Mouth",
                    UrlSlug = "jason-mouth",
                    Email ="json@gmail.com",
                    JoinedDate = new DateTime(2022,10,21)
                },
                new()
                {
                    FullName = "Tuệ An",
                    UrlSlug = "tue-an",
                    Email ="tuean5@gmail.com",
                    JoinedDate = new DateTime(2018,2,19)
                },
                new()
                {
                    FullName = "Admin",
                    UrlSlug = "admin",
                    Email ="admin@gmail.com",
                    JoinedDate = new DateTime(2022,5,21)
                },
                new()
                {
                    FullName = "Mẫn An",
                    UrlSlug = "man-an",
                    Email ="manan12@gmail.com",
                    JoinedDate = new DateTime(2017,2,4)
                },
                new()
                {
                    FullName = "Thanh Phong",
                    UrlSlug = "thanhphong",
                    Email ="thanhphong75@gmail.com",
                    JoinedDate = new DateTime(2021,3,6)
                },
                new()
                {
                    FullName = "Hoài Niệm",
                    UrlSlug = "hoainiem",
                    Email ="hoainiem789@gmail.com",
                    JoinedDate = new DateTime(2012,7,1)
                }
            };
            _dbContext.Author.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        }
        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new() { Name =".Net Core", Description =".Net Core", UrlSlug = "net-core", ShowOnMenu = true },
                new() { Name ="Architecture", Description ="Architecture", UrlSlug = "architecture", ShowOnMenu = true},
                new() { Name ="Messaging", Description ="Messaging", UrlSlug = "messaging", ShowOnMenu = true},
                new() { Name ="OOP", Description ="OOP", UrlSlug = "oop", ShowOnMenu = true},
                new() { Name ="Design Patterns", Description ="Design Patterns", UrlSlug = "design-patterns", ShowOnMenu = true},
                new() { Name ="Sống", Description ="Sống", UrlSlug = "song", ShowOnMenu = true},
                new() { Name ="Câu chuyện cuộc sống", Description ="Câu chuyện cuộc sống", UrlSlug = "cauchuyenvecuocsong", ShowOnMenu = true },
                new() { Name ="Yêu thương, liệu có giản đơn", Description ="Yêu thương, liệu có giản đơn", UrlSlug = "yeuthuonglieucogiandon", ShowOnMenu = true},
                new() { Name ="Người bạn tri kỉ", Description ="Người bạn tri kỉ", UrlSlug = "nguoibantriki", ShowOnMenu = true},
                new() { Name ="Thiên nhiên, động vật", Description ="Thiên nhiên, động vật", UrlSlug = "thiennhiendongvat", ShowOnMenu = true},
                new() { Name ="Hạnh phúc ở đâu? Ở ngay cách mà bạn đối diện với cuộc sống ấy", Description ="Hạnh phúc ở đâu? Ở ngay cách mà bạn đối diện với cuộc sống ấy", UrlSlug = "hanhphucodau", ShowOnMenu = true},
                new() { Name ="trái tim", Description ="Trái tim", UrlSlug = "traitim", ShowOnMenu = true },
                
            };
            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();
            return categories;
        }
        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new() {Name = "Google", Description = "Google applications", UrlSlug="google-applications"},
                new() {Name = "ASP.NET MVC", Description = "ASP.NET MVC", UrlSlug="asp.net-mvc"},
                new() {Name = "Razor Page", Description = "Razor Page", UrlSlug="razor-page"},
                new() {Name = "Blazor", Description = "Blazor", UrlSlug="blazor"},
                new() {Name = "Neural Network", Description = "Neural Network", UrlSlug="neural-network"},
                new() {Name = "Sống", Description = "Sống", UrlSlug="song"},
                new() {Name = "Câu chuyện cuộc sống", Description ="Câu chuyện cuộc sống", UrlSlug = "cauchuyenvecuocsong"},
                new() {Name = "Hạnh phúc", Description ="Hạnh phú ở đâu?", UrlSlug = "hanhphucodau"},
                new() {Name = "trái tim", Description = "traitim", UrlSlug="trai-tim"}
                

            };
            _dbContext.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }
        private IList<Post> AddPosts(
            IList<Author> authors,
            IList<Category> categories,
            IList<Tag> tags)
        {
            var posts = new List<Post>()
            {
                new()
                {
                    Title ="ASP.NET Core Diagnostic Scenarios",
                    ShortDescription = "David and friends has a great repos",
                    Description = "Here's a few great DON'T and DO examples",
                    Meta = "David and friends has a great repos",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },
                new()
                {
                    Title ="10 điều ai cũng phải khắc cốt ghi tâm nếu muốn có một cuộc đời suôn sẻ",
                    ShortDescription = "Cuộc sống thay đổi, vận động không ngừng nghỉ… vì thế nếu bạn muốn đứng vững trong xã hội này, nhất định phải ghi nhớ 10 bài học sau.",
                    Description = "Cuộc sống thay đổi, vận động không ngừng nghỉ… vì thế nếu bạn muốn đứng vững trong xã hội này, nhất định phải ghi nhớ 10 bài học sau.",
                    Meta = " khắc cốt ghi tâm",
                    UrlSlug = "10-dieu-ai-cung-phai-khac-cot-ghi-tam",
                    Published = true,
                    PostedDate = new DateTime(2018,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 20,
                    Author = authors[1],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },
                new()
                {
                    Title ="Câu chuyện ý nghĩa dành cho người đi làm: Hãy làm việc bằng cái tâm, Chức danh có thực sự quan trọng, Đi hay ở là sự lựa chọn",
                    ShortDescription = "Trong cuộc sống, không ít những kẻ nhờ thủ đoạn, hoặc do may mắn, bỗng ngồi vào một ví trí nào đó, thấy những người xung quanh đều xum xoe nịnh nọt, bổng lộc tự đến đầy nhà… thì tưởng mình là tài năng, cao quý và oai vệ lắm.\r\n\r\n",
                    Description = "Trong cuộc sống, không ít những kẻ nhờ thủ đoạn, hoặc do may mắn, bỗng ngồi vào một ví trí nào đó, thấy những người xung quanh đều xum xoe nịnh nọt, bổng lộc tự đến đầy nhà… thì tưởng mình là tài năng, cao quý và oai vệ lắm.\r\n\r\n",
                    Meta = "hãy làm việc bằng cái tâm,",
                    UrlSlug = "cau-chuyen-y-nghia-danh-cho-nguoi-di",
                    Published = true,
                    PostedDate = new DateTime(2009,9,3,1,2,0),
                    ModifiedDate = null,
                    ViewCount = 15,
                    Author = authors[2],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[2]
                    }
                },
                new()
                {
                    Title ="Hạnh phúc ở đâu? Ở ngay cách mà bạn đối diện với cuộc sống ấy",
                    ShortDescription = "mong muốn hôm nay vui vẻ hay không vui vẻ",
                    Description = "mong muốn hôm nay vui vẻ hay không vui vẻ",
                    Meta = "Hạnh phúc ở đâu?",
                    UrlSlug = "hanhphucodau",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[4],
                    Category = categories[4],
                    Tags = new List<Tag>()
                    {
                        tags[4]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new()
                {
                    Title ="Hỡi những trái tim tuổi 25, đừng sợ!",
                    ShortDescription = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Description = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    Meta = "Khi bạn coi tuổi tác chỉ là con số để tượng trưng, thì chẳng có gì để sợ hãi cả!",
                    UrlSlug = "tuoi25dungso",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                }

            };
            _dbContext.AddRange(posts);
            _dbContext.SaveChanges();
            return posts;
        }

    }

}
