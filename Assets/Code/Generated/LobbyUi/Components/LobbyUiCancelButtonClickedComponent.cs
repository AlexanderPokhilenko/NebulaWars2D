//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Code.Scenes.LobbyScene.ECS;

public partial class LobbyUiContext {

    public LobbyUiEntity cancelButtonClickedEntity { get { return GetGroup(LobbyUiMatcher.CancelButtonClicked).GetSingleEntity(); } }

    public bool isCancelButtonClicked {
        get { return cancelButtonClickedEntity != null; }
        set {
            var entity = cancelButtonClickedEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isCancelButtonClicked = true;
                } else {
                    entity.Destroy();
                }
            }
        }
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

    static readonly CancelButtonClickedComponent cancelButtonClickedComponent = new CancelButtonClickedComponent();

    public bool isCancelButtonClicked {
        get { return HasComponent(LobbyUiComponentsLookup.CancelButtonClicked); }
        set {
            if (value != isCancelButtonClicked) {
                var index = LobbyUiComponentsLookup.CancelButtonClicked;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : cancelButtonClickedComponent;

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

    static Entitas.IMatcher<LobbyUiEntity> _matcherCancelButtonClicked;

    public static Entitas.IMatcher<LobbyUiEntity> CancelButtonClicked {
        get {
            if (_matcherCancelButtonClicked == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.CancelButtonClicked);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherCancelButtonClicked = matcher;
            }

            return _matcherCancelButtonClicked;
        }
    }
}
