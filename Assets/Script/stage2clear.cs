using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class stage2clear : MonoBehaviour
{
    [SerializeField] GameObject _gamecleartext;
    [SerializeField] GameObject _gameTimecleartext02;
    [SerializeField] GameObject _baseboard;
    [SerializeField] GameObject _hpScore;
    [SerializeField] GameObject player;
    [SerializeField] GameObject _okButton;
    [SerializeField] Type _name;

    ClearDataList datas;

    int _hp;
    int _stageClearData = 1;

    bool datasave = false;
    private void Start() //1스테이지에서 정보 불러오기
    {
        datas = new ClearDataList();
        datas.datas = new List<ClearData>();
        dataRead();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DataSave();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("충돌");
            _hp = player.GetComponent<Player_Controller02>().GetClearDataHp();
            Debug.Log("hp = " + _hp);
            // if (collision.collider.CompareTag("Player"))
            // {
            _gamecleartext.SetActive(true);
            // _gameTimecleartext.SetActive(true);
            _gameTimecleartext02.SetActive(true);
            _baseboard.SetActive(true);
            _hpScore.SetActive(true);
            _okButton.SetActive(true);
            //GetComponent<Timescore>().enabled = true; *******************
            datasave = true;
            DataSave();
        }
    }
    void DataSave()
    {
        ClearData data = new ClearData(_name, _hp, _stageClearData);
        datas.datas.Add(data);
        string json = JsonUtility.ToJson(datas);

        string path = Application.persistentDataPath + "/stg02cleardata.json";

        using (StreamWriter outStream = File.CreateText(path))
        {
            outStream.WriteLine(json);
        }
    }
    void dataRead()
    {
        if (File.Exists(Application.persistentDataPath + "/stg01cleardata.json"))//데이터가 있으면 
        {
            string json = "";
            using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/stg01cleardata.json"))
            {
                json = inStream.ReadToEnd();
            }
            if (string.IsNullOrEmpty(json) == false)
            {
                datas = JsonUtility.FromJson<ClearDataList>(json);//불러옴
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
}
