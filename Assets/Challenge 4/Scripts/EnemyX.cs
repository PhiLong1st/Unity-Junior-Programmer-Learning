using UnityEngine;

namespace Challenge4
{
  public class EnemyX : MonoBehaviour
  {
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;


    private void Awake()
    {
      playerGoal = GameObject.Find("Player Goal");
    }

    private void Start()
    {
      enemyRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
      enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
      // If enemy collides with either goal, destroy it
      if (other.gameObject.name == "Enemy Goal")
      {
        Destroy(gameObject);
      }
      else if (other.gameObject.name == "Player Goal")
      {
        Destroy(gameObject);
      }
    }
  }
}