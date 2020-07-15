//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiContext {

    public LobbyUiEntity currentWarshipIndexEntity { get { return GetGroup(LobbyUiMatcher.CurrentWarshipIndex).GetSingleEntity(); } }
    public Code.Scenes.LobbyScene.ECS.Components.CurrentWarshipIndexComponent currentWarshipIndex { get { return currentWarshipIndexEntity.currentWarshipIndex; } }
    public bool hasCurrentWarshipIndex { get { return currentWarshipIndexEntity != null; } }

    public LobbyUiEntity SetCurrentWarshipIndex(int newValue) {
        if (hasCurrentWarshipIndex) {
            throw new Entitas.EntitasException("Could not set CurrentWarshipIndex!\n" + this + " already has an entity with Code.Scenes.LobbyScene.ECS.Components.CurrentWarshipIndexComponent!",
                "You should check if the context already has a currentWarshipIndexEntity before setting it or use context.ReplaceCurrentWarshipIndex().");
        }
        var entity = CreateEntity();
        entity.AddCurrentWarshipIndex(newValue);
        return entity;
    }

    public void ReplaceCurrentWarshipIndex(int newValue) {
        var entity = currentWarshipIndexEntity;
        if (entity == null) {
            entity = SetCurrentWarshipIndex(newValue);
        } else {
            entity.ReplaceCurrentWarshipIndex(newValue);
        }
    }

    public void RemoveCurrentWarshipIndex() {
        currentWarshipIndexEntity.Destroy();
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

    public Code.Scenes.LobbyScene.ECS.Components.CurrentWarshipIndexComponent currentWarshipIndex { get { return (Code.Scenes.LobbyScene.ECS.Components.CurrentWarshipIndexComponent)GetComponent(LobbyUiComponentsLookup.CurrentWarshipIndex); } }
    public bool hasCurrentWarshipIndex { get { return HasComponent(LobbyUiComponentsLookup.CurrentWarshipIndex); } }

    public void AddCurrentWarshipIndex(int newValue) {
        var index = LobbyUiComponentsLookup.CurrentWarshipIndex;
        var component = (Code.Scenes.LobbyScene.ECS.Components.CurrentWarshipIndexComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.Components.CurrentWarshipIndexComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCurrentWarshipIndex(int newValue) {
        var index = LobbyUiComponentsLookup.CurrentWarshipIndex;
        var component = (Code.Scenes.LobbyScene.ECS.Components.CurrentWarshipIndexComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.Components.CurrentWarshipIndexComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentWarshipIndex() {
        RemoveComponent(LobbyUiComponentsLookup.CurrentWarshipIndex);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherCurrentWarshipIndex;

    public static Entitas.IMatcher<LobbyUiEntity> CurrentWarshipIndex {
        get {
            if (_matcherCurrentWarshipIndex == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.CurrentWarshipIndex);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherCurrentWarshipIndex = matcher;
            }

            return _matcherCurrentWarshipIndex;
        }
    }
}