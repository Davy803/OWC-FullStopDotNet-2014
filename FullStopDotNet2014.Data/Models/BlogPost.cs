using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FullStopDotNet2014.Common.Enums;
using FullStopDotNet2014.Common.ModelInterfaces;

namespace FullStopDotNet2014.Data.Models
{
    public class BlogPost : IBlogPost
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }

        [MaxLength(128)]
        public string UserId { get; set; }

        public DateTime PublishDate { get; set; }

        public PublishStatus Status { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
