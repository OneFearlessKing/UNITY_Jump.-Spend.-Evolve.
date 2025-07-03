using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip pointSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float jumpForce = 10.0f;
    public float gravityModifier = 1.5f;
    public bool isOnGround = true;
    public bool gameOver = true;
    public bool end = false;


    public void StartRunning()
    {
        gameOver = false;
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerRb.freezeRotation = true;
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
        //fresh after reloading scene
        isOnGround = true;
        gameOver = true;
        end = false;
    }

    void Update()
    {
        // Only allow jump if game is not over
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(pointSound, 1.0f);
        }
        if (gameOver)
        {
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            end = true;
        }
    }
}   