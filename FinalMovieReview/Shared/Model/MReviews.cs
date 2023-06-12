using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMovieReview.Shared.Model
{
    public class MReviews
    {
        [Key]
        public int user { get; set; }
        public float MRating { get; set; }
        public string MDesc { get; set; }
    }
}
