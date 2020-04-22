using UnityEngine;

public class Open_Menu : MonoBehaviour
{
    [SerializeField] private GameObject hand = null;
    private Animator openMenuAnimation;
    private bool isTheMenuOpen = false;

    void Start()
    {
        // Getting the animator controller:
        openMenuAnimation = gameObject.GetComponent<Animator>();
    }

    /// <summary>
    /// The menu opens when the player looks at their lef hand in
    /// an specific rotation.   
    /// </summary>
    void Update()
    {
        // Opening Menu:
        if (hand.transform.eulerAngles.z > 45 && hand.transform.eulerAngles.z < 75 && isTheMenuOpen == false)
        {
            openMenuAnimation.SetBool("isOpening", true);
            openMenuAnimation.SetBool("isClosing", false);
            isTheMenuOpen = true;
        }
        // Closing Menu:
        else if ((hand.transform.eulerAngles.z < 45 || hand.transform.eulerAngles.z > 75) && isTheMenuOpen == true)
        {
            openMenuAnimation.SetBool("isOpening", false);
            openMenuAnimation.SetBool("isClosing", true);
            isTheMenuOpen = false;
        }
    }
}
