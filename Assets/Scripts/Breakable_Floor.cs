using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
