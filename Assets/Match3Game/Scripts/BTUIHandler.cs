using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTUIHandler : MonoBehaviour {
    //BTHome

	public void PlayButtonClick()
    {
        SceneManager.LoadScene("BTMap");
	}
    public void EditAvatarButtonClick()
    {
        SceneManager.LoadScene("BTEditAvatar");
    }

    /* Make settings button create pop up to change audio, sound fx on/off, see credits, etc
    public void SettingsButton()
    {
        SceneManager.LoadScene("");
    }
    */
        public void FacebookButton()
    {
        Application.OpenURL("https:www.facebook.com/BotsLeague/");
    }

    //BTMap
            //Click on level to go to level
            //settings?


    //BTGameplay
            //PauseButton


    //BTEditAvatar
            //settings?



}



