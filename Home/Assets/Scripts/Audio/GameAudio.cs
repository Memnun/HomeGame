using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{

	public FMOD.Studio.EventInstance ambiance;
	public FMOD.Studio.EventInstance walk;
	public FMOD.Studio.EventInstance music;

    // Start is called before the first frame update
    void Start()
    {
        ambiance = FMODUnity.RuntimeManager.CreateInstance("event:/Ambience/Ambience_2D");
        ambiance.start();
        walk = FMODUnity.RuntimeManager.CreateInstance("event:/Player-Assigned/Movement_Player");
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Gamplay_Loop");
        music.setParameterValue("Turn", 0);
        music.start();
    }

    // Update is called once per frame
    void Update()
    {
        ambiance.setParameterValue("Season", Globals.Instance.playerList[Globals.Instance.currentPlayer].currentSeason);
        music.setParameterValue("Turn", Globals.Instance.currentPlayer-1);
    }
    void walkstop() {
    	walk.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    	
    }
    public void walkInstance() {
    	walk.start();
    	Invoke("walkstop", 0.5f);
    }
    public void getResource() {
    	FMODUnity.RuntimeManager.PlayOneShot("event:/Player-Assigned/Resource_Get");
    }
    public void ringIn() {
    	FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Transition_Turn");
    }
    public void VicoTori () {
    	FMODUnity.RuntimeManager.PlayOneShot("event:/Music/Victory_Music");
    }
}
