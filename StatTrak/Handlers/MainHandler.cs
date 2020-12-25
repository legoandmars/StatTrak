using StatTrak.Configuration;
using StatTrak.Data;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

namespace StatTrak.Handlers
{
    public static class MainHandler
    {
        public static List<StatTrakData> DataList;

        public static Data.StatTrak ActiveStatTrak;
        public static void LoadData()
        {
            DataList = PluginConfig.Instance.data;
            if(DataList == null) DataList = new List<StatTrakData>();
        }

        public static void SaveData()
        {
            PluginConfig.Instance.data = DataList;
        }

        public static void InitializeStatTrak(Data.StatTrak statTrak)
        {
            // Does the stattrak instance already exist? if not, let's add it
            List<StatTrakData> foundData = DataList.FindAll(x => x.ID == statTrak.StatTrakID);
            StatTrakData data;
            if (!foundData.Any())
            {
                StatTrakData newData = new StatTrakData();
                newData.ID = statTrak.StatTrakID;
                newData.BlocksSliced = 0;
                DataList.Add(newData);
                data = newData;
            }
            else data = foundData[0];
            if (SceneManager.GetActiveScene().name.ToLower() == "gamecore")
            {
                ActiveStatTrak = statTrak;
            }
            else
            {
                // do UI stuff
                UIHandler.CreateUI(data);
            }
            // properly set text on initial load
            if (statTrak.StatTrakText != null)
            {
                foreach (TMP_Text text in statTrak.StatTrakText)
                {
                    text.SetText(GetFormattedNumber(data.BlocksSliced));
                }
            }
        }

        public static void UninitializeStatTrak(Data.StatTrak statTrak)
        {
            ActiveStatTrak = null;

            // find the data and do UI stuff
            List<StatTrakData> foundData = DataList.FindAll(x => x.ID == statTrak.StatTrakID);

            if (foundData.Any()) UIHandler.DestroyUI(foundData[0]);
        }

        public static void CutEvent(NoteData noteData, NoteCutInfo noteCutInfo, int arg3) {
            if (noteCutInfo.allIsOK)
            {
                if(ActiveStatTrak != null)
                {
                    for(int i = 0; i < DataList.Count; i++)
                    {
                        if(DataList[i].ID == ActiveStatTrak.StatTrakID)
                        {
                            DataList[i].BlocksSliced++;
                            // handle setting TMP text
                            if (ActiveStatTrak.StatTrakText != null)
                            {
                                foreach (TMP_Text text in ActiveStatTrak.StatTrakText)
                                {
                                    text.SetText(GetFormattedNumber(DataList[i].BlocksSliced));
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            if(nextScene.name.ToLower() != "gamecore")
            {
                SaveData();
            }
        }

        // Utils
        public static string GetFormattedNumber(int number) {
            if (number >= 1000000000)
            {
                // I *seriously* doubt anybody is ever going to hit a billion blocks sliced with one saber, but if you do... congrats, I guess?
                return ((float)number / 1000000000).ToString("0.0") + "B";
            }
            else if (number >= 1000000)
            {
                return ((float)number / 1000000).ToString("0.0") + "M";
            }
            else if (number >= 1000)
            {
                return ((float)number / 1000).ToString("0.0") + "K";
            } else return number.ToString();
        } 

    }
}
