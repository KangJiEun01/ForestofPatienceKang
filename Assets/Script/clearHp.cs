using UnityEngine;

public class clearHp : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] carrot;
    int hp;
    void Start()
    {
        hp = player.GetComponent<Player_Controller02>().GetClearDataHp();
        HPscore();
    }
    void HPscore()
    {
        if (hp == 2)
        {
            carrot[0].SetActive(true);
            carrot[1].SetActive(false);
            carrot[2].SetActive(false);
        }
        else if (hp == 1)
        {
            carrot[0].SetActive(true);
            carrot[1].SetActive(true);
            carrot[2].SetActive(false);
        }
        else if (hp == 0)
        {
            carrot[0].SetActive(true);
            carrot[1].SetActive(true);
            carrot[2].SetActive(true);
        }
    }
}
