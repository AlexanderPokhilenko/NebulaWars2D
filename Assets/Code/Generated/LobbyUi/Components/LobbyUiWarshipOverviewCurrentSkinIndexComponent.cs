//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiContext {

    public LobbyUiEntity warshipOverviewCurrentSkinIndexEntity { get { return GetGroup(LobbyUiMatcher.WarshipOverviewCurrentSkinIndex).GetSingleEntity(); } }
    public Code.Scenes.LobbyScene.ECS.WarshipOverviewCurrentSkinIndex warshipOverviewCurrentSkinIndex { get { return warshipOverviewCurrentSkinIndexEntity.warshipOverviewCurrentSkinIndex; } }
    public bool hasWarshipOverviewCurrentSkinIndex { get { return warshipOverviewCurrentSkinIndexEntity != null; } }

    public LobbyUiEntity SetWarshipOverviewCurrentSkinIndex(int newIndex) {
        if (hasWarshipOverviewCurrentSkinIndex) {
            throw new Entitas.EntitasException("Could not set WarshipOverviewCurrentSkinIndex!\n" + this + " already has an entity with Code.Scenes.LobbyScene.ECS.WarshipOverviewCurrentSkinIndex!",
                "You should check if the context already has a warshipOverviewCurrentSkinIndexEntity before setting it or use context.ReplaceWarshipOverviewCurrentSkinIndex().");
        }
        var entity = CreateEntity();
        entity.AddWarshipOverviewCurrentSkinIndex(newIndex);
        return entity;
    }

    public void ReplaceWarshipOverviewCurrentSkinIndex(int newIndex) {
        var entity = warshipOverviewCurrentSkinIndexEntity;
        if (entity == null) {
            entity = SetWarshipOverviewCurrentSkinIndex(newIndex);
        } else {
            entity.ReplaceWarshipOverviewCurrentSkinIndex(newIndex);
        }
    }

    public void RemoveWarshipOverviewCurrentSkinIndex() {
        warshipOverviewCurrentSkinIndexEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity {

    public Code.Scenes.LobbyScene.ECS.WarshipOverviewCurrentSkinIndex warshipOverviewCurrentSkinIndex { get { return (Code.Scenes.LobbyScene.ECS.WarshipOverviewCurrentSkinIndex)GetComponent(LobbyUiComponentsLookup.WarshipOverviewCurrentSkinIndex); } }
    public bool hasWarshipOverviewCurrentSkinIndex { get { return HasComponent(LobbyUiComponentsLookup.WarshipOverviewCurrentSkinIndex); } }

    public void AddWarshipOverviewCurrentSkinIndex(int newIndex) {
        var index = LobbyUiComponentsLookup.WarshipOverviewCurrentSkinIndex;
        var component = (Code.Scenes.LobbyScene.ECS.WarshipOverviewCurrentSkinIndex)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.WarshipOverviewCurrentSkinIndex));
        component.index = newIndex;
        AddComponent(index, component);
    }

    public void ReplaceWarshipOverviewCurrentSkinIndex(int newIndex) {
        var index = LobbyUiComponentsLookup.WarshipOverviewCurrentSkinIndex;
        var component = (Code.Scenes.LobbyScene.ECS.WarshipOverviewCurrentSkinIndex)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.WarshipOverviewCurrentSkinIndex));
        component.index = newIndex;
        ReplaceComponent(index, component);
    }

    public void RemoveWarshipOverviewCurrentSkinIndex() {
        RemoveComponent(LobbyUiComponentsLookup.WarshipOverviewCurrentSkinIndex);
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
public sealed partial class LobbyUiMatcher {

    static Entitas.IMatcher<LobbyUiEntity> _matcherWarshipOverviewCurrentSkinIndex;

    public static Entitas.IMatcher<LobbyUiEntity> WarshipOverviewCurrentSkinIndex {
        get {
            if (_matcherWarshipOverviewCurrentSkinIndex == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.WarshipOverviewCurrentSkinIndex);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherWarshipOverviewCurrentSkinIndex = matcher;
            }

            return _matcherWarshipOverviewCurrentSkinIndex;
        }
    }
}
