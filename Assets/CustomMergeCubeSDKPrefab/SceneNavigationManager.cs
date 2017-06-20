using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationManager : MonoBehaviour 
{
	public Transform MenuRoot;
	void Awake(){
		transform.parent = MenuRoot;

	}
	public void LoadScene( string sceneName )
	{
		SceneManager.LoadScene(sceneName);
	}
}
