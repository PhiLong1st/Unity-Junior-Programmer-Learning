using UnityEngine;

namespace CourseLibraryPrototype2
{
    public class MoveForward : MonoBehaviour
    {
        public float speed = 5f;

        void Update()
        {
            var newPosition = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + speed * Time.deltaTime
            );
            transform.position = newPosition;
        }
    }
}