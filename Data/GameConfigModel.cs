using Newtonsoft.Json;

namespace blazor_dads_text_adventure.Data
{
    public class GameConfigModel
    {
        [JsonProperty("startScene")]
        public string StartScene { get; set; }
    }
}