using UnityEngine;
using UnityEngine.InputSystem;

namespace Challenge3
{
  public class PlayerControllerX : MonoBehaviour
  {
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public InputAction floatAction;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    private void Awake()
    {
      playerRb = GetComponent<Rigidbody>();
    }

    void Start()
    {
      Physics.gravity *= gravityModifier;
      playerAudio = GetComponent<AudioSource>();
      floatAction.Enable();

      playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    void Update()
    {
      if (floatAction.IsPressed() && !gameOver)
      {
        playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
      }
    }

    private void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.CompareTag("Bomb"))
      {
        gameOver = true;
        var particle = Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        particle.Play();

        PlaySound(explodeSound);
        Destroy(other.gameObject);
        Destroy(gameObject);

        Debug.Log("Game Over!");
      }

      else if (other.gameObject.CompareTag("Money"))
      {
        fireworksParticle.Play();
        PlaySound(moneySound);
        Destroy(other.gameObject);
      }

      if (other.gameObject.CompareTag("Border") && !gameOver)
      {
        playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
      }
    }

    private void PlaySound(AudioClip clip)
    {
      if (playerAudio != null && clip != null)
      {
        playerAudio.PlayOneShot(clip, 1.0f);
      }
    }
  }
}