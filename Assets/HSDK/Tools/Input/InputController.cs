using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * How To Use:
 * Add this Input Controller on an empty GameObject in the scene.
 * Set the lMask in the inspector to whichever layer you wish for gui collisions to occur.

 * Add the methods called OnClick, OnHoverStart, and OnHoverEnd to the objects you wish to have listening to the input events.
 * For an example, add the script InputButton to your object.
 * 
 * 
 * This is the main input driver. It handles touch events by shooting a ray from the headset to the forward direction.
 * Any object that collides with the raycast will receive the OnClick, OnHoverStart, and OnHoverEnd events as they happen.
 **/

public class InputController : MonoBehaviour 
{
	public static InputController instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			DestroyImmediate(this.gameObject);
	}

	public LayerMask lMask;
	Transform headTransform;
	
	RaycastHit hit;
	Transform currentGazedObject;
	bool currentlyGazing = false;

	bool isTouchInput = false;


	void Start () 
	{
		headTransform = Camera.main.transform.parent;
	}

	public void SwitchInput(bool isTouchInputTp)
	{
		isTouchInput = isTouchInputTp;
	}

	void Update ()
	{		
		Ray ray = new Ray ();

		if (isTouchInput) 
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		} 
		else 
		{
			ray.origin = headTransform.position;
			ray.direction = headTransform.forward;
		}

		if (Physics.Raycast (ray, out hit, 10f, lMask)) 
		{			
			CheckGazing ();

			if (Input.GetMouseButtonDown (0)) 
			{
				hit.transform.SendMessage ("OnClick", SendMessageOptions.DontRequireReceiver);
			}					
		} 
		else 
		{
			if (currentlyGazing) 
			{
				HoverEnd ();
			} 
		}		
	}

	void CheckGazing()
	{
		if (!isTouchInput) 
		{
			if (!currentlyGazing) 
			{
				HoverStart ();
			} 
			else 
			{
				if (currentGazedObject != hit.transform) 
				{
					HoverEnd ();
					HoverStart ();
				}
			}
		}
	}

	void HoverStart()
	{
		currentlyGazing = true;
		hit.transform.SendMessage ("OnHoverStart", SendMessageOptions.DontRequireReceiver);
		currentGazedObject = hit.transform;

		if (PointerControl.Ins != null) 
		{
			PointerControl.Ins.ZoomUp ();
		}
	}

	void HoverEnd()
	{
		currentlyGazing = false;
		currentGazedObject.transform.SendMessage ("OnHoverEnd", SendMessageOptions.DontRequireReceiver);

		if (PointerControl.Ins != null) 
		{
			PointerControl.Ins.ZoomToDefault ();
		}
	}
}
