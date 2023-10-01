using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainbutton : MonoBehaviour
{
    public void ClickStartButton()
    {
        SceneManager.LoadScene("Stage_01");
    }
    public void ClickLoadButton()
    {
        SceneManager.LoadScene("LoadGame");
    }
}
