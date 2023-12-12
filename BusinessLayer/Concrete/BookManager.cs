using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        [ValidationAspect(typeof(BookValidator))]
        public IResult Add(Book book)
        {
             _bookDal.Add(book);
            return new SuccessResult(Messages.BookAdded);
        }

        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        public IDataResult<Book> GetById(int bookId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b => b.BookId == bookId));
        }
        
        public IDataResult<List<Book>> GetByBookPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.BookPrice >= min && b.BookPrice <= max));
        }

        public IDataResult<List<BookDetailDto>> GetBookDetails()
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails());
        }

        [ValidationAspect(typeof(BookValidator))]
        public IResult Update(Book book)
        {
            var result = _bookDal.GetAll(b => b.AuthorId ==  book.AuthorId).Count;
            if(result >= 10)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            throw new NotImplementedException();
        }

        public IDataResult<List<Book>> GetByCategoryId(int id)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.CategoryId == id));
        }
    }
}
