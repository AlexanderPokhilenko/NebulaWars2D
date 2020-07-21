using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Scenes.LootboxScene.PrefabScripts.Wpp.ECS
{
    [WppAccrual, Unique]
    public class WarshipPowerPointsComponent:IComponent
    {
        public int value;
        public int maxValueForLevel;
    }
}