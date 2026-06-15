using UnityEngine;
using System.Collections;

namespace CourseLibraryPrototype4
{
  public class PlayerController : MonoBehaviour
  {
    [SerializeField] private float _speed = 500;
    [SerializeField] private int powerUpDuration = 5;
    [SerializeField] private bool _hasPowerup;
    [SerializeField] private float normalStrength = 10;
    [SerializeField] private float powerupStrength = 25;
    [SerializeField] GameObject powerupIndicator;

    private Rigidbody playerRb;
    private GameObject focalPoint;

    private void OnEnable()
    {
      Time.timeScale = 1;
    }
    private void Start()
    {
      playerRb = GetComponent<Rigidbody>();
      focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
      float verticalInput = Input.GetAxis("Vertical");
      playerRb.AddForce(focalPoint.transform.forward * verticalInput * _speed * Time.deltaTime);

      powerupIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("PowerUp"))
      {
        Destroy(other.gameObject);
        OnCollectPowerup();
      }

      if (other.gameObject.CompareTag("DestroyZone"))
      {
        gameObject.SetActive(false);
        Time.timeScale = 0;
        Debug.Log("Game Over!");
      }
    }

    private void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.CompareTag("Enemy"))
      {
        PerformForceAction(other.gameObject);
      }
    }

    public void ResetPosition()
    {
      transform.position = new Vector3(0, 1, -7);
      playerRb.linearVelocity = Vector3.zero;
      playerRb.angularVelocity = Vector3.zero;
    }

    public void PerformForceAction(GameObject enemy)
    {
      Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
      Vector3 awayFromPlayer = enemy.transform.position - transform.position;

      float strength = CalculateStrength();
      enemyRigidbody.AddForce(awayFromPlayer * strength, ForceMode.Impulse);
    }

    private float CalculateStrength()
    {
      return _hasPowerup ? powerupStrength : normalStrength;
    }

    private void OnCollectPowerup()
    {
      _hasPowerup = true;
      powerupIndicator.SetActive(true);
      StartCoroutine(PowerupCooldown());
    }

    private IEnumerator PowerupCooldown()
    {
      yield return new WaitForSeconds(powerUpDuration);
      _hasPowerup = false;
      powerupIndicator.SetActive(false);
    }
  }
}