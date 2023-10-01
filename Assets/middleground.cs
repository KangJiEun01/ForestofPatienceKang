using UnityEngine;

public class middleground : MonoBehaviour
{
    [SerializeField] GameObject _middleGrd;
    [SerializeField] GameObject _backGrd;
    [SerializeField] GameObject _grid;

    float _Mspeed = 1.7f;
    float _Bspeed = 1.0f;
    float _Gspeed = 3.0f;

    Vector3 miStart = new Vector3(24.93f, 0, 0); //생성한 이미지 트렌스폼을 기준으로 바꾸기
    Vector3 bkStart = new Vector3(18.93f, 0, 0);
    Vector3 grStart = new Vector3(23.93f, 0, 0);


    private void Start()
    {
        // BGInst = GetComponent<BGroungMove>


        GameObject middlePrefad = Instantiate(_middleGrd);
        GameObject backPrefad = Instantiate(_backGrd);
        GameObject gridPrefad = Instantiate(_grid);
        middlePrefad.transform.position = new Vector3(1, 0, 0);
        backPrefad.transform.position = new Vector3(-5, 0, 0);
        gridPrefad.transform.position = new Vector3(0, 0, 0);

        float x = Mathf.Cos(180);
        Vector3 dir = new Vector3(x, 0, 0);
        middlePrefad.GetComponent<MGroundMove>().MGInit(dir, _Mspeed);
        backPrefad.GetComponent<BGroungMove>().BGInit(dir, _Bspeed);
        gridPrefad.GetComponent<GGroundMove>().GGInit(dir, _Gspeed);


        middlePrefad = Instantiate(_middleGrd);
        backPrefad = Instantiate(_backGrd);
        gridPrefad = Instantiate(_grid);
        middlePrefad.transform.position = new Vector3(24.93f, 0, 0);
        backPrefad.transform.position = new Vector3(18.93f, 0, 0);
        gridPrefad.transform.position = new Vector3(23.93f, 0, 0);

        middlePrefad.GetComponent<MGroundMove>().MGInit(dir, _Mspeed);
        backPrefad.GetComponent<BGroungMove>().BGInit(dir, _Bspeed);
        gridPrefad.GetComponent<GGroundMove>().GGInit(dir, _Gspeed);
    }

    void Update()
    {
    }

    //void GroundInst()
    //{
    //    GameObject middlePrefad = Instantiate(_middleGrd);
    //    GameObject backPrefad = Instantiate(_backGrd);
    //    GameObject gridPrefad = Instantiate(_grid);
    //    middlePrefad.transform.position = miStart;
    //    backPrefad.transform.position = bkStart;
    //    gridPrefad.transform.position = grStart;

    //    float x = Mathf.Cos(180);
    //    Vector3 dir = new Vector3(x, 0, 0);
    //    middlePrefad.GetComponent<MGroundMove>().MGInit(dir, _Mspeed);
    //    backPrefad.GetComponent<BGroungMove>().BGInit(dir, _Bspeed);
    //    gridPrefad.GetComponent<GGroundMove>().GGInit(dir, _Gspeed);


    //    GetComponent<BGroungMove>().BGInstan(BGInst);
    //}
    public void GridInst()
    {
        GameObject gridPrefad = Instantiate(_grid);
        //gridPrefad.transform.position = grStart;
        gridPrefad.transform.position = grStart;

        float x = Mathf.Cos(180);
        Vector3 dir = new Vector3(x, 0, 0);
        gridPrefad.GetComponent<GGroundMove>().GGInit(dir, _Gspeed);
    }
    public void BackInst()
    {
        GameObject backPrefad = Instantiate(_backGrd);
        backPrefad.transform.position = bkStart;

        float x = Mathf.Cos(180);
        Vector3 dir = new Vector3(x, 0, 0);
        backPrefad.GetComponent<BGroungMove>().BGInit(dir, _Bspeed);
    }
    public void MidInst()
    {
        GameObject middlePrefad = Instantiate(_middleGrd);
        middlePrefad.transform.position = miStart;

        float x = Mathf.Cos(180);
        Vector3 dir = new Vector3(x, 0, 0);
        middlePrefad.GetComponent<MGroundMove>().MGInit(dir, _Mspeed);
    }
}
