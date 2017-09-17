using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class AudioPool : MonoBehaviour
{
	public AudioMixerGroup mixerGroup;
    private List<AudioSource> _sources;
    private int _maxSources = 6;

    public void Start()
    {
    	_sources = new List<AudioSource>();
    }

    public AudioSource GetAudioSourceFromPool()
    {
        foreach (AudioSource source in _sources)
		{
            if (!source.isPlaying) return source;
        }
		if (_sources.Count >= _maxSources)
		{
			Debug.LogWarning("NO HIT AUDIOSOURCES AVAILABLE. ADD MORE SOURCES TO POOL");
			return null;
		}
        var newSource = gameObject.AddComponent<AudioSource>();
		if (mixerGroup != null) newSource.outputAudioMixerGroup = mixerGroup;
        _sources.Add(newSource);
        return newSource;
    }

}
