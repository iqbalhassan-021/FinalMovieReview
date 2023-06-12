using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalMovieReview.Shared.Model;

namespace FinalMovieReview.Server.Data
{
    public class FinalMovieReviewServerContext : DbContext
    {
        public FinalMovieReviewServerContext (DbContextOptions<FinalMovieReviewServerContext> options)
            : base(options)
        {
        }

        public DbSet<FinalMovieReview.Shared.Model.MData> MData { get; set; } = default!;

        public DbSet<FinalMovieReview.Shared.Model.MReviews> MReviews { get; set; } = default!;
    }
}
