using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip jumpWave;
    public AudioClip Hop;
    public AudioClip byeBye;
    public AudioClip changeCube;
    public AudioClip Coily_Over_the_edge;
    public AudioClip Ahop;
    public AudioClip Game_start_music;
    public AudioClip coin_Drop;
    public AudioClip bonk;
	public AudioClip Ride_the_disk;

    public void PacmanJump()
	{
		audio.PlayOneShot(jumpWave);	
	}
    public void qbertjump()
	{
		audio.PlayOneShot(Hop);
	}
    public void gameover()
	{
		audio.PlayOneShot(byeBye);
	}
    public void changcube()
	{
		audio.PlayOneShot(changeCube);
	}
    public void eventsound()
	{
		audio.PlayOneShot(Coily_Over_the_edge);
	}
    public void balljump()
	{
		audio.PlayOneShot(Ahop);
	}
    public void startmusic()
	{
		audio.PlayOneShot(Game_start_music);
	}
    public void powerup()
	{
		audio.PlayOneShot(coin_Drop);
	}
    public void touchball()
	{
		audio.PlayOneShot(bonk);
	}
	public void bonus()
	{
		audio.PlayOneShot (Ride_the_disk);
	}
}
