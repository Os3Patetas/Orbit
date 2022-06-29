using UnityEngine;
using com.Icypeak.Orbit.General;

namespace com.Icypeak.Orbit.Player
{
    [System.Serializable]
    [CreateAssetMenu(fileName ="PlayerInfo",menuName ="PlayerInfo/New")]
    public class PlayerInfo : ScriptableObject
    {
        public double coins = 0;
        public int highestScore = 0;
        public string selectedSkin = "Default";
        public CoinBonus activatedBonus;
    }
}
