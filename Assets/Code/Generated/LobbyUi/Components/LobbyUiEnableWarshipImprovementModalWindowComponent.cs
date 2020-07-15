//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Code.Scenes.LobbyScene.ECS;

public partial class LobbyUiEntity {

    public EnableWarshipImprovementModalWindowComponent enableWarshipImprovementModalWindow { get { return (EnableWarshipImprovementModalWindowComponent)GetComponent(LobbyUiComponentsLookup.EnableWarshipImprovementModalWindow); } }
    public bool hasEnableWarshipImprovementModalWindow { get { return HasComponent(LobbyUiComponentsLookup.EnableWarshipImprovementModalWindow); } }

    public void AddEnableWarshipImprovementModalWindow(NetworkLibrary.NetworkLibrary.Http.WarshipDto newWarshipDto) {
        var index = LobbyUiComponentsLookup.EnableWarshipImprovementModalWindow;
        var component = (EnableWarshipImprovementModalWindowComponent)CreateComponent(index, typeof(EnableWarshipImprovementModalWindowComponent));
        component.WarshipDto = newWarshipDto;
        AddComponent(index, component);
    }

    public void ReplaceEnableWarshipImprovementModalWindow(NetworkLibrary.NetworkLibrary.Http.WarshipDto newWarshipDto) {
        var index = LobbyUiComponentsLookup.EnableWarshipImprovementModalWindow;
        var component = (EnableWarshipImprovementModalWindowComponent)CreateComponent(index, typeof(EnableWarshipImprovementModalWindowComponent));
        component.WarshipDto = newWarshipDto;
        ReplaceComponent(index, component);
    }

    public void RemoveEnableWarshipImprovementModalWindow() {
        RemoveComponent(LobbyUiComponentsLookup.EnableWarshipImprovementModalWindow);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherEnableWarshipImprovementModalWindow;

    public static Entitas.IMatcher<LobbyUiEntity> EnableWarshipImprovementModalWindow {
        get {
            if (_matcherEnableWarshipImprovementModalWindow == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.EnableWarshipImprovementModalWindow);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherEnableWarshipImprovementModalWindow = matcher;
            }

            return _matcherEnableWarshipImprovementModalWindow;
        }
    }
}
