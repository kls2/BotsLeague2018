using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {

	void Start () {
        //Application.targetFrameRate = 60;
        Screen.SetResolution(720,1280, false);
        //480, 800;
        Destroy(this);
    }
	
}
