using System;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Common
{
    /// <summary>
    /// Синглтон
    /// Хранит информацию о интервалах уровня силы кораблей.
    /// </summary>
    public class WarshipPowerScaleStorage
    {
        private static readonly Lazy<WarshipPowerScaleStorage> Lazy = new Lazy<WarshipPowerScaleStorage> (
            () => new WarshipPowerScaleStorage()); 
        public static WarshipPowerScaleStorage Instance => Lazy.Value;
        private WarshipPowerScaleModel warshipPowerScaleModel;
        
        public void SetValue(WarshipPowerScaleModel warshipPowerScale)
        {
            warshipPowerScaleModel = warshipPowerScale;
        }

        public float GetProgress(int powerLevel, int powerPoints)
        {
            int maxPowerPointsValue = warshipPowerScaleModel.PowerLevelModels[powerLevel].PowerPointsCost;
            return 1f * powerPoints / maxPowerPointsValue;
        }

        public int GetMaxPowerPoints(int powerLevel)
        {
            return warshipPowerScaleModel.PowerLevelModels[powerLevel].PowerPointsCost;
        }

        public int GetCost(int powerLevel)
        {
            return warshipPowerScaleModel.PowerLevelModels[powerLevel].SoftCurrencyCost;
        }
    }
}