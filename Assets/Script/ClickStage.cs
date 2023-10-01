using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickStage : MonoBehaviour
{
    public void Stage01Road()
    {
        SceneManager.LoadScene("Stage_01");
    }
    public void Stage02Road()
    {
        SceneManager.LoadScene("Stage_02");
    }
}
