//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity {

    static readonly Code.Scenes.LobbyScene.ECS.DisableWarshipOverviewUiLayerComponent disableWarshipOverviewUiLayerComponent = new Code.Scenes.LobbyScene.ECS.DisableWarshipOverviewUiLayerComponent();

    public bool messageDisableWarshipOverviewUiLayer {
        get { return HasComponent(LobbyUiComponentsLookup.DisableWarshipOverviewUiLayer); }
        set {
            if (value != messageDisableWarshipOverviewUiLayer) {
                var index = LobbyUiComponentsLookup.DisableWarshipOverviewUiLayer;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : disableWarshipOverviewUiLayerComponent;

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

    static Entitas.IMatcher<LobbyUiEntity> _matcherDisableWarshipOverviewUiLayer;

    public static Entitas.IMatcher<LobbyUiEntity> DisableWarshipOverviewUiLayer {
        get {
            if (_matcherDisableWarshipOverviewUiLayer == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.DisableWarshipOverviewUiLayer);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherDisableWarshipOverviewUiLayer = matcher;
            }

            return _matcherDisableWarshipOverviewUiLayer;
        }
    }
}
