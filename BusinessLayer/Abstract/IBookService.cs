using CoreLayer.Utilities.Results;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<List<Book>> GetByCategoryId(int id);
        IDataResult<List<Book>> GetByBookPrice(decimal min, decimal max);
        IDataResult<List<BookDetailDto>> GetBookDetails();
        IDataResult<Book> GetById(int bookId);
        IResult Add(Book book);
        IResult Update(Book book);
    }
}
