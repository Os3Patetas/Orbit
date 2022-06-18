using UnityEngine;
using TMPro;
using com.Icypeak.Orbit.Player;

namespace com.Icypeak.Orbit.UI.Score
{
    public class ScoreUIBehaviour : MonoBehaviour
    {
        TextMeshProUGUI _scoreTextComponent;

        void Awake()
        {
            _scoreTextComponent = GetComponent<TextMeshProUGUI>();
        }

        void OnEnable()
        {
            PlayerStats.OnScoreChange += UpdateScoreText;
        }

        void OnDisable()
        {
            PlayerStats.OnScoreChange -= UpdateScoreText;
        }


        void UpdateScoreText(int score)
        {
            _scoreTextComponent.text = score.ToString();
        }
    }
}
