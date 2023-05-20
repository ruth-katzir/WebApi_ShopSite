using entities;
using Repository;
using System.Text.Json;

namespace Service
{
    public class RatingService :IRatingService
    {

        IRatingRepository repository;

        public RatingService(IRatingRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Rating> addRatingAsync(Rating rating)
        {
            return await repository.addRatingAsync(rating);
        }
    }
}
