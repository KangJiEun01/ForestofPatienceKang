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
//                datas = JsonUtility.FromJson<ItemDataList>(json);//�������� ����
//                SpwanItems();
//            }
//            else
//            {
//                Debug.Log("������ �����ϴ�.");
//            }
//        }
//        else
//        {
//            Debug.Log("������ �����ϴ�.");
//        }
//    }
//    void SpwanItems()
//    {
//        foreach (var data in datas.datas) //���� ������ �ϳ��� �ҷ��ͼ� ����
//        {
//            foreach (var item in items) // ������ ���� ť�� �Ǵ� ���Ǿ�
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
