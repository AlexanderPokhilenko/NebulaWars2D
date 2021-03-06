//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity movementEntity { get { return GetGroup(InputMatcher.Movement).GetSingleEntity(); } }
    public Code.Scenes.BattleScene.ECS.Components.Input.MovementComponent movement { get { return movementEntity.movement; } }
    public bool hasMovement { get { return movementEntity != null; } }

    public InputEntity SetMovement(float newX, float newY) {
        if (hasMovement) {
            throw new Entitas.EntitasException("Could not set Movement!\n" + this + " already has an entity with Code.Scenes.BattleScene.ECS.Components.Input.MovementComponent!",
                "You should check if the context already has a movementEntity before setting it or use context.ReplaceMovement().");
        }
        var entity = CreateEntity();
        entity.AddMovement(newX, newY);
        return entity;
    }

    public void ReplaceMovement(float newX, float newY) {
        var entity = movementEntity;
        if (entity == null) {
            entity = SetMovement(newX, newY);
        } else {
            entity.ReplaceMovement(newX, newY);
        }
    }

    public void RemoveMovement() {
        movementEntity.Destroy();
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
public partial class InputEntity {

    public Code.Scenes.BattleScene.ECS.Components.Input.MovementComponent movement { get { return (Code.Scenes.BattleScene.ECS.Components.Input.MovementComponent)GetComponent(InputComponentsLookup.Movement); } }
    public bool hasMovement { get { return HasComponent(InputComponentsLookup.Movement); } }

    public void AddMovement(float newX, float newY) {
        var index = InputComponentsLookup.Movement;
        var component = (Code.Scenes.BattleScene.ECS.Components.Input.MovementComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Input.MovementComponent));
        component.x = newX;
        component.y = newY;
        AddComponent(index, component);
    }

    public void ReplaceMovement(float newX, float newY) {
        var index = InputComponentsLookup.Movement;
        var component = (Code.Scenes.BattleScene.ECS.Components.Input.MovementComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Input.MovementComponent));
        component.x = newX;
        component.y = newY;
        ReplaceComponent(index, component);
    }

    public void RemoveMovement() {
        RemoveComponent(InputComponentsLookup.Movement);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherMovement;

    public static Entitas.IMatcher<InputEntity> Movement {
        get {
            if (_matcherMovement == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Movement);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherMovement = matcher;
            }

            return _matcherMovement;
        }
    }
}
