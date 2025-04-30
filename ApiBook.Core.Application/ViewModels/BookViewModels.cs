using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiBook.Core.Application.ViewModels
{
    public class BookViewModels
    {
        public int id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public int pageCount{ get; set; }
        
        public string excerpt { get; set; }

        public DateTime publishDate { get; set; }
    }
}

