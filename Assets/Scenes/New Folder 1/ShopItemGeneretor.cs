using System;
using UnityEngine;
using TMPro;

public class ShopItemGeneretor : MonoBehaviour
{
    [SerializeField] private Item[] _itemdata;

    private void Start()
    {
        GameObject textobj = new GameObject("mytext");
        textobj.transform.SetParent(transform,false);
       
        TextMeshProUGUI textmesh = textobj.AddComponent<TextMeshProUGUI>();
        textmesh.text = _itemdata[0].Name;
        textmesh.fontSize = 50;
        textmesh.color = Color.cyan;
        
        RectTransform rect = textobj.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, 300);
        rect.localScale = Vector3.one;



    }
}
