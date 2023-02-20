using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimationsBooster : MonoBehaviour
{
    [SerializeField] Image _boostFrame;
    [SerializeField] float _speedStartAnimation;
    [SerializeField] float _delayAnimation;
    [SerializeField] float _SpeedEndAnimation;

    public void StartAnimation()
    {
        StartCoroutine(ActivateEffect());
    }

    private IEnumerator ActivateEffect()
    {
        while (_boostFrame.color.a <= 1)
        {
            float speed = _speedStartAnimation * Time.deltaTime;
            _boostFrame.color += new Color(0f, 0f, 0f, speed);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return new WaitForSeconds(_delayAnimation);

        while (_boostFrame.color.a >= 0)
        {
            float speed = _SpeedEndAnimation * Time.deltaTime;
            _boostFrame.color -= new Color(0f, 0f, 0f, speed);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
