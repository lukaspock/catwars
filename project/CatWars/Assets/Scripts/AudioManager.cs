using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public enum SoundType
    {
        Jump,
        Powerup,
        Shoot,
        Music_Menu,
        Music_Battle
        // Add more sound types as needed
    }

    [System.Serializable]
    public class Sound
    {
        public SoundType Type;
        public AudioClip Clip;

        [Range(0f, 1f)]
        public float Volume = 1f;

        [HideInInspector]
        public AudioSource Source;
    }

    //Singleton
    public static AudioManager Instance;

    //All sounds and their associated type - Set these in the inspector
    public Sound[] AllSounds;

    //Runtime collections
    private Dictionary<SoundType, Sound> _soundDictionary = new Dictionary<SoundType, Sound>();
    private AudioSource _musicSource;

    private void Awake()
    {
        //Assign singleton
        Instance = this;

        //Set up sounds
        foreach(var s in AllSounds)
        {
            _soundDictionary[s.Type] = s;
        }
    }



    public void Play(SoundType type, Vector3 position)
    {
        if (!_soundDictionary.TryGetValue(type, out Sound s))
        {
            Debug.LogWarning($"Sound type {type} not found!");
            return;
        }

        // Spawn the object at the specific position provided
        var soundObj = new GameObject($"Sound_{type}");
        soundObj.transform.position = position; 

        var audioSrc = soundObj.AddComponent<AudioSource>();

        // Assign properties
        audioSrc.clip = s.Clip;
        audioSrc.volume = s.Volume;

        // IMPORTANT: Make it a 3D sound so the position actually matters
        audioSrc.spatialBlend = 0f; // 1 = 3D, 0 = 2D
        audioSrc.minDistance = 1000f;
        audioSrc.maxDistance = 50000f; // Adjust based on your game scale
        audioSrc.rolloffMode = AudioRolloffMode.Linear;

        audioSrc.Play();
        Debug.LogWarning($"Sound type {type} played!" + audioSrc);

        Destroy(soundObj, s.Clip.length);
    }
}