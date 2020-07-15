namespace Code.Common
{
    /// <summary>
    /// Хранит информацию о рейтинге корабля для отображения наград или в лобби.
    /// </summary>
    public class WarshipRankModel
    {
        public readonly int currentRating;
        public readonly int currentRank;
        public readonly int maxRatingValueForRank;
        
        /// <summary>
        /// [0, 1]
        /// </summary>
        public readonly float rankProgress;

        public WarshipRankModel(int currentRating, int currentRank, int maxRatingValueForRank, float rankProgress)
        {
            this.currentRating = currentRating;
            this.currentRank = currentRank;
            this.maxRatingValueForRank = maxRatingValueForRank;
            this.rankProgress = rankProgress;
        }

        public override string ToString()
        {
            return currentRating.ToString();
        }
    }
}