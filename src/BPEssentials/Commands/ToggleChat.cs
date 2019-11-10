﻿using BPCoreLib.Interfaces;
using BPCoreLib.PlayerFactory;
using BPEssentials.Configuration.Models.SettingsModel;
using BPEssentials.Enums;
using BPEssentials.ExtendedPlayer;
using BPEssentials.ExtensionMethods;
using BPEssentials.Interfaces;
using BrokeProtocol.Entities;

namespace BPEssentials.Commands
{
    public class ToggleChat : ICommand
    {
        public bool LastArgSpaces { get; }

        public ILogger Logger { get; set; }

        public Settings Settings { get; set; }

        public ExtendedPlayerFactory<PlayerItem> PlayerFactory { get; set; }

        public void Invoke(ShPlayer player)
        {
            var ePlayer = player.GetExtendedPlayer();
            ePlayer.CurrentChat = ePlayer.CurrentChat == Chat.Disabled ? Chat.Global : Chat.Disabled;
            player.SendChatMessage($"Your chat is now set to {ePlayer.CurrentChat}.");
        }
    }
}
