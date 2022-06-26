using System;
using com.Icypeak.Orbit.Obstacle;
using UnityEngine;

namespace com.Icypeak.Orbit.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] int scorePoints;
        public int ScorePoints { get => scorePoints; }
        public Action<int> OnScoreChange;

        private void IncreaseScore()
        {
            scorePoints++;
            OnScoreChange?.Invoke(scorePoints);
        }

        void OnEnable()
        {
            if (Director.GameMode == 1)
                ObstacleBehaviour.OnDeath += IncreaseScore;
            else
                ObstacleBehaviour.OnEscape += IncreaseScore;
        }

        void OnDisable()
        {
            if (Director.GameMode == 1)
                ObstacleBehaviour.OnDeath -= IncreaseScore;
            else
                ObstacleBehaviour.OnEscape -= IncreaseScore;
        }
    }
}
