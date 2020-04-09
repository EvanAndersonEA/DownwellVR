using UnityEngine;

public class Player_Actions : MonoBehaviour
{
    [HideInInspector] public int player_Lifes = 3;
    private float impulse = 500.0f;
    public Rigidbody rb;

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Danger_Collider")
        {
            player_Lifes--;
            Destroy(collision.transform.parent.gameObject);
        }

        if (collision.gameObject.tag == "Bouncing_Collider")
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * impulse);
            Destroy(collision.transform.parent.gameObject);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Danger_Collider")
        {
            player_Lifes--;
            Destroy(other.transform.parent.gameObject);
        }

        if (other.gameObject.tag == "Bouncing_Collider")
        {
            rb.AddRelativeForce(Vector3.up * impulse);
            Destroy(other.transform.parent.gameObject);
        }
    }
}
