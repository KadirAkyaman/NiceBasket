using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeController : MonoBehaviour
{
    Vector3 startTouchPosition;
    Vector3 endTouchPosition;
    Vector3 mousePos;
    Vector3 throwDirection;
    [SerializeField] float throwSpeed;

    Vector3 ballStartPos;

    Rigidbody ballRb;
    LineRenderer ballLine;

    Camera mainCamera;

    public bool isThrow;
    public bool isTouchDevice;

    private void Awake()
    {
        ballRb = GetComponent<Rigidbody>();
        ballLine = GetComponent<LineRenderer>();
    }

    void Start()
    {
        ballStartPos = transform.position;
        ballRb.isKinematic = true;
        mainCamera = Camera.main;
        isThrow = false;
        isTouchDevice = IsTouchDevice();
    }

    void Update()
    {
        if (!isThrow)
        {
            if (isTouchDevice)
            {
                HandleTouchInput();
            }
            else
            {
                HandleMouseInput();
            }
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;

                    if (endTouchPosition.y > startTouchPosition.y)
                    {
                        ThrowBall();
                    }
                    break;
            }
        }
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            startTouchPosition = mainCamera.ScreenToWorldPoint(mousePos);
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            Vector3 dragPosition = mainCamera.ScreenToWorldPoint(mousePos);
            throwDirection = startTouchPosition - dragPosition;

            ballLine.positionCount = 2;
            ballLine.SetPosition(0, transform.position);

            Vector3 lineEndPos = transform.position + throwDirection.normalized * throwDirection.y;
            ballLine.SetPosition(1, lineEndPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            ballLine.positionCount = 0;
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            ballRb.isKinematic = false;
            endTouchPosition = mainCamera.ScreenToWorldPoint(mousePos);

            throwDirection = startTouchPosition - endTouchPosition;

            if (throwDirection.y > 0)
            {
                ThrowBall();
            }
        }
    }

    public void ThrowBall()
    {
        isThrow = true;
        ballRb.AddForce(new Vector3(throwDirection.y * throwSpeed / 2, throwDirection.y * throwSpeed, throwDirection.z * throwSpeed), ForceMode.Impulse);
    }

    public bool IsTouchDevice()
    {
        return SystemInfo.deviceType == DeviceType.Handheld;
    }

}
