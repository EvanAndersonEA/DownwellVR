using UnityEngine;

public class Kill_Enemy : MonoBehaviour
{
    [SerializeField] private int numberOfHitsBeforeDestroyed = 3;
    [SerializeField] private Lives_Score_Handler score_Handler = null;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            numberOfHitsBeforeDestroyed--;
            if (numberOfHitsBeforeDestroyed == 0)
            {
                score_Handler.score += 1000;
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
