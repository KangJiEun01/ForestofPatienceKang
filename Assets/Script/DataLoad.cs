//using System.IO;
//using UnityEngine;
//using static UnityEditor.Progress;

//public class ItemSpawner : Genericsingleton<ItemSpawner>
//{
//    [SerializeField] GameObject[] items;
//    Transform[] _points;

//    ItemDataList datas;
//    public void Init(Transform[] points)
//    {
//        datas = new ItemDataList();
//        _points = points;
//        dataRead();
//    }
//    void dataRead()
//    {
//        if (File.Exists(Application.persistentDataPath + "/itemdata.json"))
//        {
//            string json = "";
//            using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/itemdata.json"))
//            {
//                json = inStream.ReadToEnd();
//            }
//            if (string.IsNullOrEmpty(json) == false)
//            {
//                datas = JsonUtility.FromJson<ItemDataList>(json);//아이템을 스폰
//                SpwanItems();
//            }
//            else
//            {
//                Debug.Log("내용이 없습니다.");
//            }
//        }
//        else
//        {
//            Debug.Log("파일이 없습니다.");
//        }
//    }
//    void SpwanItems()
//    {
//        foreach (var data in datas.datas) //개별 아이템 하나씩 불러와서 생성
//        {
//            foreach (var item in items) // 프리팹 정보 큐브 또는 스피어
//            {
//                if (data._type == item.GetComponent<Item>().Type)
//                {
//                    GameObject temp = Instantiate(item);
//                    temp.GetComponent<Item>().Init(data);
//                    temp.transform.position = _points[Random.Range(0, _points.Length)].transform.position;
//                    break;
//                }
//            }
//        }
//    }
//}
