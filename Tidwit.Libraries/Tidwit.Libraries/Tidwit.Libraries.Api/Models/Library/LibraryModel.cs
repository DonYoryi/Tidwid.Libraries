using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tidwit.Libraries.Api.Models
{
    public class LibraryModel
    {
        public int Id { set; get; }
        public string Name {set;get;}
        public string Description {set;get;}
        public DateTime PublishDate {set;get;}
        public string Language {set;get;}
        public bool IsPublic {set;get;}
        public string ParentLibrary {set;get;}
        public string UrlImage {set;get;}
        public string FilePath { set; get; }
    }
}
