﻿using BPEssentials.Abstractions;
using BPEssentials.ExtensionMethods;
using BPEssentials.ExtensionMethods.Warns;
using BPEssentials.Utils;
using BrokeProtocol.API.ExtensionMethods;
using BrokeProtocol.Entities;

namespace BPEssentials.Commands
{
    public class Warn : Command
    {
        public override bool LastArgSpaces { get; } = true;

        public void Invoke(ShPlayer player, ShPlayer target, string reason)
        {
            player.AddWarn(player, reason);
            ChatUtils.SendToAllEnabledChatT("all_warned", player.username.SanitizeString(), target.username.SanitizeString(), reason.SanitizeString());
            player.TS("player_warned", target.username.SanitizeString(), reason.SanitizeString());
            player.TS("target_warned", player.username.SanitizeString(), reason.SanitizeString());
        }
    }
}