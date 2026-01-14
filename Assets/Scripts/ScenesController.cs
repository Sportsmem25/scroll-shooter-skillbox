using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    [SerializeField] private int numberScene;

    public bool _iscanShootPlayer;

    /// <summary>
    /// Загрузка уровня
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene(numberScene);
    }

    /// <summary>
    /// Загрузка стартовой сцены
    /// </summary>
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Загрузка следующей сцены
    /// </summary>
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }

    /// <summary>
    /// Перезагрузка сцены
    /// </summary>
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ContinueGame();
    }

    /// <summary>
    /// Загрузка победной сцены
    /// </summary>
    public void LoadWinScene()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Загрузка сцены проигрыша
    /// </summary>
    public void LoadLoseScene()
    {
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// Выход из игры
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();

    #if Unity_Editor
        UnityEditor.EditorApplication.isPlaying = false; // Exit play mode
    #endif
    }

    /// <summary>
    /// Пауза игры
    /// </summary>
    public void PausedGame()
    {
        Time.timeScale = 0f;
        _iscanShootPlayer = false;
    }

    /// <summary>
    /// Продолжение игры
    /// </summary>
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        _iscanShootPlayer = true;
    }
}
