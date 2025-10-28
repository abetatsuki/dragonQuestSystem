using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ShopItemGeneretor : MonoBehaviour
{
    [SerializeField] private Item[] _itemdata;
    private List<GameObject> _itemGameobjData = new List<GameObject>();
    public Item[] ItemData => _itemdata;
    public List<GameObject> ItemsObj => _itemGameobjData;
    
    private List<TextMeshProUGUI> _textMesh = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> TextMeshProUGUIs => _textMesh;

    public void ChangeColor(int selectnumber)
    {
        _textMesh[selectnumber].color = Color.red;
        if(selectnumber >= 1)
        _textMesh[selectnumber-1].color = Color.cyan;
        if(selectnumber < _textMesh.Count -1)
        _textMesh[selectnumber+1].color = Color.cyan;
        

    }
 
    private void Start()
    {
        for (int i = 0; i < _itemdata.Length; i++)
        {


            GameObject textobj = new GameObject("mytext");
            textobj.transform.SetParent(transform, false);

            TextMeshProUGUI textmesh = textobj.AddComponent<TextMeshProUGUI>();
            textmesh.text = _itemdata[i].Name;
            textmesh.fontSize = 50;
            textmesh.color = Color.cyan;

            RectTransform rect = textobj.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0, 500 - 100*i);
            rect.localScale = Vector3.one;
            _itemGameobjData.Add(textobj);
            _textMesh.Add(textmesh);

        }

    }
}
