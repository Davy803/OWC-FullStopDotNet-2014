using System;
using FullStopDotNet2014.Common.Enums;

namespace FullStopDotNet2014.Common.ModelInterfaces
{
    public interface IBlogPost
    {
        int Id { get; set; }
        string Header { get; set; }
        string Slug { get; set; }
        string Body { get; set; }

        
        string UserId { get; set; }

        DateTime PublishDate { get; set; }
        PublishStatus Status { get; set; }
    }
}