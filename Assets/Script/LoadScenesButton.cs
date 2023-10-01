using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesButton : MonoBehaviour
{
    public void ExitButton()//버튼 : 스테이지 선택 전에는 start 버튼 비활성화하고 
        //활성화된 스테이지 클릭한 경우만 start버튼 활성화
    {
        SceneManager.LoadScene("Main");
    }
}
