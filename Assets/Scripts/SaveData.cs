using System.Collections;
using UnityEngine;


namespace Assets.Scripts
{
    [System.Serializable]
    public class SaveData
    {
        public static SaveData Current;
        public static SaveData current {
            get
            {
                if (Current == null)
                {
                    Current = new SaveData();
                }
                return Current;
            }

        }
        public PlayerProfile profile;
    }
    
}