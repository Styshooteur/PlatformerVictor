using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;

public class MusicManager : MonoBehaviour
{
   private static MusicManager _instance;
   
   [FMODUnity.EventRef] [SerializeField] private string musicEvent = "";

   private void Awake()
   // The music doesn't stop through scene switch
   {
      if (!_instance)
      {
         _instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
      DontDestroyOnLoad(gameObject);
   }

   private void Start()
   {
      FMODUnity.RuntimeManager.PlayOneShot(musicEvent, transform.position);
   }
}
