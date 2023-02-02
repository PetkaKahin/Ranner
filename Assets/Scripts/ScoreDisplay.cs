using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        Score.ChangeScore += TextUpdate;
    }

    private void OnDisable()
    {
        Score.ChangeScore -= TextUpdate;
    }

    public void TextUpdate(int amount)
    {
        _text.text = $"{amount}";
    }
}
