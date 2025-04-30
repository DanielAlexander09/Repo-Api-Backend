using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBook.Core.Application.ViewModels
{
    public class AutorViewModels
    {

       public int id { get; set; }  

        public int idBook { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
       

        
    }
}

