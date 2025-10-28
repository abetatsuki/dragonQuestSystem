using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "New Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _item;
    public GameObject ItemS => _item;
    public string Name => _name;
    public int Price => _price;
}
