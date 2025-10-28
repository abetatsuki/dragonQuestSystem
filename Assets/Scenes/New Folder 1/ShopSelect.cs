using UnityEngine;
using TMPro;

public class ShopSelect : MonoBehaviour
{
    private ShopItemGeneretor _shopItemGeneretor;
    [SerializeField] private int _selectIndex = 0;
   
    void Start()
    {
        _shopItemGeneretor = GetComponent<ShopItemGeneretor>();
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            BuyShopItems();

        }
        _shopItemGeneretor.ChangeColor(_selectIndex);
    }
    public void DebugSelectShopItem()
    {
        Debug.Log($"選択中: {_shopItemGeneretor.ItemData[_selectIndex].name}");

    }
    public void BuyShopItems()
    {
        Instantiate(_shopItemGeneretor.ItemData[_selectIndex].ItemS);
        Debug.Log(_shopItemGeneretor.ItemData[_selectIndex].Name);

    }
    public void SelectButtonPlus()
    {
        _selectIndex++;

        // 範囲外にならないようにもう一度Clampで安全化
        _selectIndex = Mathf.Clamp(_selectIndex, 0, _shopItemGeneretor.ItemData.Length - 1);
        DebugSelectShopItem();



    }

    public void SelectButtonDelete()
    {
        _selectIndex--;

        // 下限も安全化
        _selectIndex = Mathf.Clamp(_selectIndex, 0, _shopItemGeneretor.ItemData.Length - 1);
        DebugSelectShopItem();
    }
    
}
