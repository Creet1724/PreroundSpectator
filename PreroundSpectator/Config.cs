using System.ComponentModel;

namespace PreroundSpectator
{
    public class Config
    {
        [Description("Is this plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
    }
}