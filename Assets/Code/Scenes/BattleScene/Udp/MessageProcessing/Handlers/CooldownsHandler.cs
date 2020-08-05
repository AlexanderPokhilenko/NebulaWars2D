﻿using Code.Scenes.BattleScene.ECS.Systems;
using Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus;

namespace Code.Scenes.BattleScene.Udp.MessageProcessing.Handlers
{
    public class CooldownsHandler : MessageHandler<CooldownsMessage>
    {
        protected override void Handle(in CooldownsMessage message, uint messageId, bool needResponse)
        {
            CooldownsUpdaterSystem.SetCooldowns(message.WeaponsCooldowns);
            AbilityUpdaterSystem.SetCurrentCooldown(message.AbilityCooldown);
        }
    }
}