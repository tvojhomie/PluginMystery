using UnityEngine;

public class Robby : MonoBehaviour
{
    public static Robby instance;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float JumpForce;
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] Camera playerCamera;
    [SerializeField] Animator Anim;

    private Rigidbody rb;
    private bool _onGround;

    [SerializeField] VariableJoystick JS;
    float moveHorizontal;
    float moveVertical;

    private bool isMobileDevice = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isMobileDevice = Application.isMobilePlatform;

        if (isMobileDevice)
        {
            JS.gameObject.SetActive(true);
        }
        else
        {
            JS.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!isMobileDevice)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = JS.Horizontal;
            moveVertical = JS.Vertical;
        }

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Anim.SetBool("Run", true);
        }
        else
        {
            Anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = forward * moveVertical + right * moveHorizontal;

        if (desiredMoveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(desiredMoveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (transform.position.y < -10f)
        {
            Respawn();
        }
    }

    public void Jump()
    {
        if (_onGround)
        {
            rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
        }
    }

    private void Respawn()
    {
        transform.position = new Vector3(0, 1, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _onGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _onGround = false;
    }
}
