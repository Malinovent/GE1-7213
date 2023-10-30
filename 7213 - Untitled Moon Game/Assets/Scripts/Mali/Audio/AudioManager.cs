using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mali.Audio
{
    public class AudioManager : MonoBehaviour
    {

        #region Singleton Implementation
        public static AudioManager Singleton;

        private void Awake()
        {
            if(Singleton == null)
            {
                Singleton = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        #endregion

        [SerializeField] private AudioClip[] audioClips;

        private List<AudioSource> audioSources = new List<AudioSource>();

        private void Start()
        {
            CreateAudioSourceObject();
        }

        private AudioSource CreateAudioSourceObject()
        {
            //Cree un nouveau object vide
            GameObject newAudioSource = new GameObject();
            newAudioSource.name = "AudioSource";
            newAudioSource.transform.parent = this.transform;

            //Ajouter audioSource a l'objet
            AudioSource audio = newAudioSource.AddComponent<AudioSource>();

            //Ajouter au list
            audioSources.Add(audio);
            return audio;
        }

        public void PlayAudio(AudioClip audioClip)
        {
            //Itere dans la boucle pour trouver un audio qui joue pas
            foreach(AudioSource audioSource in audioSources)
            {
                if(!audioSource.isPlaying)
                {
                    audioSource.clip = audioClip;
                    audioSource.Play();
                    return;
                }
            }

            //Si il n'y a pas, creer un nouveau
            AudioSource newSource = CreateAudioSourceObject();
            newSource.clip = audioClip;
            newSource.Play();
        }

        public void PlayAudio(string audioClipName)
        {
            switch(audioClipName)
            {
                case "fireBall":
                    //Logic play fireball
                    PlayAudio(audioClips[0]);
                    break;
                case "iceBall":
                    //Logic play iceball
                    PlayAudio(audioClips[1]);
                    break;
            }
        }
    }
}
