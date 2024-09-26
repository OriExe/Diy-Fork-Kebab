using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int score = 0;
    [SerializeField] private TMP_Text text;
    private static TMP_Text textStatic;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        textStatic = text;
    }

    public static void increaseScore(int amount)
    {
        score+= amount;
        textStatic.text = score.ToString();
    }

    public static int returnScore()
    {
        return score;
    }
}
