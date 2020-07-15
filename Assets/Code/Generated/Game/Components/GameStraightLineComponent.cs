//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents;

public partial class GameEntity {

    public StraightLineComponent straightLine { get { return (StraightLineComponent)GetComponent(GameComponentsLookup.StraightLine); } }
    public bool hasStraightLine { get { return HasComponent(GameComponentsLookup.StraightLine); } }

    public void AddStraightLine(UnityEngine.Material newMaterial) {
        var index = GameComponentsLookup.StraightLine;
        var component = (StraightLineComponent)CreateComponent(index, typeof(StraightLineComponent));
        component.material = newMaterial;
        AddComponent(index, component);
    }

    public void ReplaceStraightLine(UnityEngine.Material newMaterial) {
        var index = GameComponentsLookup.StraightLine;
        var component = (StraightLineComponent)CreateComponent(index, typeof(StraightLineComponent));
        component.material = newMaterial;
        ReplaceComponent(index, component);
    }

    public void RemoveStraightLine() {
        RemoveComponent(GameComponentsLookup.StraightLine);
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

    static Entitas.IMatcher<GameEntity> _matcherStraightLine;

    public static Entitas.IMatcher<GameEntity> StraightLine {
        get {
            if (_matcherStraightLine == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StraightLine);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStraightLine = matcher;
            }

            return _matcherStraightLine;
        }
    }
}
