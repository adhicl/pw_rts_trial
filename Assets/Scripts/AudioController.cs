using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip aPortal;
    public AudioClip aBuild;

	private AudioSource mSource;

    public static AudioController instance { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
	{
		mSource = this.GetComponent<AudioSource>();
	}
	public void PlaySoundPortal()
	{
		mSource.PlayOneShot(aPortal);
	}

	public void PlaySoundBuild()
	{
		mSource.PlayOneShot(aBuild);
	}
}
