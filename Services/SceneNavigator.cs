using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

using blazor_dads_text_adventure.Data;

namespace blazor_dads_text_adventure.Services
{
    public class SceneNavigator
    {
        private IEnumerable<Scene> Scenes;
        private GameConfigModel Config;

        public SceneNavigator(IEnumerable<Scene> scenes, GameConfigModel config)
        {
            Scenes = scenes;
            Config = config;
        }

        public MarkupString ListLoadedScenes()
        {
            var sceneKeys = string.Join(' ',
                from scene in Scenes
                select $"{scene.SceneKey}<br />");
            
            return (MarkupString)sceneKeys;
        }

        public MarkupString ListGameConfig()
        {
            return (MarkupString)$"{Config.StartScene}";
        }

        public string Start()
        {
            return Config.StartScene;
        }

        public Scene GetActiveScene(string sceneKey = null)
        {
            var targetKey = (sceneKey == null ? Config.StartScene : sceneKey);
            return getTargetScene(targetKey);
        }

        public MarkupString GetSceneText(string sceneKey = null)
        {
            var targetKey = (sceneKey == null ? Config.StartScene : sceneKey);
            var targetScene = getTargetScene(targetKey);

            return convertSceneTextToMarkup(targetScene.Lines);
        }

        public IEnumerable<SceneAction> GetSceneActions(string sceneKey = null)
        {
            var targetKey = (sceneKey == null ? Config.StartScene : sceneKey);
            var targetScene = getTargetScene(targetKey);

            return targetScene.Actions;
        }

        private Scene getTargetScene(string sceneKey) => Scenes.First(scene => scene.SceneKey == sceneKey);

        private MarkupString convertSceneTextToMarkup(IEnumerable<SceneLine> sceneText)
        {
            List<MarkupString> retString = new List<MarkupString>();
            
            foreach (var line in sceneText)
                retString.Add((MarkupString)$"{getLeadingSpaces(line.Spaces + 1)}{line.Line}<br />");
            
            return (MarkupString)string.Concat(retString);
        }

        private MarkupString getLeadingSpaces(int numSpaces)
        {
            var retString = string.Empty;
            for (var index = 0; index < numSpaces; index++)
            {
                retString += $"&nbsp;";
            }

            return (MarkupString)retString;
        }
    }
}