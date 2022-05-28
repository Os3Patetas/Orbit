using UnityEngine;

namespace com.Icypeak.Orbit.Utils
{
    [System.Serializable]
    public class RandomTimer
    {
        [SerializeField] float _minTime;
        [SerializeField] public float _maxTime;
        [SerializeField] float _timer;

        public bool TimeHasElapsed => _timer <= 0f;

        public RandomTimer(float minTime, float maxTime)
        {
            this._minTime = minTime;
            this._maxTime = maxTime;
            Reset();
        }

        public void Redefine(float minTime, float maxTime)
        {
            this._minTime = minTime;
            this._maxTime = maxTime;
        }

        public void Reset() => _timer = Random.Range(_minTime, _maxTime);
        public void Run(float timeTick) => _timer -= timeTick;
    }
}
