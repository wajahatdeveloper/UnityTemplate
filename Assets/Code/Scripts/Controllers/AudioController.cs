using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : SingletonBehaviour<AudioController>
{
	public AudioSource Music;
	public AudioSource SFX;

	public void GetPlayerPrefs()
	{
		SetMusicVolume(PlayerPrefs.HasKey("Music") ? PlayerPrefs.GetFloat("Music") : 1);
		SetSoundFXVolume(PlayerPrefs.HasKey("SoundFX") ? PlayerPrefs.GetFloat("SoundFX") : 1);
	}

	public void PlayMusic(AudioClip clip)
	{
		Music.clip = clip;
		Music.Play();
	}

	public void StopMusic()
	{
		Music.Stop();
	}

	public void PlaySoundFx(AudioClip clip)
	{
		ChangeClip(clip);
		SFX.Play();
	}

	public void StopSoundFX()
	{
		SFX.Stop();
	}

	public void ChangeClip(AudioClip clip)
	{
		SFX.clip = clip;
	}

	public void SetMusicVolume(float volume)
	{
		Music.volume = volume;
	}
	
	public void SetSoundFXVolume(float volume)
	{
		SFX.volume = volume;
	}
}
