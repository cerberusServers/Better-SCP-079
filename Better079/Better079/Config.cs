using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better079
{
    public class Config : IConfig
    {
        [Description("The plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;

        [Description("The command prefix")]
        public string b079_prefix { get; set; } = "s079";
        [Description("Help texts")]
        public string b079_help_title { get; set; } = "Habilidades/Comandos:";
        public string b079_help_a1 { get; set; } = "Te teletransportaras a tu aliado SCP mas cercano";
        public string b079_help_a2 { get; set; } = "Activa un agante memético mortal en la sala donde estes (Solo daña a los humanos)";
        public string b079_help_a3 { get; set; } = "Apaga las luces de la zona donde estas actualmente Surface/Heavy/Light";
        public string b079_help_a4 { get; set; } = "Ciega a los que esten cerca de la camara";

        [Description("Error msg")]
        public string b079_msg_tier_required { get; set; } = "\n<color=#00ddff>Tier</color> <color=#00ddff>$tier+</color> <color=#00ddff>requerido</color>";
        public string b079_msg_no_power { get; set; } = "\n<color=#f70090>No tienes suficiente energia</color>";
        public string b079_msg_help_cmd_fail { get; set; } = "\n<color=#f21400>Invalido</color>. <color=#f27100>Usa \".$prefix?\" para mas ayuda.</color>";

        [Description("Message activation A1")]
        public string b079_msg_a1_fail { get; set; } = "\n<color=#f26d00>No hay SCP's Cerca</color>";
        public string b079_msg_a1_run { get; set; } = "\n<color=#1df700>Viajando...</color>";

        [Description("Message A2")]
        public string b079_msg_a2_fail { get; set; } = "\n<color=#fafafa>Agente memetico</color> <color=#ff0000>no disponible</color> <color=#fafafa>en esta sala</color>";
        public string b079_msg_a2_run { get; set; } = "\n<color=#08bdff>Activando agente memético....</color>";

        [Description("Message A3")]
        public string b079_msg_a3_run { get; set; } = "\n<color=#5d00ff>Apagando luces</color>...";
        [Description("Message A4")]
        public string b079_msg_a4_run { get; set; } = "\n<color=#ffc508>Sobrecargando flash de la camara....</color>";

        [Description("Memetic agent warning for humans in the room")]
        public string b079_msg_a2_warn { get; set; } = "\n<b><size=32><color=#329600>[</color><color=red>PELIGRO</color><color=#329600>]</color> <color=#f29f05>Agente memético </color> <color=#f29f05>activandose en esta sala en $seconds segundos</color></size></b>";
        [Description("Memetic message activation")]
        public string b079_msg_a2_active { get; set; } = "\n<color=#ff0000>Agente memético activado!</color>";
        [Description("SCP-079 spawn message")]
        public string b079_spawn_msg { get; set; } = "<color=#329600>[Better079]</color><color=#08c3d4> Escribe \".079 help\" en la consola abriendola con la Ñ para ver las habilidades que tienes.</color>";

        [Description("Configs A1 | teleport | distance skill A1")]
        public float b079_a1_dist { get; set; } = 25f;
        [Description("Power needed")]
        public float b079_a1_power { get; set; } = 15f;
        [Description("Tier required | 0 = Tier 1 | 1 = Tier 2 | 2 = Tier 3 | 3 = Tier 4 | 4 = Tier 5")]
        public int b079_a1_tier { get; set; } = 0;

        [Description("Configs A4 | Flash | power needed")]
        public float b079_a4_power { get; set; } = 85f;
        [Description("Tier required | 0 = Tier 1 | 1 = Tier 2 | 2 = Tier 3 | 3 = Tier 4 | 4 = Tier 5")]
        public int b079_a4_tier { get; set; } = 1;

        [Description("Configs A3 | facility lights")]
        public float b079_a3_power { get; set; } = 45f;
        [Description("Failure time")]
        public float b079_a3_timer { get; set; } = 15f;
        [Description("Tier required | 0 = Tier 1 | 1 = Tier 2 | 2 = Tier 3 | 3 = Tier 4 | 4 = Tier 5")]
        public int b079_a3_tier { get; set; } = 1;

        [Description("Configs A2 | Memetic kill agent")]
        public float b079_a2_power { get; set; } = 75f;
        [Description("Tier required | 0 = Tier 1 | 1 = Tier 2 | 2 = Tier 3 | 3 = Tier 4 | 4 = Tier 5")]
        public int b079_a2_tier { get; set; } = 3;
        [Description("Time before the doors close")]
        public int b079_a2_timer { get; set; } = 5;
        [Description("Memetic agent duration")]
        public int b079_a2_gas_timer { get; set; } = 10;
        [Description("Killing XP with memetic agent")]
        public float b079_a2_exp { get; set; } = 35f;
        [Description("Cooldown")]
        public float b079_a2_cooldown { get; set; } = 10f;
        [Description("Blacklist rooms | recommended: - LCZ_914 - EZ_GateB - EZ_GateA - HCZ_106")]
        public List<string> b079_a2_blacklisted_rooms { get; set; } = new List<string>();
        [Description("Cassie announcement memetic agent | for the sake of your ears leave this on false")]
        public bool b079_a2_disable_cassie { get; set; } = true;
        [Description("Is the XP boost activated")]
        public bool xpboost { get; set; } = false;
        [Description("SCP-079 XP boost, it does not affect the exp of the memetic agent | Default: KillAssist = 0 DirectKill = 1, HardwareHack = 2, AdminCheat = 3, GeneralInteractions = 4, PocketAssist = 5")]
        public Dictionary<ExpGainType, float> experienceGain { get; set; } = new Dictionary<ExpGainType, float> {
            {
                ExpGainType.GeneralInteractions, 5
            },
            {
                ExpGainType.KillAssist, 2
            }
        };
    }
}
