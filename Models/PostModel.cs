using AspNetCoreGeneratedDocument;
using Microsoft.VisualBasic;

namespace HelpDevs.Models
{
    public class PostModel
    {
        int Id { get; set; }
        string Text { get; set; }
        User _User;

        DateAndTime DatePosted { get; set; }

        public PostModel(User user)
        {
            _User = user;
        }

        

    }
}