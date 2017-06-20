using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSequenceExample : MonoBehaviour 
{
	public string sceneToLoad = "BoomBoxExample";

	void Start()
	{
		MergeTutorial.ins.gameObject.SetActive(false);
		IntroSequencer.instance.OnIntroSequenceComplete += StartIntroTutorial;
		MergeTutorial.ins.OnIntroDone += OnIntroComplete;

		IntroSequencer.instance.StartIntroSequencer();
	}

	void StartIntroTutorial()
	{
		MergeTutorial.ins.gameObject.SetActive(true);
		MergeTutorial.ins.StartTutorial();
	}

	void OnIntroComplete()
	{
		SceneManager.LoadScene(sceneToLoad);
	}
}
