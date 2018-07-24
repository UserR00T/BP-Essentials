﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static BP_Essentials.EssentialsVariablesPlugin;
using static BP_Essentials.EssentialsMethodsPlugin;

namespace BP_Essentials.Commands
{
    class SpawnVehicle : EssentialsChatPlugin
    {
        public static void Run(SvPlayer player, string message)
        {
            string arg1 = GetArgument.Run(1, false, false, message);
            if (String.IsNullOrEmpty(arg1))
            {
                player.SendToSelf(Channel.Unsequenced, ClPacket.GameMessage, ArgRequired);
                return;
            }
            bool Parsed = int.TryParse(arg1, out int arg1int);
            if (Parsed)
            {
                if (arg1int > 0 && arg1int <= IDs_Vehicles.Length)
                {
                    var shPlayer = player.player;
                    var pos = shPlayer.GetPosition();
                    if (arg1.Length > 4)
                        SvMan.AddNewEntity(shPlayer.manager.GetEntity(arg1int).gameObject, shPlayer.manager.places[0], new Vector3(pos.x, pos.y + 10F, pos.z), shPlayer.GetRotation(), false, 0F);
                    else
                        SvMan.AddNewEntity(shPlayer.manager.GetEntity(IDs_Vehicles[arg1int - 1]).gameObject, shPlayer.manager.places[0], new Vector3(pos.x, pos.y + 7F, pos.z), shPlayer.GetRotation(), false, 0F);
                    player.SendToSelf(Channel.Unsequenced, ClPacket.GameMessage, $"<color={infoColor}>Spawning in vehicle with the ID: </color><color={argColor}>{arg1}</color>");
                }
                else
                    player.SendToSelf(Channel.Unsequenced, ClPacket.GameMessage, $"<color={errorColor}>Error: The ID must be between 1 and {IDs_Vehicles.Length}.</color>");
            }
            else
                player.SendToSelf(Channel.Unsequenced, ClPacket.GameMessage, $"<color={errorColor}>Error: Is that a valid number you provided as argument?</color>");
        }
    }
}