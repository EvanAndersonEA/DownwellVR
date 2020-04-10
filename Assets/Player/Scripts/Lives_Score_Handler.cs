using TMPro;
using UnityEngine;

public class Lives_Score_Handler : MonoBehaviour
{
    [SerializeField] private GameObject life_1 = null;
    [SerializeField] private GameObject life_2 = null;
    [SerializeField] private GameObject life_3 = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;

    [HideInInspector] public int score;

    // Update is called once per frame
    private void FixedUpdate()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateLives(int lives)
    {
        switch (lives)
        {
            case 3:
                life_1.SetActive(true);
                life_2.SetActive(true);
                life_3.SetActive(true);
                break;
            case 2:
                life_1.SetActive(true);
                life_2.SetActive(true);
                life_3.SetActive(false);
                break;
            case 1:
                life_1.SetActive(true);
                life_2.SetActive(false);
                life_3.SetActive(false);
                break;
            default:
                life_1.SetActive(false);
                life_2.SetActive(false);
                life_3.SetActive(false);
                break;
        }
    }
}