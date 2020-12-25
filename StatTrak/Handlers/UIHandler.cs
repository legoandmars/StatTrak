using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.FloatingScreen;
using HMUI;
using StatTrak.Data;
using StatTrak.UI;
using UnityEngine;

namespace StatTrak.Handlers
{
    public static class UIHandler
    {
        private static FloatingScreen Screen;
        internal static StatTrakViewController ViewController;
        public static StatTrakData SelectedStatTrak;
        public static void CreateUI(StatTrakData statTrak)
        {
            if (!Screen)
            {
                SelectedStatTrak = statTrak;
                Screen = FloatingScreen.CreateFloatingScreen(new Vector2(100, 20), false, new Vector3(1.75f, 0.5f, 1f), Quaternion.Euler(0, 60, 0));
                ViewController = BeatSaberUI.CreateViewController<StatTrakViewController>();
                Screen.SetRootViewController(ViewController, HMUI.ViewController.AnimationType.None);
            }
            else
            {
                DestroyUI(statTrak);
                CreateUI(statTrak);
            }
        }

        public static void DestroyUI(StatTrakData statTrak)
        {
            SelectedStatTrak = null;
            if (Screen != null)
            {
                Screen.gameObject.SetActive(false);
                UnityEngine.Object.Destroy(Screen.gameObject);
                Screen = null;
            }
            if (ViewController != null)
            {
                ViewController.gameObject.SetActive(false);
                UnityEngine.Object.Destroy(ViewController.gameObject);
                ViewController = null;
            }
        }
    }
}
