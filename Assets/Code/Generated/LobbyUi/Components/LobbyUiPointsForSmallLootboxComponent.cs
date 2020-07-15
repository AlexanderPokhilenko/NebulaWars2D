//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Code.Scenes.LobbyScene.ECS;

public partial class LobbyUiContext {

    public LobbyUiEntity pointsForSmallLootboxEntity { get { return GetGroup(LobbyUiMatcher.PointsForSmallLootbox).GetSingleEntity(); } }
    public PointsForSmallLootboxComponent pointsForSmallLootbox { get { return pointsForSmallLootboxEntity.pointsForSmallLootbox; } }
    public bool hasPointsForSmallLootbox { get { return pointsForSmallLootboxEntity != null; } }

    public LobbyUiEntity SetPointsForSmallLootbox(int newValue) {
        if (hasPointsForSmallLootbox) {
            throw new Entitas.EntitasException("Could not set PointsForSmallLootbox!\n" + this + " already has an entity with Code.Scenes.LobbyScene.ECS.Components.PointsForSmallLootboxComponent!",
                "You should check if the context already has a pointsForSmallLootboxEntity before setting it or use context.ReplacePointsForSmallLootbox().");
        }
        var entity = CreateEntity();
        entity.AddPointsForSmallLootbox(newValue);
        return entity;
    }

    public void ReplacePointsForSmallLootbox(int newValue) {
        var entity = pointsForSmallLootboxEntity;
        if (entity == null) {
            entity = SetPointsForSmallLootbox(newValue);
        } else {
            entity.ReplacePointsForSmallLootbox(newValue);
        }
    }

    public void RemovePointsForSmallLootbox() {
        pointsForSmallLootboxEntity.Destroy();
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

    public PointsForSmallLootboxComponent pointsForSmallLootbox { get { return (PointsForSmallLootboxComponent)GetComponent(LobbyUiComponentsLookup.PointsForSmallLootbox); } }
    public bool hasPointsForSmallLootbox { get { return HasComponent(LobbyUiComponentsLookup.PointsForSmallLootbox); } }

    public void AddPointsForSmallLootbox(int newValue) {
        var index = LobbyUiComponentsLookup.PointsForSmallLootbox;
        var component = (PointsForSmallLootboxComponent)CreateComponent(index, typeof(PointsForSmallLootboxComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePointsForSmallLootbox(int newValue) {
        var index = LobbyUiComponentsLookup.PointsForSmallLootbox;
        var component = (PointsForSmallLootboxComponent)CreateComponent(index, typeof(PointsForSmallLootboxComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePointsForSmallLootbox() {
        RemoveComponent(LobbyUiComponentsLookup.PointsForSmallLootbox);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherPointsForSmallLootbox;

    public static Entitas.IMatcher<LobbyUiEntity> PointsForSmallLootbox {
        get {
            if (_matcherPointsForSmallLootbox == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.PointsForSmallLootbox);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherPointsForSmallLootbox = matcher;
            }

            return _matcherPointsForSmallLootbox;
        }
    }
}
