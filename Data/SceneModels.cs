using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace blazor_dads_text_adventure.Data
{
    public class Scene
    {
        public string SceneKey { get; set; }

        public IEnumerable<SceneLine> Lines { get; set; }

        public IEnumerable<SceneAction> Actions { get; set; }

        public MarkupString ToMarkupString()
        {
            List<string> retInfo = new List<string>();
            
            retInfo.Add($"Scene Key: {SceneKey}");
            retInfo.Add($"Scene Line Count: {Lines.Count()}");
            retInfo.Add($"Scene Action Count: {Actions.Count()}");
            foreach (var action in Actions)
                retInfo.Add(action.ToString());
            
            return (MarkupString)string.Join("<br />", retInfo);
        }
    }

    public class SceneLine
    {
        [JsonProperty("spaces")]
        public int Spaces { get; set; }

        [JsonProperty("line")]
        public string Line { get; set; }
    }

    public class SceneAction
    {

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }
    }
}
