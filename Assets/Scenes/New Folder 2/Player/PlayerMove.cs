
using UnityEngine;
/// <summary>
/// �v���C���[�̓������Ǘ�����N���X
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private InputBuffer _inputBuffer;
    [SerializeField] private PlayerManager _playerManager;
    private int _currentspeed;
    private Vector3 _currentPotion;
    
    private Transform _transoform;

    private void OnEnable()
    {
        _inputBuffer.OnMove += Input;
    }
    public void OnDisable()
    {
        _inputBuffer.OnMove -= Input;
    }


    private void Start()
    {
        _transoform = GetComponent<Transform>();
        _currentspeed = _playerManager.CurrentStatus.Speed;
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// �o�b�t�@�[�N���X������͂��󂯎��
    /// </summary>
    /// <param name="input"></param>
    public void Input(Vector2 input)
    {
        _currentPotion = new Vector3(input.x,0,input.y);
       
    }
    /// <summary>
    /// �����̎��̂�����
    /// </summary>
    public void Move()
    {
        _transoform.position += _currentPotion * _currentspeed * Time.deltaTime ;
    }
}
