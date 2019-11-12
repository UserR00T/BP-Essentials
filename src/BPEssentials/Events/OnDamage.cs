﻿using BPEssentials.ExtensionMethods;
using BrokeProtocol;
using BrokeProtocol.API;
using BrokeProtocol.API.ExtensionMethods;
using BrokeProtocol.Entities;
using System;
using UnityEngine;

namespace BPEssentials.RegisteredEvents
{
    public class OnDamage : IScript
    {
        public OnDamage()
        {
            GameSourceHandler.Add(BrokeProtocol.API.Events.Player.OnDamage, new Action<ShPlayer, DamageIndex, float, ShPlayer, Collider>(OnEvent));
        }

        public void OnEvent(ShPlayer player, DamageIndex damageIndex, float amount, ShPlayer attacker, Collider collider)
        {
            if (!player.isHuman)
            {
                return;
            }
            if (player.GetExtendedPlayer().HasGodmode)
            {
                player.SendChatMessage($"Damage blocked: {amount}HP. (Attacker: {attacker.ID}: {attacker.username.SanitizeString()})");
                // TODO: Override gamesource
                return;
            }
        }
    }
}
