using UnityEngine;

namespace com.Icypeak.Orbit.Obstacle
{
    [CreateAssetMenu(menuName="Obstacle/Skin/New", fileName="ObstacleSkin")]
    [System.Serializable]
    public class ObstacleSkin : ScriptableObject
    {
        public float RotationSpeed;
        public Sprite ObstacleSprite;
    }
}
