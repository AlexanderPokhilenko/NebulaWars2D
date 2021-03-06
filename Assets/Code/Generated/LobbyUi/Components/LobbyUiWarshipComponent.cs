//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity {

    public Code.Scenes.LobbyScene.ECS.WarshipComponent warship { get { return (Code.Scenes.LobbyScene.ECS.WarshipComponent)GetComponent(LobbyUiComponentsLookup.Warship); } }
    public bool hasWarship { get { return HasComponent(LobbyUiComponentsLookup.Warship); } }

    public void AddWarship(NetworkLibrary.NetworkLibrary.Http.WarshipDto newWarshipDto) {
        var index = LobbyUiComponentsLookup.Warship;
        var component = (Code.Scenes.LobbyScene.ECS.WarshipComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.WarshipComponent));
        component.warshipDto = newWarshipDto;
        AddComponent(index, component);
    }

    public void ReplaceWarship(NetworkLibrary.NetworkLibrary.Http.WarshipDto newWarshipDto) {
        var index = LobbyUiComponentsLookup.Warship;
        var component = (Code.Scenes.LobbyScene.ECS.WarshipComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.WarshipComponent));
        component.warshipDto = newWarshipDto;
        ReplaceComponent(index, component);
    }

    public void RemoveWarship() {
        RemoveComponent(LobbyUiComponentsLookup.Warship);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherWarship;

    public static Entitas.IMatcher<LobbyUiEntity> Warship {
        get {
            if (_matcherWarship == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.Warship);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherWarship = matcher;
            }

            return _matcherWarship;
        }
    }
}
