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


    GameManager gameManager;
    UIController uIController;

    [SerializeField] AudioSource throwSound;

    [SerializeField] BallType ballType = null;

    private void Awake()
    {
        ballRb = GetComponent<Rigidbody>();
        ballLine = GetComponent<LineRenderer>();
    }

    void Start()
    {

        ScriptableObjects();

        ballStartPos = transform.position;
        ballRb.isKinematic = true;
        mainCamera = Camera.main;
        isThrow = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIController = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    void Update()
    {
        if (uIController.isStart)
        {
            TouchInput();
            if (!isThrow)
            {
                MouseInput();
            }
        }

    }

    void ScriptableObjects()
    {
        throwSpeed = ballType.throwPower;
        transform.localScale = ballType.ballScale;
    }

    void TouchInput()
    {
        if (Input.touchCount > 0 && !isThrow)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                mousePos = touch.position;
                mousePos.z = 5f;
                startTouchPosition = mainCamera.ScreenToWorldPoint(mousePos);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                mousePos = touch.position;
                mousePos.z = 5f;
                Vector3 dragPosition = mainCamera.ScreenToWorldPoint(mousePos);
                throwDirection = startTouchPosition - dragPosition;

                ballLine.positionCount = 2;
                ballLine.SetPosition(0, transform.position);

                Vector3 lineEndPos = transform.position + throwDirection;

                ballLine.SetPosition(1, lineEndPos);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                ballLine.positionCount = 0;
                mousePos = touch.position;
                mousePos.z = 5f;
                ballRb.isKinematic = false;
                endTouchPosition = mainCamera.ScreenToWorldPoint(mousePos);

                throwDirection = startTouchPosition - endTouchPosition;

                ThrowBall();
            }
        }
    }

    void MouseInput()
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

            Vector3 lineEndPos = transform.position + throwDirection;
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


            ThrowBall();

        }
    }

    public void ThrowBall()
    {
        GetComponent<Animator>().SetBool("isThrow", true);
        throwSound.Play();
        isThrow = true;
        ballRb.AddForce(new Vector3(throwDirection.y * throwSpeed / 2, throwDirection.y * throwSpeed, throwDirection.z * throwSpeed), ForceMode.Impulse);
    }

}
