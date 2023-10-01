using UnityEngine;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool isPaused;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static GameManager Instance
    {
        get { return instance; }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
}

