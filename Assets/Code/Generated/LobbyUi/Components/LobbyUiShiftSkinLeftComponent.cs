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

    static readonly ShiftSkinLeftComponent shiftSkinLeftComponent = new ShiftSkinLeftComponent();

    public bool messageShiftSkinLeft {
        get { return HasComponent(LobbyUiComponentsLookup.ShiftSkinLeft); }
        set {
            if (value != messageShiftSkinLeft) {
                var index = LobbyUiComponentsLookup.ShiftSkinLeft;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : shiftSkinLeftComponent;

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

    static Entitas.IMatcher<LobbyUiEntity> _matcherShiftSkinLeft;

    public static Entitas.IMatcher<LobbyUiEntity> ShiftSkinLeft {
        get {
            if (_matcherShiftSkinLeft == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.ShiftSkinLeft);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherShiftSkinLeft = matcher;
            }

            return _matcherShiftSkinLeft;
        }
    }
}
