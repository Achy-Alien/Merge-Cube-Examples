using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExampleManager : MonoBehaviour {
	public Transform cubeRoot;
	public Renderer [] cubeSides;
	int cubeClickCount = 1;

	public Color [] colorPool;
	int colorIndex = 0;

	public bool alwaysReMatch = false;
	bool alreadyMatch = false;
	void Start(){
		GetComponent<BasicTrackableEventHandler>().OnTrackingFound += OnTrackingFound;
		GetComponent<BasicTrackableEventHandler>().OnTrackingLost += OnTrackingLost;
	}
	void OnTrackingFound(){
		if (!alreadyMatch) {
			transform.FaceToCamera (cubeRoot);
			alreadyMatch = !alwaysReMatch;
		}
	}
	void OnTrackingLost(){
		
	}

	public void CubeClick(){
		cubeClickCount++;
		if (cubeClickCount > 5) {
			cubeClickCount = 1;
		}
		Vector2 sizeTp = Vector2.one * (float)cubeClickCount;
		foreach (Renderer tp in cubeSides) {
			tp.material.SetTextureScale ("_decal", sizeTp);
		}
	}

	public void NextClick(){
		colorIndex++;
		if (colorIndex >= colorPool.Length) {
			colorIndex = 0;
		}
		foreach (Renderer tp in cubeSides) {
			tp.material.SetColor("_basecolor", colorPool[colorIndex]);
		}
	}
}
