using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour {

	public void PlayButtonClick()
    {
        SceneManager.LoadScene("BTGameplay");
	}
    public void EditAvatarButtonClick()
    {
        SceneManager.LoadScene("BTEditAvatar");
    }

}
