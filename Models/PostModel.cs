using AspNetCoreGeneratedDocument;
using Microsoft.VisualBasic;

namespace HelpDevs.Models
{
    public class Post
    {
        int Id { get; set; }

        public User _User;
        public string Text { get; set; }

        public DateAndTime DatePosted { get; set; }

        public Post(User user)
        {
            _User = user;
        }

        

    }
}