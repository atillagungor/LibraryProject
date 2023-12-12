using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;

namespace PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BookTest();
            AuthorTest();
        }

        private static void BookTest()
        {
            BookManager bookManager = new BookManager(new EfBookDal());
            foreach (var book in bookManager.GetAll().Data)
            {
                Console.WriteLine(book.BookName);
            }
        }

        private static void AuthorTest()
        {
            AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
            foreach (var author in authorManager.GetAll().Data)
            {
                Console.WriteLine(author.AuthorName);
            }
        }
    }
}
