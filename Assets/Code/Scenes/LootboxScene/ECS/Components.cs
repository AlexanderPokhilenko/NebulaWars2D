using System;
using Code.Scenes.LootboxScene.PrefabScripts;
using Entitas;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LootboxScene.ECS
{
   [Lootbox]
   public class CanvasClickComponent : IComponent
   {
   }

   [Lootbox]
   public class ShowPrizeComponent : IComponent
   {
      public ResourceModel resourceModel;
   }

   [Lootbox]
   public class ItemsLeftComponent : IComponent
   {
      public int value;
   }

   [Lootbox]
   public class ShowLootboxComponent : IComponent
   {

   }

   [Lootbox]
   public class NeedToOpenLootboxComponent : IComponent
   {
      public LootboxOpeningController lootboxOpeningController;
   }
}