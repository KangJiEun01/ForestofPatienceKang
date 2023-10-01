using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StageData : MonoBehaviour
{
    [SerializeField] Type _name;
    ClearDataList datas;

    [SerializeField] GameObject[] Score;

    bool datasave = false;

    [SerializeField] GameObject _stg01True;
    [SerializeField] GameObject _stg01False;

    [SerializeField] GameObject _stg01;

    [SerializeField] GameObject _RankS;
    [SerializeField] GameObject _RankA;
    [SerializeField] GameObject _RankB;
    [SerializeField] GameObject _RankC;
    [SerializeField] GameObject _RankD;
    [SerializeField] GameObject _RankF;

    bool _stg01clear = false;
    bool _stg02clear = false;
    bool _stg03clear = false;
    bool _stg04clear = false;
    bool _stg05clear = false;
    bool _stg06clear = false;

    void Start()
    {
        datas = new ClearDataList();
        datas.datas = new List<ClearData>();
    }
    private void OnEnable()
    {
        DataRead();
        Stg01DataRead();
        RankDatas();
    }

    void Update()
    {
        StageButton();
    }
    void RankDatas()
    {
        if (datas.datas.Count > 0)
        {
            ClearData firstData = datas.datas[0];
            Debug.Log("1stageName" + firstData._name);
            Debug.Log("Stage Clear Data: " + firstData._stageClearData);
        }
    }
    void ClartDatas()
    {
        if (datas.datas.Count > 0)
        {
            ClearData firstData = datas.datas[0];
            Debug.Log("1stageName" + firstData._name);
            Debug.Log("Stage Clear Data: " + firstData._stageClearData);
        }
    }
    void Stg01DataRead()
    {
        if (File.Exists(Application.persistentDataPath + "/stg01cleardata.json"))//데이터가 있으면 
        {
            if (datas.datas.Count > 0)//나중에 프리펩 데이터 로드해서 타입으로 가져오는걸로 바꾸기
                                      //아니면 생성 포지션 변경
            {
                _stg01True.SetActive(true);
                _stg01False.SetActive(false);
                _stg01clear = true;
                ClearData firstData = datas.datas[0];
                _name = firstData._name;
                Debug.Log("_name");
                if (_name == Type.S)
                {
                    _RankS.SetActive(true);
                }
                else if (_name == Type.A)
                {
                    _RankA.SetActive(true);
                }
                else if (_name == Type.B)
                {
                    _RankB.SetActive(true);
                    _RankS.SetActive(false);
                }
                else if (_name == Type.C)
                {
                    _RankC.SetActive(true);
                    _RankS.SetActive(false);
                }
                else if (_name == Type.D)
                {
                    _RankD.SetActive(true);
                }
                else if (_name == Type.F)
                {
                    _RankF.SetActive(true);
                }
            }
        }
        else
        {
            _stg01True.SetActive(false);
            _stg01False.SetActive(true);
            _stg01clear = false;
        }
    }// 파일 하나로 관리하게 수정********************************

    public void StageButton()
    {
        if (_stg01clear)
        {
            _stg01.SetActive(true);
        }
    }

    void LoadData()
    {
        string path = Application.persistentDataPath + "/stg01cleardata.json";

        if (File.Exists(path))
        {
            using (StreamReader inStream = File.OpenText(path))
            {
                string json = inStream.ReadToEnd();
                datas = JsonUtility.FromJson<ClearDataList>(json);
            }
        }
        else
        {
            datas = new ClearDataList();
            datas.datas = new List<ClearData>();
        }
    }
    void DataRead()
    {
        if (File.Exists(Application.persistentDataPath + "/stg01cleardata.json"))
        {
            string json = "";
            using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/stg01cleardata.json"))
            {
                json = inStream.ReadToEnd();
            }
            if (string.IsNullOrEmpty(json) == false)
            {
                datas = JsonUtility.FromJson<ClearDataList>(json);
            }
        }
    }
}
