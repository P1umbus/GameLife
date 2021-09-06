using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _quad;

    [SerializeField] private float _speed;

    [SerializeField] private float _maxSize = 5;
    [SerializeField] private float _minSize = 0.1f;

    private float _horizontalLimit;
    private float _verticalLimit;


    private void Awake()
    {
        if (_maxSize == 0)
            _maxSize = 5;
        if (_minSize == 0)
            _minSize = 0.1f;

        CreateLimits();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            Move();

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            ChangeSize();                
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;

        float verticalMove = Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime;

        Vector3 move = new Vector3(horizontalMove, verticalMove);
        
        transform.Translate(move);

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, -_horizontalLimit,_horizontalLimit),
            Mathf.Clamp(transform.position.y, -_verticalLimit, _verticalLimit),
            transform.position.z
            );
    }

    private void CreateLimits()
    {
        float size = Camera.main.orthographicSize;

        _verticalLimit = (_maxSize - size) * (_quad.localScale.y / 10);
        _horizontalLimit = (_maxSize - size) * (_quad.localScale.x / 10);

        Move();
    }

    private void ChangeSize()
    {
        Camera.main.orthographicSize += -Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, _minSize, _maxSize);

        CreateLimits();
    }
}
