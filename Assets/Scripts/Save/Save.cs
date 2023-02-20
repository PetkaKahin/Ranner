using UnityEngine;

public class Save : MonoBehaviour
{
    public static void SaveScore(int score)
    {
        if (PlayerPrefs.GetInt("Score") < score)
            PlayerPrefs.SetInt("Score", Score.ScoreCount);
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt("Score");
    }
}
