//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Scenes.BattleScene.ECS.Components.Game.InfoDistanceComponent infoDistance { get { return (Code.Scenes.BattleScene.ECS.Components.Game.InfoDistanceComponent)GetComponent(GameComponentsLookup.InfoDistance); } }
    public bool hasInfoDistance { get { return HasComponent(GameComponentsLookup.InfoDistance); } }

    public void AddInfoDistance(float newValue) {
        var index = GameComponentsLookup.InfoDistance;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.InfoDistanceComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.InfoDistanceComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInfoDistance(float newValue) {
        var index = GameComponentsLookup.InfoDistance;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.InfoDistanceComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.InfoDistanceComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInfoDistance() {
        RemoveComponent(GameComponentsLookup.InfoDistance);
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

    static Entitas.IMatcher<GameEntity> _matcherInfoDistance;

    public static Entitas.IMatcher<GameEntity> InfoDistance {
        get {
            if (_matcherInfoDistance == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InfoDistance);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInfoDistance = matcher;
            }

            return _matcherInfoDistance;
        }
    }
}
