using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class GameManager : MonoBehaviour
{
    Vignette vign;

    // Start is called before the first frame update
    void Start()
    {
        Volume volume = GetComponent<Volume>();
        Vignette tempvign;

        if (volume.profile.TryGet<Vignette>(out tempvign))
        {
            vign = tempvign;
        }
        vign.intensity.value = 0f;
    }
}
