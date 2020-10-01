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
        [Description("Better SCP-079 esta activado o no")]
        public bool IsEnabled { get; set; } = true;

        [Description("El Prefijo del comando")]
        public string b079_prefix { get; set; } = "s079";
        [Description("Textos de ayuda")]
        public string b079_help_title { get; set; } = "Abilities/Commands:";
        public string b079_help_a1 { get; set; } = "Teleport to your SCP friends";
        public string b079_help_a2 { get; set; } = "Activate a memetic in the current room (only on humans)";
        public string b079_help_a3 { get; set; } = "Shutdown Zone Lighting";
        public string b079_help_a4 { get; set; } = "Camera Flash (blinds others)";

        [Description("Texto cuando necesita X nivel o X de energia")]
        public string b079_msg_tier_required { get; set; } = "Tier $tier+ Required";
        public string b079_msg_no_power { get; set; } = "Not enough power.";
        public string b079_msg_help_cmd_fail { get; set; } = "Invalid. Type \".$prefix ?\" for help.";

        [Description("Mensajes de activacion Teleport")]
        public string b079_msg_a1_fail { get; set; } = "No SCPs found.";
        public string b079_msg_a1_run { get; set; } = "Teleporting...";

        [Description("Mensajes del ataque memetico")]
        public string b079_msg_a2_fail { get; set; } = "Memetics don't work here!";
        public string b079_msg_a2_run { get; set; } = "Activating...";

        [Description("Mensaje del apagon")]
        public string b079_msg_a3_run { get; set; } = "Overcharging...";
        [Description("Granada Flash")]
        public string b079_msg_a4_run { get; set; } = "Flashing...";

        [Description("Advertencia del agente memetico")]
        public string b079_msg_a2_warn { get; set; } = "<color=#ff0000>MEMETIC KILL AGENT will activate in this room in $seconds seconds.</color>";
        [Description("Mensaje de activacion del agente memetico")]
        public string b079_msg_a2_active { get; set; } = "<color=#ff0000>MEMETIC KILL AGENT ACTIVATED.</color>";
        [Description("Mensaje de Spawn del SCP-079")]
        public string b079_spawn_msg { get; set; } = "<color=#00ff00>[Better079] Type \".079 help\" in the console for more abilities.</color>";

        [Description("Configuracion de A1 | teleport")]
        public float b079_a1_dist { get; set; } = 15f;
        [Description("Energia necesaria")]
        public float b079_a1_power { get; set; } = 15f;
        [Description("Nivel necesario para la habilidad | 0 = Tier 1 | 1 = Tier 2 | 2 = Tier 3 | 3 = Tier 4 | 4 = Tier 5")]
        public int b079_a1_tier { get; set; } = 0;

        [Description("Configuracion de la habilidad A4 | Granada Flash")]
        public float b079_a4_power { get; set; } = 40f;
        public int b079_a4_tier { get; set; } = 1;

        [Description("Configuracion de la habilidad A3 | Apagon")]
        public float b079_a3_power { get; set; } = 100f;
        [Description("Duracion del apagon")]
        public float b079_a3_timer { get; set; } = 30f;
        [Description("Nivel necesario para la habilidad | 0 = Tier 1 | 1 = Tier 2 | 2 = Tier 3 | 3 = Tier 4 | 4 = Tier 5 ")]
        public int b079_a3_tier { get; set; } = 1;

        [Description("Configuracion de Ataque memetico | A2")]
        public float b079_a2_power { get; set; } = 75f;
        [Description("Nivel necesario")]
        public int b079_a2_tier { get; set; } = 2;
        [Description("Duracion hasta que se cierren las puertas")]
        public int b079_a2_timer { get; set; } = 5;
        [Description("Duracion del ataque memetico")]
        public int b079_a2_gas_timer { get; set; } = 10;
        [Description("EXP por matar por memetico")]
        public float b079_a2_exp { get; set; } = 35f;
        [Description("CD de la habilidad")]
        public float b079_a2_cooldown { get; set; } = 60f;
        [Description("Cuartos donde no se pueden usar")]
        public List<string> b079_a2_blacklisted_rooms { get; set; } = new List<string>();
        [Description("Deberia cassie anunciar el ataque memetico")]
        public bool b079_a2_disable_cassie { get; set; } = false;
    }
}
