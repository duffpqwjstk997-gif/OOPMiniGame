using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    Direction _direction;
    public InputActionReference MoveKey;
    Rigidbody2D rb;
    public Vector2 moveDir = Vector2.right;
    public Vector2 EmoveDir = Vector2.right;
    public float MoveSpeed = 10f;
    public bool isPlayer = false;
    public bool isMoving = true;
    public GameObject Target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        if (MoveKey != null && isPlayer)
        {
            MoveKey.action.Enable();
            MoveKey.action.performed += ReverseDirection;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveKey != null && isPlayer)
        {
            _direction = new Direction(this.moveDir,Vector2.zero);
        }
        else if (!isPlayer)
        {
            Vector2 target = Player.instance.transform.position;
            _direction = new Direction(target,transform.position);
            this.EmoveDir = _direction.KeepdirX;
        }
    }
    private void FixedUpdate()
    {
        if (_direction != null && isMoving)
        {
            rb.linearVelocity = (_direction.KeepdirX * MoveSpeed * Time.deltaTime);
        } 
    }
    private void ReverseDirection(InputAction.CallbackContext context)
    {
        this.moveDir = -moveDir;
    }
    public void StopMove()
    {
        MoveSpeed = 0f;
        isMoving = false;
    }

}
