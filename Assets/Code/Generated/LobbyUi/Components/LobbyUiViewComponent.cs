//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity {

    public Code.Scenes.LobbyScene.ECS.ViewComponent view { get { return (Code.Scenes.LobbyScene.ECS.ViewComponent)GetComponent(LobbyUiComponentsLookup.View); } }
    public bool hasView { get { return HasComponent(LobbyUiComponentsLookup.View); } }

    public void AddView(UnityEngine.GameObject newGameObject) {
        var index = LobbyUiComponentsLookup.View;
        var component = (Code.Scenes.LobbyScene.ECS.ViewComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.ViewComponent));
        component.gameObject = newGameObject;
        AddComponent(index, component);
    }

    public void ReplaceView(UnityEngine.GameObject newGameObject) {
        var index = LobbyUiComponentsLookup.View;
        var component = (Code.Scenes.LobbyScene.ECS.ViewComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.ViewComponent));
        component.gameObject = newGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveView() {
        RemoveComponent(LobbyUiComponentsLookup.View);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherView;

    public static Entitas.IMatcher<LobbyUiEntity> View {
        get {
            if (_matcherView == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.View);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherView = matcher;
            }

            return _matcherView;
        }
    }
}
