﻿using BPEssentials.Abstractions;
using BPEssentials.ExtensionMethods;
using BPEssentials.ExtensionMethods.Warns;
using BrokeProtocol.Collections;
using BrokeProtocol.Entities;
using BrokeProtocol.Utility.Networking;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BPEssentials.ExtensionMethods.Warns.ExtensionPlayerWarns;

namespace BPEssentials.Commands
{
    public class WarnRemove : Command
    {
        public void Invoke(ShPlayer player, string target, int warnId)
        {
            if (warnId < 1)
            {
                player.TS("warn_remove_error_null_or_negative", warnId.ToString());
                return;
            }

            if (EntityCollections.TryGetPlayerByNameOrID(target, out var shTarget))
            {
                if (CheckWarmCount(player, warnId, shTarget.GetWarns())) return;
                shTarget.RemoveWarn(warnId - 1);
                return;
            }

            if (Core.Instance.SvManager.TryGetUserData(target, out var user))
            {
                if (CheckWarmCount(player, warnId, user.GetWarns())) return;
                user.RemoveWarn(warnId - 1);
                return;
            }

            player.TS("user_not_found", target.CleanerMessage());
        }

        private bool CheckWarmCount(ShPlayer player, int warnId, List<SerializableWarn> warns)
        {
            if (warns.Count < warnId)
            {
                player.TS("warn_remove_error_notExistent", warnId.ToString());
                return true;
            }
            player.TS("player_warn_removed", warns[warnId - 1].ToString(player));
            return false;
        }
    }
}