using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class stageclear : MonoBehaviour
{
    [SerializeField] GameObject _gamecleartext;
    [SerializeField] GameObject _gameTimecleartext02;
    [SerializeField] GameObject _baseboard;
    [SerializeField] GameObject _hpScore;
    [SerializeField] GameObject player;
    [SerializeField] GameObject _okButton;
    [SerializeField] GameObject _timescore;
    [SerializeField] GameObject _timer;
    [SerializeField] GameObject[] ClearScoreimg;
    [SerializeField] Type _name;

    ClearDataList datas;

    int _hp;
    int _stageClearData = 1;

    float _second;
    float _minute;
    float ClearScore = 1000f;

    bool datasave = false;

    private void Start()
    {
        datas = new ClearDataList();
        datas.datas = new List<ClearData>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _hp = player.GetComponent<Player_Controller02>().GetClearDataHp();
            _gamecleartext.SetActive(true);
            _gameTimecleartext02.SetActive(true);
            _baseboard.SetActive(true);
            _hpScore.SetActive(true);
            _okButton.SetActive(true);
            //GetComponent<Timescore>().enabled = true; *******************
            datasave = true;
            StageScore();
            DataSave02();
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (File.Exists(Application.persistentDataPath + "/stg01cleardata.json"))//데이터가 있으면 
            {
                string json = "";
                using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/stg01cleardata.json"))//StreamReader읽기 전용
                {
                    json = inStream.ReadToEnd();//ReadToEnd말고 다른 방법으로 읽는 방법 있음
                }
                if (string.IsNullOrEmpty(json) == false)//데이터가 없으면
                {
                    //ItemData data = JsonUtility.FromJson<ItemData>(json);//형식을 제네릭으로 지정
                    datas = JsonUtility.FromJson<ClearDataList>(json);
                    foreach (var data in datas.datas)
                    {
                        Debug.Log($"Hp : {data._hp}, name : {data._name}, clearstage:{data._stageClearData}");
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
    void StageScore()
    {
        _minute = _timer.GetComponent<Timer>().ClearTimeMinute();
        _second = _timer.GetComponent<Timer>().ClearTimeSecond();
        ClearScore = ClearScore - ((_second) + (_minute * 10f) + (_hp * 100));
        if (ClearScore > 980)
        {
            _name = Type.S;
            ClearScoreimg[0].SetActive(true);
            ClearScoreimg[1].SetActive(false);
            ClearScoreimg[2].SetActive(false);
            ClearScoreimg[3].SetActive(false);
            ClearScoreimg[4].SetActive(false);
            ClearScoreimg[5].SetActive(false);
        }
        else if ((ClearScore <= 980 && ClearScore > 950))
        {
            _name = Type.A;
            ClearScoreimg[0].SetActive(false);
            ClearScoreimg[1].SetActive(true);
            ClearScoreimg[2].SetActive(false);
            ClearScoreimg[3].SetActive(false);
            ClearScoreimg[4].SetActive(false);
            ClearScoreimg[5].SetActive(false);
        }
        else if ((ClearScore <= 950 && ClearScore > 850))
        {
            _name = Type.B;
            ClearScoreimg[0].SetActive(false);
            ClearScoreimg[1].SetActive(false);
            ClearScoreimg[2].SetActive(true);
            ClearScoreimg[3].SetActive(false);
            ClearScoreimg[4].SetActive(false);
            ClearScoreimg[5].SetActive(false);
        }
        else if ((ClearScore <= 850 && ClearScore > 700))
        {
            _name = Type.C;
            ClearScoreimg[0].SetActive(false);
            ClearScoreimg[1].SetActive(false);
            ClearScoreimg[2].SetActive(false);
            ClearScoreimg[3].SetActive(true);
            ClearScoreimg[4].SetActive(false);
            ClearScoreimg[5].SetActive(false);
        }
        else if ((ClearScore <= 700 && ClearScore > 500))
        {
            _name = Type.D;
            ClearScoreimg[0].SetActive(false);
            ClearScoreimg[1].SetActive(false);
            ClearScoreimg[2].SetActive(false);
            ClearScoreimg[3].SetActive(false);
            ClearScoreimg[4].SetActive(true);
            ClearScoreimg[5].SetActive(false);
        }
        else if ((ClearScore <= 550))
        {
            _name = Type.F;
            ClearScoreimg[0].SetActive(false);
            ClearScoreimg[1].SetActive(false);
            ClearScoreimg[2].SetActive(false);
            ClearScoreimg[3].SetActive(false);
            ClearScoreimg[4].SetActive(false);
            ClearScoreimg[5].SetActive(true);
        }
    }
    bool checkScoreSave(Type t, Type t2)
    {
        switch (t)
        {
            case Type.S: return false;
            case Type.A: if (t2.Equals(Type.S)) return true; break;
            case Type.B: if (t2.Equals(Type.S) || t2.Equals(Type.A)) return true; break;
            case Type.C: if (t2.Equals(Type.S) || t2.Equals(Type.A) || t2.Equals(Type.B)) return true; break;
            case Type.D: if (t2.Equals(Type.S) || t2.Equals(Type.A) || t2.Equals(Type.B) || t2.Equals(Type.C)) return true; break;
        }
        return false;
    }
    void DataSave02()
    {
        if (File.Exists(Application.persistentDataPath + "/stg01cleardata.json"))//데이터가 있으면 
        {
            string namejson = Application.persistentDataPath + "/stg01cleardata.json";
            string json = "";
            using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/stg01cleardata.json"))//StreamReader읽기 전용
            {
                json = inStream.ReadToEnd();//ReadToEnd말고 다른 방법으로 읽는 방법 있음
            }
        }
        else //데이터 없으면 저장
        {
            ClearData data = new ClearData(_name, _hp, _stageClearData);
            datas.datas.Add(data);
            string json = JsonUtility.ToJson(datas);

            string path = Application.persistentDataPath + "/stg01cleardata.json";

            using (StreamWriter outStream = File.CreateText(path))
            {
                outStream.WriteLine(json);
            }
        }
    }
    void DataSave()
    {
        ClearData data = new ClearData(_name, _hp, _stageClearData);
        datas.datas.Add(data);
        string json = JsonUtility.ToJson(datas);

        string path = Application.persistentDataPath + "/stg01cleardata.json";

        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.WriteLine(json);
        }
    }
}
[Serializable]
public class ClearDataList
{
    public List<ClearData> datas;
}
[Serializable]
public class ClearData
{
    public Type _name;
    public int _hp;
    public int _stageClearData;

    public ClearData(Type name, int HP, int stageClearData)
    {
        _name = name;
        _hp = 3 - HP;
        _stageClearData = stageClearData;
    }
}
public enum Type
{
    S,
    A,
    B,
    C,
    D,
    F,
}
