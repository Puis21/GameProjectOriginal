using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            UIManager.Instance.movementPanel.SetActive(true);
            StartCoroutine(PanelClose());
        }
    }

    private IEnumerator PanelClose()
    {
        yield return new WaitForSeconds(5f);
        UIManager.Instance.movementPanel.SetActive(false);
    }
}
