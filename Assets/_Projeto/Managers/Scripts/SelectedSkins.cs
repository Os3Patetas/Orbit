using UnityEngine;

using com.Icypeak.Orbit.Utils;

namespace com.Icypeak.Orbit.Managers
{
    [CreateAssetMenu(menuName = "SelectedSkinList/New")]
    [System.Serializable]
    public class SelectedSkins : ScriptableObject
    {
        public Skin PlayerSkin;
        public Skin ObstacleSkin;
        public Skin LifePowerupSkin;
    }
}
