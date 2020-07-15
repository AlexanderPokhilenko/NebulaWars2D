using System;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Common.Statistics
{
    /// <summary>
    /// Синглтон.
    /// У корабля есть рейтинг - кол-во кубков. В зависимости от кол-ва кубков считается ранг.
    /// </summary>
    public class WarshipRatingScaleStorage
    {
        private static readonly Lazy<WarshipRatingScaleStorage> Lazy = new Lazy<WarshipRatingScaleStorage> (
            () => new WarshipRatingScaleStorage()); 
        public static WarshipRatingScaleStorage Instance => Lazy.Value;
        private WarshipRatingScaleModel warshipRatingScaleModel;
        
        public void SetValue(WarshipRatingScaleModel warshipRatingScaleModelArg)
        {
            warshipRatingScaleModel = warshipRatingScaleModelArg;
        }
        
        public WarshipRankModel GetRankModel(int currentRating)
        {
            int currentRank = GetRank(currentRating);
            int maxRatingValueForRank = warshipRatingScaleModel.RankMaxRatingArray[currentRank];
                
            int maxRatingForPreviousRank = default;
            if (currentRank - 1 >= 0)
            {
                maxRatingForPreviousRank = warshipRatingScaleModel.RankMaxRatingArray[currentRank-1];
            }
            
            float rankProgress = 1f*(currentRating-maxRatingForPreviousRank)/(maxRatingValueForRank-maxRatingForPreviousRank);
            WarshipRankModel result = new WarshipRankModel(currentRating, currentRank, maxRatingValueForRank, rankProgress );
            return result;
        }
        
        private int GetRank(int currentRating)
        {
            //Не бывает отрицательного рейтинга
            if (currentRating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(currentRating));
            }
            
            //Найти интервал
            for (int rank = 0; rank < warshipRatingScaleModel.RankMaxRatingArray.Length; rank++)
            {
                if (currentRating < warshipRatingScaleModel.RankMaxRatingArray[rank])
                {
                    return rank;
                }   
            }
            
            throw new Exception("Рейтинг слишком большой. Невозможно вернуть значение ранга.");
        }
    }
}
