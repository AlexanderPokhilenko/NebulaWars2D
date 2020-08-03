// using Entitas;
//
// namespace Code.Scenes.LobbyScene.ECS.MatchSearch
// {
//     /// <summary>
//     /// Костыльно создает компонеты при нажатии кнопок START и CANCEL
//     /// </summary>
//     public class StartCancelMatchComponentsCreatorSystem:IExecuteSystem
//     {
//         private static volatile bool startButtonClickedUnhandled;
//         private static volatile bool cancelButtonClickedUnhandled;
//         private readonly LobbyUiContext lobbyUiContext;
//
//         public StartCancelMatchComponentsCreatorSystem(LobbyUiContext lobbyUiContext)
//         {
//             this.lobbyUiContext = lobbyUiContext;
//         }
//         
//         public void Execute()
//         {
//             HandleStartButtonClicked(startButtonClickedUnhandled);
//             HandleCancelButtonClicked(cancelButtonClickedUnhandled);
//         }
//
//         private void HandleStartButtonClicked(bool startButtonClicked)
//         {
//             if (startButtonClicked)
//             {
//                 if (!lobbyUiContext.hasStartButtonClicked)
//                 {
//                     lobbyUiContext.isStartButtonClicked= true;
//                 }
//                 startButtonClickedUnhandled = false;
//                 lobbyUiContext.isBattleWaitingUiEnabled = true;
//             }
//         }
//         
//         
//         private void HandleCancelButtonClicked(bool cancelButtonClicked)
//         {
//             if (cancelButtonClicked)
//             {
//                 if (!lobbyUiContext.isCancelButtonClicked)
//                 {
//                     lobbyUiContext.isCancelButtonClicked = true;
//                 }
//                 cancelButtonClickedUnhandled = false;
//                 lobbyUiContext.isBattleWaitingUiEnabled = false;
//             }
//         }
//     }
// }