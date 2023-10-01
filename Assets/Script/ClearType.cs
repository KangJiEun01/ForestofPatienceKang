using UnityEngine;

public class ClearType : MonoBehaviour
{
    [SerializeField] ClearDataList type;
    public ClearDataList Type { get { return type; } }
    ClearDataList _itemData;
    public ClearDataList itemData { get { return _itemData; } }
    public void Init(ClearDataList data)
    {
        _itemData = data;
        gameObject.name = _itemData.GetType().Name;
        //GetComponent<Renderer>().material.SetColor("_Color", _itemData._color);
        //gameObject.name = _itemData._name;
        //transform.localScale = Vector3.one * _itemData._scale;
    }
    public ClearDataList getitem()
    {
        Destroy(gameObject);
        return _itemData;
    }
}
