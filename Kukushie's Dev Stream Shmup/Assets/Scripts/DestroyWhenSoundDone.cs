using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenSoundDone : MonoBehaviour
{
    public AudioSource audioSource;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(this.audioSource.clip.length);
        Destroy(this.gameObject);
    }
}
