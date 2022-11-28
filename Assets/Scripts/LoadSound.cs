using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundMenu.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }
}
