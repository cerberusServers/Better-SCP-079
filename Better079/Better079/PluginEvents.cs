using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Grenades;
using Hints;
using Interactables.Interobjects.DoorUtils;
using MEC;
using Mirror;
using Respawning;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Better079
{
    public class PluginEvents
    {
        private Better079Plugin plugin;
        internal static float a2cooldown = 0f;
        internal static float a4cooldown = 0f;
        internal static float cda2;

        public PluginEvents(Better079Plugin better079Plugin)
        {
            this.plugin = better079Plugin;
        }

        internal void RoundStart()
        {
            a2cooldown = 0f;
            a4cooldown = 0f;
            cda2 = plugin.Config.b079_a2_cooldown;
        }

        internal void PlayerSpawn(SpawningEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp079)
            {
                ev.Player.ReferenceHub.hints.Show(new TextHint(Better079Plugin.instance.Config.b079_spawn_msg, new HintParameter[] { new StringHintParameter("") }, new HintEffect[]
                {
                    HintEffectPresets.TrailingPulseAlpha(0.5f, 1f, 0.5f, 2f, 0f, 3)
                }, 10f));
                //ev.Player.Broadcast(10, plugin.SpawnMsg, false);
            }
        }

        public static List<Camera079> GetSCPCameras()
        {
            var list = GameObject.FindObjectsOfType<Camera079>();
            List<Camera079> cams = new List<Camera079>();
            foreach (var ply in PlayerManager.players)
            {
                if (ply.GetComponent<ReferenceHub>().characterClassManager.CurRole.team == Team.SCP && ply.GetComponent<ReferenceHub>().characterClassManager.NetworkCurClass != RoleType.Scp079)
                {
                    foreach (var cam in list)
                    {
                        if (Vector3.Distance(cam.transform.position, ply.transform.position) <= Better079Plugin.instance.Config.b079_a1_dist)
                        {
                            cams.Add(cam);
                        }
                    }
                }
            }
            return cams;
        }

        public void ExpGain(GainingExperienceEventArgs ev)
        {
            if (!plugin.Config.xpboost) return;

            foreach (ExpGainType gainType in plugin.Config.experienceGain.Keys)
                if (gainType == ev.GainType)
                    ev.Amount += plugin.Config.experienceGain[gainType];
        }

        public static Room SCP079Room(ReferenceHub player)
        {
            Vector3 playerPos = player.scp079PlayerScript.currentCamera.transform.position;
            Vector3 end = playerPos - new Vector3(0f, 10f, 0f);
            bool flag = Physics.Linecast(playerPos, end, out RaycastHit raycastHit, -84058629);

            if (!flag || raycastHit.transform == null)
                return null;

            Transform transform = raycastHit.transform;

            while (transform.parent != null && transform.parent.parent != null)
                transform = transform.parent;

            foreach (Room room in Map.Rooms)
                if (room.Position == transform.position)
                    return room;
            return null;
            //return new Room(transform.name, transform, transform.position);
        }

        public static IEnumerator<float> GasRoom(Room room, ReferenceHub scp)
        {
            a2cooldown = Time.time + cda2;
            if (!Better079Plugin.instance.Config.b079_a2_disable_cassie)
            {
                string str = ".g4 ";
                for (int i = Better079Plugin.instance.Config.b079_a2_timer; i > 0f; i--)
                {
                    str += ". .g4 ";
                }
                RespawnEffectsController.PlayCassieAnnouncement(str, false, false);
            }
            List<DoorVariant> doors = Map.Doors.Where((d) => Vector3.Distance(d.transform.position, room.Position) <= 20f).ToList();
            foreach (var item in doors)
            {
                item.TargetState = true;
                item.ServerChangeLock(DoorLockReason.Lockdown079, true);
            }
            for (int i = Better079Plugin.instance.Config.b079_a2_timer; i > 0f; i--)
            {
                foreach (var ply in PlayerManager.players)
                {
                    var player = new Player(ply);
                    if (player.Team != Team.SCP && player.CurrentRoom != null && player.CurrentRoom.Transform == room.Transform)
                    {
                        player.ReferenceHub.hints.Show(new TextHint(Better079Plugin.instance.Config.b079_msg_a2_warn.Replace("$seconds", "" + i), new HintParameter[] { new StringHintParameter("") }, new HintEffect[]
                        {
                            HintEffectPresets.TrailingPulseAlpha(0.5f, 1f, 0.5f, 2f, 0f, 3)
                        }, 1f));
                        //player.ClearBroadcasts();
                        //player.Broadcast(1, plugin.A2WarnMsg.Replace("$seconds", "" + i), true);
                        //PlayerManager.localPlayer.GetComponent<MTFRespawn>().RpcPlayCustomAnnouncement(".g3", false, false);
                    }
                }
                yield return Timing.WaitForSeconds(1f);
            }
            foreach (var item in doors)
            {
                item.TargetState = false;
                item.ServerChangeLock(DoorLockReason.Lockdown079, true);
            }
            foreach (var ply in PlayerManager.players)
            {
                var player = new Player(ply);
                if (player.Team != Team.SCP && player.CurrentRoom != null && player.CurrentRoom.Transform == room.Transform)
                {
                    player.ReferenceHub.hints.Show(new TextHint(Better079Plugin.instance.Config.b079_msg_a2_active, new HintParameter[] { new StringHintParameter("") }, new HintEffect[]
                    {
                        HintEffectPresets.TrailingPulseAlpha(0.5f, 1f, 0.5f, 2f, 0f, 3)
                    }, 5f));
                }
            }
            for (int i = 0; i < Better079Plugin.instance.Config.b079_a2_gas_timer * 2; i++)
            {
                foreach (var ply in PlayerManager.players)
                {
                    var player = new Player(ply);
                    if (player.Team != Team.SCP && player.Role != RoleType.Spectator && player.CurrentRoom != null && player.CurrentRoom.Transform == room.Transform)
                    {
                        player.ReferenceHub.playerStats.HurtPlayer(new PlayerStats.HitInfo(10f, "SCP-079 Memetic", DamageTypes.Poison, 0), player.ReferenceHub.gameObject);
                        if (player.Role == RoleType.Spectator)
                        {
                            scp.scp079PlayerScript.AddExperience(Better079Plugin.instance.Config.b079_a2_exp);
                        }
                    }
                }
                yield return Timing.WaitForSeconds(0.5f);
            }
            foreach (var item in doors)
            {
                item.TargetState = true;
                item.ServerChangeLock(DoorLockReason.Lockdown079, false);
                
            }
        }
    }
}