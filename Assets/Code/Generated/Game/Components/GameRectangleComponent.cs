//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.RectangleComponent rectangle { get { return (Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.RectangleComponent)GetComponent(GameComponentsLookup.Rectangle); } }
    public bool hasRectangle { get { return HasComponent(GameComponentsLookup.Rectangle); } }

    public void AddRectangle(float newWidth, float newHeight) {
        var index = GameComponentsLookup.Rectangle;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.RectangleComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.RectangleComponent));
        component.width = newWidth;
        component.height = newHeight;
        AddComponent(index, component);
    }

    public void ReplaceRectangle(float newWidth, float newHeight) {
        var index = GameComponentsLookup.Rectangle;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.RectangleComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.RectangleComponent));
        component.width = newWidth;
        component.height = newHeight;
        ReplaceComponent(index, component);
    }

    public void RemoveRectangle() {
        RemoveComponent(GameComponentsLookup.Rectangle);
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

    static Entitas.IMatcher<GameEntity> _matcherRectangle;

    public static Entitas.IMatcher<GameEntity> Rectangle {
        get {
            if (_matcherRectangle == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Rectangle);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRectangle = matcher;
            }

            return _matcherRectangle;
        }
    }
}
