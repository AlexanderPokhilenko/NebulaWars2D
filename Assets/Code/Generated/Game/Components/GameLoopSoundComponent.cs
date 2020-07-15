//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Code.Scenes.BattleScene.ECS.Components.Game.AudioComponents;

public partial class GameEntity {

    public LoopSoundComponent loopSound { get { return (LoopSoundComponent)GetComponent(GameComponentsLookup.LoopSound); } }
    public bool hasLoopSound { get { return HasComponent(GameComponentsLookup.LoopSound); } }

    public void AddLoopSound(UnityEngine.AudioClip newValue) {
        var index = GameComponentsLookup.LoopSound;
        var component = (LoopSoundComponent)CreateComponent(index, typeof(LoopSoundComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLoopSound(UnityEngine.AudioClip newValue) {
        var index = GameComponentsLookup.LoopSound;
        var component = (LoopSoundComponent)CreateComponent(index, typeof(LoopSoundComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLoopSound() {
        RemoveComponent(GameComponentsLookup.LoopSound);
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

    static Entitas.IMatcher<GameEntity> _matcherLoopSound;

    public static Entitas.IMatcher<GameEntity> LoopSound {
        get {
            if (_matcherLoopSound == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LoopSound);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLoopSound = matcher;
            }

            return _matcherLoopSound;
        }
    }
}
