using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public sealed class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    private int _score;

    public int Score
    {
        get => _score;
        set
        {
            if (_score == value)
                return; // Only update if the new score is different

            _score = value;

            // Update the TextMeshProUGUI component
            if (scoreText != null)
            {
                scoreText.text = $"Score: {_score}";
            }
        }
    }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        // Ensure that there is only one instance of ScoreCounter
        if (Instance == null)
        {
            Instance = this;
            // Optionally, you could add this line if you want to persist the singleton across scenes:
            // DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            // Destroy this instance if it's a duplicate
            Destroy(gameObject);
        }
    }
}
