using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer : SingletonMonobehaviour<SoundPlayer>{

    GameObject soundPlayer;
    AudioSource audioSource;
    Dictionary<string, AudioClipInfo> audioClips = new Dictionary<string, AudioClipInfo>();

    //AudioClipInfo
    class AudioClipInfo
    {
        public string resourceName;
        public string name;
        public AudioClip clip;

        public AudioClipInfo(string resourceName, string name)
        {
            this.resourceName = resourceName;
            this.name = name;
        }
    }

    public void Awake()
	{

        if (soundPlayer == null)
        {
            soundPlayer = gameObject;
            audioSource = soundPlayer.AddComponent<AudioSource>();
        }

        //SE
        audioClips.Add("Explosion", new AudioClipInfo("Explosion", "se001"));
        
        //BGM
        //audioClips.Add("");

        DontDestroyOnLoad(this);

    }

    public bool PlaySoundEffect(string seName)
    {
        if (audioClips.ContainsKey(seName) == false)
            return false;   //not register error

        AudioClipInfo audioclipinfo = audioClips[seName];

        if (audioclipinfo.clip == null)
            audioclipinfo.clip = (AudioClip)Resources.Load("Sounds/" + audioclipinfo.resourceName);

        audioSource.PlayOneShot(audioclipinfo.clip);
        
        return true;
    }
	
}
