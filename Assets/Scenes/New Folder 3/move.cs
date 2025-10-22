using UnityEngine;

public class move : MonoBehaviour
{
    private Vector3 currentPosition = new Vector3(0, 0.5f, 0);
    private Vector3 Velocity;
    private float _speed = 0.1f;
    private Transform _transform;
    [SerializeField] private input _input;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _transform.position = currentPosition;
        _input.OnMove += Input;
    }

    private void Input(Vector2 input) => Velocity = new Vector3(input.x / 10, 0, input.y / 10);


    // Update is called once per frame
    void Update()
    {
        float fInputVel = Mathf.Sqrt(Velocity.x * Velocity.x + Velocity.z * Velocity.z);
        if (fInputVel > _speed)
        {
            Velocity = Velocity / fInputVel * _speed;
        }

        currentPosition += Velocity;
        CheckWall();
        _transform.position = currentPosition;
    }

    private void CheckWall()
    {
        if (currentPosition.x > 5f)
        {
            currentPosition.x = 5f;
            Velocity.x = -Velocity.x;
        }

        if (currentPosition.x < -5f)
        {
            currentPosition.x = -5f;
            Velocity.x = -Velocity.x;
        }

        if (currentPosition.z > 5f)
        {
            currentPosition.z = 5f;
            Velocity.z = -Velocity.z;
        }

        if (currentPosition.z < -5f)
        {
            currentPosition.z = -5f;
            Velocity.z = -Velocity.z;
        }
    }
}