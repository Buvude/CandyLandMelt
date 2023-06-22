using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioModelCaller : MonoBehaviour
{
    public void Step()
    {
        AkSoundEngine.PostEvent("Step", this.gameObject);
    }
}
