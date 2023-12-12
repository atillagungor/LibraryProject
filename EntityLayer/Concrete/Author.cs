using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author:IEntity
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
