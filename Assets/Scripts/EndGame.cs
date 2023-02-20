using System.Collections;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] private CanvasGroup _endDisplay;

    [SerializeField] private GameObject _canvasGame;
    [SerializeField] private GameObject _canvasEndGame;

    [SerializeField] private TMP_Text _score;
    [SerializeField] private float _SpeedAnimationSecond;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        Player.Died += PauseEndGame;
    }

    private void OnDisable()
    {
        Player.Died -= PauseEndGame;
    }

    private void PauseEndGame()
    {
        _score.text = Score.ScoreCount.ToString();

        _canvasGame.SetActive(false);
        _canvasEndGame.SetActive(true);

        StartCoroutine(PauseAnimation(_SpeedAnimationSecond));
    }

    private IEnumerator PauseAnimation(float speed)
    {
        float speedAnimation = Time.unscaledDeltaTime / speed * LetMover.Speed;

        while (Time.timeScale - speedAnimation >= 0)
        {
            speedAnimation = Time.unscaledDeltaTime / speed * LetMover.Speed;

            Time.timeScale -= speedAnimation;
            _endDisplay.alpha += speedAnimation;

            yield return new WaitForSeconds(Time.unscaledDeltaTime);
        }

        Time.timeScale = 0;
    }
}
