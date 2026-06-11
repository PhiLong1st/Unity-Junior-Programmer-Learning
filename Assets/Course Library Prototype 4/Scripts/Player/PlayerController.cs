using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace CourseLibraryPrototype4
{
  public class PlayerController : MonoBehaviour
  {
    public float playerSpeed = 150f;
    public GameObject powerupIndicator;

    private InputSystem_Actions controls;
    private Rigidbody playerRb;
    private GameObject focalPoint;

    private bool _hasPowerUp;
    private float _powerUpStrength = 15f;


    private float _debugTimer = 0f;
    private int _order = 0;

    void Awake()
    {
      controls = new InputSystem_Actions();
      playerRb = GetComponent<Rigidbody>();
      focalPoint = GameObject.Find("Focal Point");
    }

    private void Start()
    {
      _hasPowerUp = false;

    }

    void OnEnable()
    {
      controls.Player.Enable();
    }

    void Update()
    {
      Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
      float forwardInput = moveInput.y;

      playerRb.AddForce(focalPoint.transform.forward * forwardInput * playerSpeed * Time.deltaTime);

      powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {

      if (other.CompareTag("PowerUp"))
      {
        _hasPowerUp = true;
        Destroy(other.gameObject);

        StartCoroutine(DebugTimerRoutine());
        powerupIndicator.gameObject.SetActive(true);
      }
    }

    private IEnumerator DebugTimerRoutine()
    {
      while (_debugTimer < 7f)
      {
        _debugTimer += Time.deltaTime;
        yield return null;
      }

      _hasPowerUp = false;
      powerupIndicator.gameObject.SetActive(false);
    }

    private IEnumerator PowerUpCountdownRoutine()
    {
      yield return new WaitForSeconds(7);

      _hasPowerUp = false;
      powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {

      if (collision.gameObject.CompareTag("Enemy") && _hasPowerUp)
      {
        var enemyRb = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = enemyRb.transform.position - transform.position;

        enemyRb.AddForce(awayFromPlayer.normalized * _powerUpStrength, ForceMode.Impulse);
      }
    }
  }
}