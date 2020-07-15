using Entitas;
using NetworkLibrary.NetworkLibrary.Http;

namespace DefaultNamespace
{
   [Lootbox]
   public class CanvasClickComponent:IComponent
   {
   }

   [Lootbox]
   public class ShowPrizeComponent:IComponent

   {
   public int amount;
   public LootboxPrizeType LootboxPrizeType;
   }
}