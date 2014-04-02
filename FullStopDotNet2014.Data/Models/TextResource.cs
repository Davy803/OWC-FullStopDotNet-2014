using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStopDotNet2014.Data.Models
{
    
    public class TextResource
    {
        [Key, Column(Order = 0)]
        public string Name { get; set; }
        [Key, Column(Order = 1)]
        public string Culture { get; set; }

        public string Value { get; set; }
    }
}
