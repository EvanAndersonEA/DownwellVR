using UnityEngine;

public class Breakable_Floor : MonoBehaviour
{
    [SerializeField] private int numberOfHitsBeforeDestroyed = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            numberOfHitsBeforeDestroyed--;
            if (numberOfHitsBeforeDestroyed == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
