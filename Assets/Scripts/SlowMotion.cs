using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 0.5f;
    public Animator startAnim;

    private void Start()
    {
        startAnim.SetTrigger("LiftGoUp");
        StartCoroutine(CanAct());
    }

    public void DoSlowMotion()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public void DoSpeedUp()
    {
        Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    private IEnumerator CanAct()
    {
        yield return new WaitForSeconds(10f);
        GameManager.Instance.canAct = true;
    }
}
