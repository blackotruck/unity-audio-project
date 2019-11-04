using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{
  [SerializeField]
  AudioSource audioSource;
  [SerializeField]
  AudioManager audioManager;

  void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      Debug.Log("Change Music");
      audioManager.CrossfadeVariantMusic(audioSource);
    }
  }

  void OnTriggerExit(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      Debug.Log("Change Music");
      audioManager.CrossfadeAmbientMusic();
    }
  }
}
