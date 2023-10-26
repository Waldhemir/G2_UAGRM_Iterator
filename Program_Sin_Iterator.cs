using System;
using System.Collections.Generic;

namespace Iterator
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string FbName { get; set; }
        public string FbUrl { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public User(string fbName, string fbUrl, bool isFacebookUser = true)
        {
            if (isFacebookUser)
            {
                FbName = fbName;
                FbUrl = fbUrl;
            }
        }

        public string GetInfo(bool isFacebookUser = false)
        {
            if (isFacebookUser)
            {
                return $"Name: {FbName}, URL: {FbUrl}";
            }
            else
            {
                return $"Name: {Name}, Email: {Email}";
            }
        }
    }

    public class ShowUsersPanel
    {
        public void ShowUsers(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.GetInfo());
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var showUsersPanel = new ShowUsersPanel();

            Console.WriteLine("Google Users:");
            var googleUsers = new List<User>
            {
                new User("roberto", "r@gmail.com"),
                new User("luis", "l@gmail.com"),
                new User("ana", "a@gmail.com")
            };
            showUsersPanel.ShowUsers(googleUsers);

            Console.WriteLine("Facebook Users:");
            var facebookUsers = new List<User>
            {
                new User("juan", "link1", true),
                new User("carlos", "link2", true)
            };
            showUsersPanel.ShowUsers(facebookUsers);
        }
    }
}
