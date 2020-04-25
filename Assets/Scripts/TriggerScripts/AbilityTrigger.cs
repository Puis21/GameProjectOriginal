using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIManager.Instance.shootPanel.SetActive(true);
            StartCoroutine(PanelClose());
        }
    }

    private IEnumerator PanelClose()
    {
        yield return new WaitForSeconds(10f);
        UIManager.Instance.shootPanel.SetActive(false);
    }
}
