using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBookDal:EfEntityRepositoryBase<Book,LibraryContext>, IBookDal
    {
        public List<BookDetailDto> GetBookDetails()
        {
            using (LibraryContext context = new LibraryContext())
            {
                var result = from b in context.Books
                             join a in context.Authors
                             on b.AuthorId equals a.AuthorId
                             select new BookDetailDto { BookId = b.BookId, BookName = b.BookName, AuthorName = a.AuthorName, BookPrice = b.BookPrice };
                return result.ToList();
            }
        }
    }
}
