Input Tool Scripts

How to Use:

InputController:
- Add this Input Controller on an empty GameObject in the scene.
- Set the lMask in the inspector to whichever layer you wish for gui collisions to occur.

InputRelativeRotation:
- Attach this script to the ImageTarget. Then register to the OnRotationChange event to listen for changes in rotation.
- This event call will happen every update.

InputButton:
- Attach this script to any object that you wish to have receive gaze inputs from.

PointerControl:
- Attach sprite renderer object to ARCamera to ensure reticle stays in place on screen.
- Attach script to your sprite renderer reticle.

InputVelocity:
- Register to the OnVelocityReached() event to receive the average direction once terminal velocity is reached.

AndroidAutofocuser:
- Attach this script to the MultiTarget object that handles tracking the HoloCube.

BasicTrackableEventHandler:
- Attach this script to the MultiTarget object within the scene.

CubeOrientation:
- Call this script's OrientateToCamera function from another script by using the proper namespace:
	Merge.CubeOrientation.OrientateToCamera (Transform imageTargetLocation, Transform target);



