//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent view { get { return (Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent)GetComponent(GameComponentsLookup.View); } }
    public bool hasView { get { return HasComponent(GameComponentsLookup.View); } }

    public void AddView(UnityEngine.GameObject newGameObject) {
        var index = GameComponentsLookup.View;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent));
        component.gameObject = newGameObject;
        AddComponent(index, component);
    }

    public void ReplaceView(UnityEngine.GameObject newGameObject) {
        var index = GameComponentsLookup.View;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent));
        component.gameObject = newGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveView() {
        RemoveComponent(GameComponentsLookup.View);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherView;

    public static Entitas.IMatcher<GameEntity> View {
        get {
            if (_matcherView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.View);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherView = matcher;
            }

            return _matcherView;
        }
    }
}
