using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text _bestScore;

    void Start()
    {
        int loadScore = Save.GetScore();
        
        _bestScore.text = loadScore.ToString();
    }
}
