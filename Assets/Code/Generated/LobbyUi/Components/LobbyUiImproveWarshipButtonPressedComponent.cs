//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity {

    static readonly Code.Scenes.LobbyScene.ECS.ImproveWarshipButtonPressedComponent improveWarshipButtonPressedComponent = new Code.Scenes.LobbyScene.ECS.ImproveWarshipButtonPressedComponent();

    public bool messageImproveWarshipButtonPressed {
        get { return HasComponent(LobbyUiComponentsLookup.ImproveWarshipButtonPressed); }
        set {
            if (value != messageImproveWarshipButtonPressed) {
                var index = LobbyUiComponentsLookup.ImproveWarshipButtonPressed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : improveWarshipButtonPressedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherImproveWarshipButtonPressed;

    public static Entitas.IMatcher<LobbyUiEntity> ImproveWarshipButtonPressed {
        get {
            if (_matcherImproveWarshipButtonPressed == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.ImproveWarshipButtonPressed);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherImproveWarshipButtonPressed = matcher;
            }

            return _matcherImproveWarshipButtonPressed;
        }
    }
}
