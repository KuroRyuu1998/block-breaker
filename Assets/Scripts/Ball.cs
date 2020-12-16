using UnityEngine;

public class Ball : MonoBehaviour
{
    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f, yPush = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;


    //state
    Vector2 paddleToBallDistance;
    bool hasStarted = false;

    //cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    void Start()
    {
        paddleToBallDistance = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LauchOnClick();
        }

    }

    private void LauchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallDistance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Vector2 velocityTweak = new Vector2(Random.Range(0.2f, randomFactor),Random.Range(0.2f, randomFactor));


        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity -= velocityTweak;
        }

    }
}
