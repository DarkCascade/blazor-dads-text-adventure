using blazor_dads_text_adventure.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace blazor_dads_text_adventure.Utilities
{
    // load scenes from scenes.json
    // parse scenes:
    // - get key
    // - use line text and spaces to generate final MarkupString
    // parse actions:
    // - generate button with action text
    // - generate click handler to change scene text

    public class SceneLoader
    {
        public async Task<IEnumerable<Scene>> LoadScenes(HttpClient client)
        {
            return await client.GetFromJsonAsync<Scene[]>("scene-data/scenes.json");
        }

        public async Task<GameConfigModel> LoadConfiguration(HttpClient client)
        {
            return await client.GetFromJsonAsync<GameConfigModel>("scene-data/game-config.json");
        }
    }
}