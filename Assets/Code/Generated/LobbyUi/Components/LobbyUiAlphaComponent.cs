//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity {

    public Code.Scenes.LobbyScene.ECS.AlphaComponent alpha { get { return (Code.Scenes.LobbyScene.ECS.AlphaComponent)GetComponent(LobbyUiComponentsLookup.Alpha); } }
    public bool hasAlpha { get { return HasComponent(LobbyUiComponentsLookup.Alpha); } }

    public void AddAlpha(float newAlpha) {
        var index = LobbyUiComponentsLookup.Alpha;
        var component = (Code.Scenes.LobbyScene.ECS.AlphaComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.AlphaComponent));
        component.alpha = newAlpha;
        AddComponent(index, component);
    }

    public void ReplaceAlpha(float newAlpha) {
        var index = LobbyUiComponentsLookup.Alpha;
        var component = (Code.Scenes.LobbyScene.ECS.AlphaComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.AlphaComponent));
        component.alpha = newAlpha;
        ReplaceComponent(index, component);
    }

    public void RemoveAlpha() {
        RemoveComponent(LobbyUiComponentsLookup.Alpha);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherAlpha;

    public static Entitas.IMatcher<LobbyUiEntity> Alpha {
        get {
            if (_matcherAlpha == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.Alpha);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherAlpha = matcher;
            }

            return _matcherAlpha;
        }
    }
}
