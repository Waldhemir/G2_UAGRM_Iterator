using System;
using System.Collections.Generic;

namespace Iterator
{
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

    // Creamos el GoogleApi.
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
            return new GoogleUserIterator(googleUsers);
        }
    }

    //Creamos la clase GoogleUser.
    public class GoogleUser
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public GoogleUser(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}";
        }
    }

    // Implementamos el Iterator para GoogleUser.
    public class GoogleUserIterator : IIterator<GoogleUser>
    {
        private List<GoogleUser> users;
        private int index;

        public GoogleUserIterator(List<GoogleUser> users)
        {
            this.users = users;
            this.index = 0;
        }

        public GoogleUser Current
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

    //Mostramos los usuarios de Google utilizando el Iterator
    public class ShowUsersPanel
    {
        private readonly GoogleApi googleApi;

        public ShowUsersPanel()
        {
            this.googleApi = new GoogleApi();
        }

        public void Show()
        {
            var googleIterator = this.googleApi.GetIterator();

            while (googleIterator.HasNext())
            {
                Console.WriteLine(googleIterator.Current);
                googleIterator.Next();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var showUsersPanel = new ShowUsersPanel();
            showUsersPanel.Show();
        }
    }

}

