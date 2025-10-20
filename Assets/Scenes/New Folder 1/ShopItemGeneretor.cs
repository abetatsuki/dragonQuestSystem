using System;
using UnityEngine;
using TMPro;

public class ShopItemGeneretor : MonoBehaviour
{
    [SerializeField] private Item[] _itemdata;
    [SerializeField] private Vector2 startPosition = new Vector2(0, 300);
    [SerializeField] private float verticalSpacing = 100f;
    [SerializeField] private float arrowOffsetX = 200f;
    private GameObject[] _itemText;
    private RectTransform _arrowRect; // 矢印のRectTransform参照
    private int _selectedIndex = 0;

    private void Start()
    {
        _itemText = new GameObject[_itemdata.Length];
        for (int i = 0; i < _itemdata.Length; i++)
        {
            GeneretTestBox(i);
            
        }
        
    


    }

    public void GeneretTestBox(int length)
    {
        //テキストボックス
        GameObject textobj = new GameObject($"text{length}");
        textobj.transform.SetParent(transform,false);
       
        TextMeshProUGUI textmesh = textobj.AddComponent<TextMeshProUGUI>();
        textmesh.text = _itemdata[0].Name;
        textmesh.fontSize = 50;
        textmesh.color = Color.cyan;
        
        RectTransform rect = textobj.GetComponent<RectTransform>();
        rect.anchoredPosition = startPosition + Vector2.down *verticalSpacing *length;
        rect.localScale = Vector3.one;
        
        _itemText[length] = textobj;
        

    }

    
}
