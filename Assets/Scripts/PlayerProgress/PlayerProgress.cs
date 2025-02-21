
using System;
using UnityEngine;

namespace TestTask.Progress
{
    [Serializable]
    public partial class PlayerProgress : MonoBehaviour
    {
        private const string PrefsKey = "Progress";

        private static PlayerProgress instance;
        public static PlayerProgress Instance
        {
            get
            {
                if (instance == null)
                {
                    var jsonData = PlayerPrefs.GetString(PrefsKey);
                    instance = JsonUtility.FromJson<PlayerProgress>(jsonData);
                    if (instance == null)
                    {
                        instance = new PlayerProgress();
                        instance.SetDefaults();
                    }
                }

                return instance;
            }
        }

        public void Save()
        {
            var jsonData = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(PrefsKey, jsonData);
            PlayerPrefs.Save();
        }
    }
}
