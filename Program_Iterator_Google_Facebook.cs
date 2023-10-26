using System;
using System.Collections.Generic;

namespace Iterator
{
    public interface IUser
    {
        string GetName();
        string GetInfo();
    }

    public class GoogleUser : IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public GoogleUser(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetInfo()
        {
            return $"Name: {Name}, Email: {Email}";
        }
    }

    public class FacebookUser : IUser
    {
        public string FbName { get; set; }
        public string FbUrl { get; set; }

        public FacebookUser(string fbName, string fbUrl)
        {
            FbName = fbName;
            FbUrl = fbUrl;
        }

        public string GetName()
        {
            return FbName;
        }

        public string GetInfo()
        {
            return $"Name: {FbName}, URL: {FbUrl}";
        }
    }

    // Definimos una interfaz Iterator genérica.
    public interface IIterator<T>
    {
        T Current { get; }
        bool HasNext();
        void Next();
    }

    // Definimos una interfaz Iterable genérica.
    public interface IEnumerableCollection<T>
    {
        IIterator<T> GetIterator();
    }

    public class UserIterator<T> : IIterator<T> where T : IUser
    {
        private List<T> users;
        private int index;

        public UserIterator(List<T> users)
        {
            this.users = users;
            this.index = 0;
        }

        public T Current
        {
            get { return users[index]; }
        }

        public bool HasNext()
        {
            return index < users.Count;
        }

        public void Next()
        {
            index++;
        }
    }

    public class ShowUsersPanel
    {
        public void ShowUsers<T>(IEnumerableCollection<T> api) where T : IUser
        {
            var iterator = api.GetIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Current.GetInfo());
                iterator.Next();
            }
        }
    }

    //Generamos el GoogleApi
    public class GoogleApi : IEnumerableCollection<GoogleUser>
    {
        private readonly List<GoogleUser> googleUsers = new List<GoogleUser>();

        public GoogleApi()
        {
            googleUsers.Add(new GoogleUser("roberto", "r@gmail.com"));
            googleUsers.Add(new GoogleUser("luis", "l@gmail.com"));
            googleUsers.Add(new GoogleUser("ana", "a@gmail.com"));
        }

        public IIterator<GoogleUser> GetIterator()
        {
            return new UserIterator<GoogleUser>(googleUsers);
        }
    }


    //Generamos el FacebookApi
    public class FacebookApi : IEnumerableCollection<FacebookUser>
    {
        public List<FacebookUser> GetFacebookUsers()
        {
            return new List<FacebookUser>
            {
                new FacebookUser("juan", "link1"),
                new FacebookUser("carlos", "link2")
            };
        }

        public IIterator<FacebookUser> GetIterator()
        {
            return new UserIterator<FacebookUser>(GetFacebookUsers());
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var showUsersPanel = new ShowUsersPanel();

            Console.WriteLine("Google Users:");
            var googleApi = new GoogleApi();
            showUsersPanel.ShowUsers(googleApi);

            Console.WriteLine("Facebook Users:");
            var facebookApi = new FacebookApi();
            showUsersPanel.ShowUsers(facebookApi);
        }
    }
}


