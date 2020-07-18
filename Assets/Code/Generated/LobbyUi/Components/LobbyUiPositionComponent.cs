//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity {

    public Code.Scenes.LobbyScene.ECS.PositionComponent position { get { return (Code.Scenes.LobbyScene.ECS.PositionComponent)GetComponent(LobbyUiComponentsLookup.Position); } }
    public bool hasPosition { get { return HasComponent(LobbyUiComponentsLookup.Position); } }

    public void AddPosition(UnityEngine.Vector3 newValue) {
        var index = LobbyUiComponentsLookup.Position;
        var component = (Code.Scenes.LobbyScene.ECS.PositionComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.PositionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePosition(UnityEngine.Vector3 newValue) {
        var index = LobbyUiComponentsLookup.Position;
        var component = (Code.Scenes.LobbyScene.ECS.PositionComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.PositionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePosition() {
        RemoveComponent(LobbyUiComponentsLookup.Position);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity : IPositionEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class LobbyUiMatcher {

    static Entitas.IMatcher<LobbyUiEntity> _matcherPosition;

    public static Entitas.IMatcher<LobbyUiEntity> Position {
        get {
            if (_matcherPosition == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.Position);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherPosition = matcher;
            }

            return _matcherPosition;
        }
    }
}
