using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerScrpt : MonoBehaviour
{
    public SpikeScript _spikeScript { get; private set; }
    public SpikeGenerator spikeGenerator;
    private Rigidbody2D prb;
    private Animator anim;
    //private Vector2 _direction = Vector2.right;
    float score;
    float scoretime;
    public Text ScoreTxt;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 13f;

    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isAlive = true;
    private enum MovementState {running,jumping,falling}
    MovementState state = MovementState.running;


    private void Awake()
    {
        prb = GetComponent<Rigidbody2D>(); //player ridgidbody
        score = 0;
        anim = GetComponent<Animator>();


    }


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //float dirX = Input.GetAxisRaw("Horizontal");
        //prb.velocity = new Vector2(dirX * moveSpeed, prb.velocity.y);

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
            scoretime = (spikeGenerator.CurrentSpeed - spikeGenerator.MinSpeed) / spikeGenerator.SpeedMultiplier;
            score = Mathf.MoveTowards(score, 1.0f,spikeGenerator.CurrentSpeed/450000);
            int scoreToDisplay = (int)Mathf.Lerp(0, 9999f, score);
            ScoreTxt.text = "Score: " + scoreToDisplay.ToString();
            GameData.Instance.Score = scoreToDisplay;
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

        if (collision.gameObject.CompareTag("spike") || collision.gameObject.CompareTag("ship"))
        {
            isAlive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        
    }
 


}
