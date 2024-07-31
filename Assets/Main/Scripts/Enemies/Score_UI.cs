using TMPro;
using UnityEngine;

public class Score_UI : MonoBehaviour
{
    private TMP_Text ScoreText;
    private ScoreController ScoreController;

    private void Awake()
    {
        ScoreText = GetComponent<TMP_Text>();
    }

    public void UpdateScore()
    {
        ScoreText.text = $"Zombie Killed :{ScoreController.score}";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            UpdateScore();
        }
    }

   
}
