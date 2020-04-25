using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIManager.Instance.tipPanel.SetActive(true);
            StartCoroutine(PanelClose());
        }
    }

    private IEnumerator PanelClose()
    {
        yield return new WaitForSeconds(7f);
        UIManager.Instance.tipPanel.SetActive(false);
    }
}
