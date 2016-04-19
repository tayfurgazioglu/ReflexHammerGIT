using UnityEngine;
using System.Collections;

using Parse;

public class BOKK : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var dimensions = new System.Collections.Generic.Dictionary<string, string> {
  // What level are you playing?
  { "level", "12" },
  // How long did it take them to die?
  { "secondsPlayed", "184" },
  // Did they complete the level?
  { "completed", "false"}
};
        ParseAnalytics.TrackEventAsync("LostLife", dimensions);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

}
