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
        Debug.Log($"�I��: {_shopItemGeneretor.ItemData[_selectIndex].name}");

    }
    public void BuyShopItems()
    {
        Instantiate(_shopItemGeneretor.ItemData[_selectIndex].ItemS);
        Debug.Log(_shopItemGeneretor.ItemData[_selectIndex].Name);

    }
    public void SelectButtonPlus()
    {
        _selectIndex++;

        // �͈͊O�ɂȂ�Ȃ��悤�ɂ�����xClamp�ň��S��
        _selectIndex = Mathf.Clamp(_selectIndex, 0, _shopItemGeneretor.ItemData.Length - 1);
        DebugSelectShopItem();



    }

    public void SelectButtonDelete()
    {
        _selectIndex--;

        // ���������S��
        _selectIndex = Mathf.Clamp(_selectIndex, 0, _shopItemGeneretor.ItemData.Length - 1);
        DebugSelectShopItem();
    }
    
}
