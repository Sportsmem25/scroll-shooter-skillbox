using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    [SerializeField] private int numberScene;

    public bool _iscanShootPlayer;

    /// <summary>
    /// ����� ����������� �������
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene(numberScene);
    }

    /// <summary>
    /// ����� ����������� ��������� �����
    /// </summary>
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// ����� ����������� ��������� �����
    /// </summary>
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }

    /// <summary>
    /// ����� ������������ �����
    /// </summary>
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// ����� ����������� �������� �����
    /// </summary>
    public void LoadWinScene()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// ����� ����������� ����� ���������
    /// </summary>
    public void LoadLoseScene()
    {
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    #if Unity_Editor
        UnityEditor.EditorApplication.isPlaying = false; // Exit play mode
    #endif
    }

    /// <summary>
    /// ����� ����
    /// </summary>
    public void PausedGame()
    {
        Time.timeScale = 0f;
        _iscanShootPlayer = false;
    }

    /// <summary>
    /// ����������� ����
    /// </summary>
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        _iscanShootPlayer = true;
    }
}
