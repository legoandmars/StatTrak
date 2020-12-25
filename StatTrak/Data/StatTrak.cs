using TMPro;
using UnityEngine;

namespace StatTrak.Data
{
    public class StatTrak : MonoBehaviour
    {
        public string StatTrakID;
        public TMP_Text[] StatTrakText;
        void Awake()
        {
            Handlers.MainHandler.InitializeStatTrak(this);
        }

        void OnDisable()
        {
            Handlers.MainHandler.UninitializeStatTrak(this);
        }
    }
}
