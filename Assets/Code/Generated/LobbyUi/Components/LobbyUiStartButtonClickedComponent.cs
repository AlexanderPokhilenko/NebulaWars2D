//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiContext {

    public LobbyUiEntity startButtonClickedEntity { get { return GetGroup(LobbyUiMatcher.StartButtonClicked).GetSingleEntity(); } }
    public Code.Scenes.LobbyScene.ECS.StartButtonClickedComponent startButtonClicked { get { return startButtonClickedEntity.startButtonClicked; } }
    public bool hasStartButtonClicked { get { return startButtonClickedEntity != null; } }

    public LobbyUiEntity SetStartButtonClicked(System.DateTime newValue) {
        if (hasStartButtonClicked) {
            throw new Entitas.EntitasException("Could not set StartButtonClicked!\n" + this + " already has an entity with Code.Scenes.LobbyScene.ECS.StartButtonClickedComponent!",
                "You should check if the context already has a startButtonClickedEntity before setting it or use context.ReplaceStartButtonClicked().");
        }
        var entity = CreateEntity();
        entity.AddStartButtonClicked(newValue);
        return entity;
    }

    public void ReplaceStartButtonClicked(System.DateTime newValue) {
        var entity = startButtonClickedEntity;
        if (entity == null) {
            entity = SetStartButtonClicked(newValue);
        } else {
            entity.ReplaceStartButtonClicked(newValue);
        }
    }

    public void RemoveStartButtonClicked() {
        startButtonClickedEntity.Destroy();
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

    public Code.Scenes.LobbyScene.ECS.StartButtonClickedComponent startButtonClicked { get { return (Code.Scenes.LobbyScene.ECS.StartButtonClickedComponent)GetComponent(LobbyUiComponentsLookup.StartButtonClicked); } }
    public bool hasStartButtonClicked { get { return HasComponent(LobbyUiComponentsLookup.StartButtonClicked); } }

    public void AddStartButtonClicked(System.DateTime newValue) {
        var index = LobbyUiComponentsLookup.StartButtonClicked;
        var component = (Code.Scenes.LobbyScene.ECS.StartButtonClickedComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.StartButtonClickedComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceStartButtonClicked(System.DateTime newValue) {
        var index = LobbyUiComponentsLookup.StartButtonClicked;
        var component = (Code.Scenes.LobbyScene.ECS.StartButtonClickedComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.StartButtonClickedComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveStartButtonClicked() {
        RemoveComponent(LobbyUiComponentsLookup.StartButtonClicked);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherStartButtonClicked;

    public static Entitas.IMatcher<LobbyUiEntity> StartButtonClicked {
        get {
            if (_matcherStartButtonClicked == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.StartButtonClicked);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherStartButtonClicked = matcher;
            }

            return _matcherStartButtonClicked;
        }
    }
}
