﻿using BPEssentials.ExtensionMethods;
using BrokeProtocol.API;
using BrokeProtocol.API.ExtensionMethods;
using BrokeProtocol.Entities;
using System;
using static BPEssentials.ExtendedPlayer.PlayerItem;

namespace BPEssentials.ChatHandlers
{
    public class GlobalChat : IScript
    {
        public GlobalChat()
        {
            GameSourceHandler.Add(BrokeProtocol.API.Events.Player.OnGlobalChatMessage, new Action<ShPlayer, string>(OnEvent));
        }

        public void OnEvent(ShPlayer player, string message)
        {
            Core.Instance.Logger.LogInfo($"[GLOBAL] {player.username}: {message}");
            switch (player.GetExtendedPlayer().CurrentChat)
            {
                case Chat.StaffChat:
                    Util.SendStaffChatMessage(player, message);
                    return;

                case Chat.Disabled:
                    player.SendChatMessage("Chat disabled");
                    return;
            }
            Util.SendToAllEnabledChat($"{player.username.SanitizeString()}: {message.SanitizeString()}");
        }
    }
}