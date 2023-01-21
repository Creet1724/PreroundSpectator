using PluginAPI.Core.Attributes;
using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace PreroundSpectator
{
    public class Plugin
    {
        public const string Name = "PreroundSpectator";
        public const string Version = "v0.1";
        public const string PluginDescription = "Spawns you as spectator before the round starts, allows you to customize your weapons before the round starts.";
        public const string Author = "Creet1724";
        public static Plugin Instance { get; private set; }

        [PluginConfig("PreroundSpectator.yml")]
        public Config Config;

        [PluginPriority(LoadPriority.Medium)]
        [PluginEntryPoint(Name, Version, PluginDescription, Author)]
        void LoadPlugin()
        {
            if (!Config.IsEnabled)
                return;
            Instance = this;
            EventManager.RegisterEvents(this);
            Log.Info($"Loading PreroundSpectator {Version} by Creet1724");
            var handler = PluginHandler.Get(this);
            handler.SaveConfig(this, nameof(Config));
        }

        [PluginEvent(ServerEventType.PlayerJoined)]
        public void PlayerJoined(Player p)
        {
            p.SetRole(PlayerRoles.RoleTypeId.Spectator);
        }
    }
}
