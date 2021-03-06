//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LootboxEntity {

    public Code.Scenes.LootboxScene.ECS.NeedToOpenLootboxComponent needToOpenLootbox { get { return (Code.Scenes.LootboxScene.ECS.NeedToOpenLootboxComponent)GetComponent(LootboxComponentsLookup.NeedToOpenLootbox); } }
    public bool hasNeedToOpenLootbox { get { return HasComponent(LootboxComponentsLookup.NeedToOpenLootbox); } }

    public void AddNeedToOpenLootbox(Code.Scenes.LootboxScene.PrefabScripts.LootboxOpeningController newLootboxOpeningController) {
        var index = LootboxComponentsLookup.NeedToOpenLootbox;
        var component = (Code.Scenes.LootboxScene.ECS.NeedToOpenLootboxComponent)CreateComponent(index, typeof(Code.Scenes.LootboxScene.ECS.NeedToOpenLootboxComponent));
        component.lootboxOpeningController = newLootboxOpeningController;
        AddComponent(index, component);
    }

    public void ReplaceNeedToOpenLootbox(Code.Scenes.LootboxScene.PrefabScripts.LootboxOpeningController newLootboxOpeningController) {
        var index = LootboxComponentsLookup.NeedToOpenLootbox;
        var component = (Code.Scenes.LootboxScene.ECS.NeedToOpenLootboxComponent)CreateComponent(index, typeof(Code.Scenes.LootboxScene.ECS.NeedToOpenLootboxComponent));
        component.lootboxOpeningController = newLootboxOpeningController;
        ReplaceComponent(index, component);
    }

    public void RemoveNeedToOpenLootbox() {
        RemoveComponent(LootboxComponentsLookup.NeedToOpenLootbox);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class LootboxMatcher {

    static Entitas.IMatcher<LootboxEntity> _matcherNeedToOpenLootbox;

    public static Entitas.IMatcher<LootboxEntity> NeedToOpenLootbox {
        get {
            if (_matcherNeedToOpenLootbox == null) {
                var matcher = (Entitas.Matcher<LootboxEntity>)Entitas.Matcher<LootboxEntity>.AllOf(LootboxComponentsLookup.NeedToOpenLootbox);
                matcher.componentNames = LootboxComponentsLookup.componentNames;
                _matcherNeedToOpenLootbox = matcher;
            }

            return _matcherNeedToOpenLootbox;
        }
    }
}
