using NetworkLibrary.NetworkLibrary.Udp;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public interface IMessageHandler
    {
        void Handle(MessageWrapper messageWrapper);
    }
}