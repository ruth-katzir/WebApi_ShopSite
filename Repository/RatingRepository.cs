using entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {

        MyShopSite325593952Context _DbContext;

        public RatingRepository(MyShopSite325593952Context dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Rating>  addRatingAsync(Rating rating)
        {
            await _DbContext.Ratings.AddAsync(rating);
            await _DbContext.SaveChangesAsync();
            return rating;
        }
    }
}
