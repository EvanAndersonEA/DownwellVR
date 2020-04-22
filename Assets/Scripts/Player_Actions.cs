using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Player_Actions : MonoBehaviour
{
    [SerializeField] private SteamVR_ActionSet m_ActionSet = null;
    [SerializeField] private SteamVR_Action_Boolean m_BooleanAction;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private GameObject vrCamera = null;
    [SerializeField] private Rigidbody body = null;
    [HideInInspector] public int player_Lifes = 3;
    private AudioSource shotSound = null;
    private int amountOfBullets = 8;

    private void Awake()
    {
        m_BooleanAction = SteamVR_Actions.default_GrabPinch;
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);

        // Getting the shot gun sound:
        shotSound = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        #region Shooting:
        if (m_BooleanAction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            // Checking if the player can keep shooting:
            if (amountOfBullets > 0)
            {
                SpawnBullet(bullet, vrCamera);
                shotSound.Play();
                amountOfBullets--;
            }
        }
            
        gameObject.GetComponent<CapsuleCollider>().center = new Vector3(vrCamera.transform.position.x, 1, vrCamera.transform.position.z);
        #endregion

        #region Update mesh and collider position:
        // Mesh position:
        Vector3 targetPosition = vrCamera.transform.localPosition;
        targetPosition.y = 1;
        transform.localPosition = targetPosition;

        // Collider position:
        gameObject.GetComponent<CapsuleCollider>().center = new Vector3(0.0f, 0.0f, 0.0f);
        #endregion


    }

    /// <summary>
    /// - Reset amount of bullets:
    ///     Some colliders can reset the amount of bullets in game.
    /// - Collide with enemy:
    ///     Depending on the collider the player loses a life or kills 
    ///     the enemy by bouncing on it.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        //Reset amount of bullets:
        if (tag == "Breakable Floor" || tag == "Bouncing_Collider" || tag == "Floor")
        {
            amountOfBullets = 8;
        }

        // Collide with enemies:
        if (tag == "Danger_Collider")
        {
            player_Lifes--;
            Destroy(other.transform.parent.gameObject);
            if (player_Lifes == 0)
            {
                SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
            }
        }

        if (tag == "Bouncing_Collider")
        {
            body.AddRelativeForce(Vector3.up * 500.0f);
            Destroy(other.transform.parent.gameObject);
        }
    }

    /// <summary>
    /// Instantiate a new bullet prefab and add force to the player
    /// to simulate bounce.
    /// </summary>
    private void SpawnBullet(GameObject bullet, GameObject player)
    {
        GameObject newBullet = Instantiate(bullet, player.transform.position - new Vector3(0, 1f, 0), Quaternion.identity);
        body.velocity = new Vector3(0, 1, 0);
        newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0, -25, 0);
    }
}
