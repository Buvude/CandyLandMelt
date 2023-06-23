using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioModelCaller : MonoBehaviour
{
    [SerializeField] private Jump jump;
    public void Step()
    {
        if(jump.GetJumpAvailable())
            AkSoundEngine.PostEvent("Step", this.gameObject);
    }
}
