using UnityEngine;
using UnityEngine.SceneManagement;

public class OkButtonClick : MonoBehaviour
{
    public void ClickButton()
    {
        SceneManager.LoadScene("Stage_02");
    }
}
