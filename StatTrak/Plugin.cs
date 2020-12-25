using IPA;
using IPA.Config.Stores;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using StatTrak.Configuration;
using StatTrak.Handlers;
using BS_Utils.Utilities;

namespace StatTrak
{

    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin instance { get; private set; }
        internal static string Name => "StatTrak";

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(IPALogger logger, IPA.Config.Config config)
        {
            instance = this;
            Logger.log = logger;
            Logger.log.Debug("Logger initialized.");
            PluginConfig.Instance = config.Generated<PluginConfig>();
            MainHandler.LoadData();
            BSEvents.noteWasCut += MainHandler.CutEvent;
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Logger.log.Debug("OnApplicationStart");
            SceneManager.activeSceneChanged += MainHandler.OnActiveSceneChanged;
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Logger.log.Debug("OnApplicationQuit");

        }
    }
}
