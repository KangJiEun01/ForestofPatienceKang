using UnityEngine;

public class UIInteract : MonoBehaviour
{
    int count = 0;
    public void OnBtnClickEvent()
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
