using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesButton : MonoBehaviour
{
    public void ExitButton()//��ư : �������� ���� ������ start ��ư ��Ȱ��ȭ�ϰ� 
        //Ȱ��ȭ�� �������� Ŭ���� ��츸 start��ư Ȱ��ȭ
    {
        SceneManager.LoadScene("Main");
    }
}
