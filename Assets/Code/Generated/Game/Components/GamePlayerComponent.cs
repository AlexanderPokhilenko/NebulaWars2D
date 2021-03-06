//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Scenes.BattleScene.ECS.Components.Game.PlayerComponent player { get { return (Code.Scenes.BattleScene.ECS.Components.Game.PlayerComponent)GetComponent(GameComponentsLookup.Player); } }
    public bool hasPlayer { get { return HasComponent(GameComponentsLookup.Player); } }

    public void AddPlayer(int newAccountId, string newNickname) {
        var index = GameComponentsLookup.Player;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.PlayerComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.PlayerComponent));
        component.accountId = newAccountId;
        component.nickname = newNickname;
        AddComponent(index, component);
    }

    public void ReplacePlayer(int newAccountId, string newNickname) {
        var index = GameComponentsLookup.Player;
        var component = (Code.Scenes.BattleScene.ECS.Components.Game.PlayerComponent)CreateComponent(index, typeof(Code.Scenes.BattleScene.ECS.Components.Game.PlayerComponent));
        component.accountId = newAccountId;
        component.nickname = newNickname;
        ReplaceComponent(index, component);
    }

    public void RemovePlayer() {
        RemoveComponent(GameComponentsLookup.Player);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayer;

    public static Entitas.IMatcher<GameEntity> Player {
        get {
            if (_matcherPlayer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Player);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayer = matcher;
            }

            return _matcherPlayer;
        }
    }
}
