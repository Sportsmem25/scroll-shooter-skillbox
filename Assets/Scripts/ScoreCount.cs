using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount Instance;

    [SerializeField] private Text scoreText;
    [SerializeField] private ScenesController scenesController;

    private int winScore = 290;
    private int score;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public static void AddScore(int amount)
    {
        Instance.score += amount;
        Debug.Log($"Скрипт ScoreCount - Начисляем {amount}. Сейчас {Instance.score} очков.");
        Instance.UpdateUI();

        if (Instance.score >= Instance.winScore)
            Instance.StartCoroutine(Instance.EnableWinScene());
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
    }


    IEnumerator EnableWinScene()
    {
        yield return new WaitForSeconds(2);
        scenesController.LoadWinScene();
    }
}
