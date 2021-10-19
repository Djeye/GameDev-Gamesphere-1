using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BubbleManager bubbleManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private int _score = 0;

    private void Start()
    {
        bubbleManager.ClickOnBubble += AddScore;
    }

    private void AddScore()
    {
        _score++;
        scoreText.text = $"score: {_score}";
    }

    private void OnDisable()
    {
        bubbleManager.ClickOnBubble -= AddScore;
    }
}