

namespace Tidwit.Libraries.Domain.Entities.Library
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System;


    [Table("users")]
    public class Library : EntityBase
    {
        public string Description { set; get; }
        public DateTime PublishDate { set; get; }
        public string Language { set; get; }
        public bool IsPublic { set; get; }
        public string ParentLibrary { set; get; }
        public string UrlImage { set; get; }
        public string FilePath { set; get; }
    }
}
