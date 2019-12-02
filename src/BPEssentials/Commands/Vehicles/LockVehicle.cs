﻿using BPEssentials.Abstractions;
using BPEssentials.ExtensionMethods;
using BPEssentials.Utils;
using BrokeProtocol.Entities;
using System.Linq;
using UnityEngine;

namespace BPEssentials.Commands
{
    public class LockVehicle : Command
    {
        public void Invoke(ShPlayer player)
        {
            var vehicle = player.curMount as ShTransport;
            if (vehicle == null)
            {
                player.TS("player_notInVehicle");
                return;
            }
            vehicle.svTransport.SvSetTransportOwner(player);
            player.TS("player_vehicle_locked", vehicle.name);
        }
    }
}
