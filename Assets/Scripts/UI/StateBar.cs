using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StateBar : MonoBehaviour
{
    [SerializeField] Image bottom;
    [SerializeField] Image top;

    [SerializeField] float increaseDuration = 0.25f;
    [SerializeField] float decreaseDuration = 0.25f;

    float currentAmount;
    float targetAmount;

    public void InitBar(int value, int maxValue)
    {
        currentAmount = 1.00f * value / maxValue;
        bottom.fillAmount = currentAmount;
        top.fillAmount = currentAmount;
    }

    public void UpdateBar(int value, int maxValue)
    {
        targetAmount = 1.00f * value / maxValue;
        if (targetAmount > currentAmount)
            StartCoroutine(IncreaseCoroutine());
        else
            StartCoroutine(DecreaseCoroutine());
    }

    IEnumerator IncreaseCoroutine()
    {
        bottom.fillAmount = targetAmount;
        float timer = 0;
        while (timer < increaseDuration)
        {
            timer += Time.deltaTime;
            top.fillAmount = Mathf.Lerp(currentAmount, targetAmount, timer / increaseDuration);
            yield return null;
        }
        currentAmount = targetAmount;
    }

    IEnumerator DecreaseCoroutine()
    {
        top.fillAmount = targetAmount;
        float timer = 0;
        while (timer < decreaseDuration)
        {
            timer += Time.deltaTime;
            bottom.fillAmount = Mathf.Lerp(currentAmount, targetAmount, timer / increaseDuration);
            yield return null;
        }
        currentAmount = targetAmount;
    }
}
