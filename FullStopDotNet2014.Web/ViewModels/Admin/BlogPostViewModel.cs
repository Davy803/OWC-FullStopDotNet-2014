using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FullStopDotNet2014.Common.Enums;
using FullStopDotNet2014.Common.ModelInterfaces;
using FullStopDotNet2014.Data.Models;

namespace FullStopDotNet2014.Web.ViewModels.Admin
{
    public class BlogPostViewModel : IBlogPost
    {
        
        public int Id { get; set; }
        public string Header { get; set; }
        public string Slug { get; set; }

        [AllowHtml]
        [UIHint("WysiwygString")]
        public string Body { get; set; }

        [UIHint("UserSelect")]
        public string UserId { get; set; }
        
        public string UserName { get; set; }

        public DateTime PublishDate { get; set; }

        public PublishStatus Status { get; set; }
    }
}