//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IAlphaEntity {

    Code.Scenes.LobbyScene.ECS.AlphaComponent alpha { get; }
    bool hasAlpha { get; }

    void AddAlpha(float newAlpha);
    void ReplaceAlpha(float newAlpha);
    void RemoveAlpha();
}
