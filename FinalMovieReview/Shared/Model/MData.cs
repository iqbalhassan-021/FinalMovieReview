using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMovieReview.Shared.Model
{
    public class MData
    {   [Key]
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public float MovieRating { get; set; }
    }
}
