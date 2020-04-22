using UnityEngine;

public class Camera_Collider : MonoBehaviour
{
    public Transform cameraRig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<CapsuleCollider>().center = new Vector3(cameraRig.position.x, 0.0f, cameraRig.position.z);
    }
}
