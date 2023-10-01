using UnityEngine;

public class PauseButton : MonoBehaviour
{
    int count = 0;
    public void OnBtnClickEvent()
    {
        MouseButtonDown();
    }
    void MouseButtonDown()
    {
        if (count == 0)
        {
            count++;
            GameManager.Instance.PauseGame();
        }
        else if (count == 1)
        {
            count = 0;
            GameManager.Instance.ResumeGame();
        }
    }
}
