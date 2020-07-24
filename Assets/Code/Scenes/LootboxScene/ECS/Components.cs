using System;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LootboxScene.ECS
{
   [Lootbox]
   public class CanvasClickComponent:IComponent
   {
   }

   [Lootbox]
   public class ShowPrizeComponent:IComponent
   {
      public ResourceModel resourceModel;
   }

   [Lootbox]
   public class ItemsLeftComponent : IComponent
   {
      public int Value;
   }
}