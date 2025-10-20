using UnityEngine;
/// <summary>
/// �v���C���[�̋������Ǘ�����N���X
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public  PlayerStatus CurrentStatus => _currentStatus;
    private PlayerStatus _currentStatus;
    private int _level;
    private PlayerData _data;

    private void Start()
    {
        _data = GetComponent<PlayerData>();
    }
    public void LevelUp()
    {
        _level++;
        _currentStatus = _data[_level];
    }
}
