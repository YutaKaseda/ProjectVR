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
        public AudioClip clip;

        public AudioClipInfo(string resourceName)
        {
            this.resourceName = resourceName;
        }
    }

    public void Awake()
	{

        if (soundPlayer == null)
        {
            soundPlayer = gameObject;
            audioSource = soundPlayer.AddComponent<AudioSource>();
        }

        //audioClips.Add("Explosion", new AudioClipInfo("Explosion4"));
        audioClips.Add("Balkan2", new AudioClipInfo("laser"));
        audioClips.Add("warp", new AudioClipInfo("warp"));
        audioClips.Add("Railgun", new AudioClipInfo("beamgun"));
		audioClips.Add("charge", new AudioClipInfo("charge"));
		audioClips.Add("Bomb", new AudioClipInfo("explosion"));
        audioClips.Add("push", new AudioClipInfo("push"));

        //DontDestroyOnLoad(this);

    }

    public bool PlaySoundEffect(string seName,float seVolume)
    {

        Debug.Log(seName);
        if (audioClips.ContainsKey(seName) == false)
            return false;   //not register error

        AudioClipInfo audioclipinfo = audioClips[seName];

        if (audioclipinfo.clip == null)
            audioclipinfo.clip = (AudioClip)Resources.Load("Sounds/" + audioclipinfo.resourceName);


        audioSource.volume = seVolume;
        audioSource.PlayOneShot(audioclipinfo.clip);
        
        return true;
    }
	
}
