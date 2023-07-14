using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerScrpt : MonoBehaviour
{
    public MoveableSpike _spikeScript { get; private set; }
    public SpikeGenerator spikeGenerator;
    private Rigidbody2D prb;
    private Animator anim;
    private Score_manager scoreManager;
    float score;


    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 13f;

    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isAlive = true;
    private enum MovementState {running,jumping,falling}
    MovementState state = MovementState.running;


    private void Awake()
    {
        prb = GetComponent<Rigidbody2D>(); //player ridgidbody
        anim = GetComponent<Animator>();
        scoreManager = Score_manager.Instance;
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded == true)
            {
                prb.velocity = new Vector2(prb.velocity.x, jumpForce);
                isGrounded = false;
            }
        }
        else if (Input.GetKeyDown("r"))
        {
            ResetState();
        }     
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            score = Mathf.MoveTowards(score, 1.0f, spikeGenerator.CurrentSpeed / 450000);
            int scoreToDisplay = (int)Mathf.Lerp(0, 9999f, score);
            scoreManager.AddScore(scoreToDisplay);
        }

        UpdateAnimationState();
    }

    private void ResetState()
    {
        this.transform.position = Vector3.zero;
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if(prb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (prb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        else
        {
            state = MovementState.running;
        }
        anim.SetInteger("state", (int)state);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.TryGetComponent(out ObstaclesClass obstacles))
        {
            isAlive = false;
            SceneManager.LoadScene("Scenes/EndScreen");
        } 
    }
}
