//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity {

    static readonly Code.Scenes.LobbyScene.ECS.BackButtonPressedComponent backButtonPressedComponent = new Code.Scenes.LobbyScene.ECS.BackButtonPressedComponent();

    public bool messageBackButtonPressed {
        get { return HasComponent(LobbyUiComponentsLookup.BackButtonPressed); }
        set {
            if (value != messageBackButtonPressed) {
                var index = LobbyUiComponentsLookup.BackButtonPressed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : backButtonPressedComponent;

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

    static Entitas.IMatcher<LobbyUiEntity> _matcherBackButtonPressed;

    public static Entitas.IMatcher<LobbyUiEntity> BackButtonPressed {
        get {
            if (_matcherBackButtonPressed == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.BackButtonPressed);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherBackButtonPressed = matcher;
            }

            return _matcherBackButtonPressed;
        }
    }
}
