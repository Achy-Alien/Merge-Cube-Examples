using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationManager : MonoBehaviour 
{


	public void LoadScene( string sceneName )
	{
		SceneManager.LoadScene(sceneName);
	}

	bool sceneMenuIsOpen = false;
	public Animator scenePanelAnimator;

	public void ToggleSceneMenu()
	{
		if (sceneMenuIsOpen)
		{
			scenePanelAnimator.Play("Close");
		}
		else
		{
			scenePanelAnimator.Play("Open");
		}

		sceneMenuIsOpen = !sceneMenuIsOpen;

	}
}
