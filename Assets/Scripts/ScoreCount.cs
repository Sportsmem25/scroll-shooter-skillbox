using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private ScenesController scenesController;
    private int killed = 0;

    private void Awake()
    {
        Health.OnEnemyKill.AddListener(EnemyKilled);
    }

    private void Update()
    {
        if(killed >= 290)
        {
            StartCoroutine(EnableWinScene());
        }
    }

    private void EnemyKilled(int countScore)
    {
        killed += countScore;
        scoreText.text = "Score: " + killed;
    }

    IEnumerator EnableWinScene()
    {
        yield return new WaitForSeconds(2);
        scenesController.LoadWinScene();
    }
}
