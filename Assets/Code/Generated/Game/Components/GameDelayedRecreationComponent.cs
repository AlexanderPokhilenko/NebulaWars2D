//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Scenes.BattleScene.ECS.Components.Game.TimerComponents.DelayedRecreationComponent delayedRecreation { get { return (Code.Scenes.BattleScene.ECS.Components.Game.TimerComponents.DelayedRecreationComponent)GetComponent(GameComponentsLookup.DelayedRecreation); } }
    public bool hasDelayedRecreation { get { return HasComponent(GameComponentsLookup.DelayedRecreation); } }

    public void AddDelayedRecreation(ViewTypeId newTypeId, float newPositionX, float newPositionY, float newDirection, float newTime) {
        var index = GameComponentsLookup.DelayedRecreation;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.TimerComponents.DelayedRecreationComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.TimerComponents.DelayedRecreationComponent));
        component.typeId = newTypeId;
        component.positionX = newPositionX;
        component.positionY = newPositionY;
        component.direction = newDirection;
        component.time = newTime;
        AddComponent(index, component);
    }

    public void ReplaceDelayedRecreation(ViewTypeId newTypeId, float newPositionX, float newPositionY, float newDirection, float newTime) {
        var index = GameComponentsLookup.DelayedRecreation;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.TimerComponents.DelayedRecreationComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.TimerComponents.DelayedRecreationComponent));
        component.typeId = newTypeId;
        component.positionX = newPositionX;
        component.positionY = newPositionY;
        component.direction = newDirection;
        component.time = newTime;
        ReplaceComponent(index, component);
    }

    public void RemoveDelayedRecreation() {
        RemoveComponent(GameComponentsLookup.DelayedRecreation);
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

    static Entitas.IMatcher<GameEntity> _matcherDelayedRecreation;

    public static Entitas.IMatcher<GameEntity> DelayedRecreation {
        get {
            if (_matcherDelayedRecreation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DelayedRecreation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDelayedRecreation = matcher;
            }

            return _matcherDelayedRecreation;
        }
    }
}
