//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class WppAccrualEntity {

    public Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent view { get { return (Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent)GetComponent(WppAccrualComponentsLookup.View); } }
    public bool hasView { get { return HasComponent(WppAccrualComponentsLookup.View); } }

    public void AddView(UnityEngine.GameObject newGameObject) {
        var index = WppAccrualComponentsLookup.View;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent));
        component.gameObject = newGameObject;
        AddComponent(index, component);
    }

    public void ReplaceView(UnityEngine.GameObject newGameObject) {
        var index = WppAccrualComponentsLookup.View;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent));
        component.gameObject = newGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveView() {
        RemoveComponent(WppAccrualComponentsLookup.View);
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
public partial class WppAccrualEntity : IViewEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class WppAccrualMatcher {

    static Entitas.IMatcher<WppAccrualEntity> _matcherView;

    public static Entitas.IMatcher<WppAccrualEntity> View {
        get {
            if (_matcherView == null) {
                var matcher = (Entitas.Matcher<WppAccrualEntity>)Entitas.Matcher<WppAccrualEntity>.AllOf(WppAccrualComponentsLookup.View);
                matcher.componentNames = WppAccrualComponentsLookup.componentNames;
                _matcherView = matcher;
            }

            return _matcherView;
        }
    }
}