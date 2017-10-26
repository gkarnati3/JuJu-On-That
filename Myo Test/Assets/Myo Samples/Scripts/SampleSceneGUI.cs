using UnityEngine;
using System.Collections;

// Draw simple instructions for sample scene.
// Check to see if a Myo armband is paired.
public class SampleSceneGUI : MonoBehaviour
{
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo1 = null;
	public GameObject myo2 = null;

    // Draw some basic instructions.
    void OnGUI ()
    {
        GUI.skin.label.fontSize = 20;

        ThalmicHub hub = ThalmicHub.instance;

        // Access the ThalmicMyo script attached to the Myo object.
        ThalmicMyo thalmicMyo1 = myo1.GetComponent<ThalmicMyo> ();

        if (!hub.hubInitialized) {
            GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
                "Cannot contact Myo Connect. Is Myo Connect running?\n" +
                "Press Q to try again."
            );
        } else if (!thalmicMyo1.isPaired) {
            GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
                "No Myo currently paired."
            );
        } else if (!thalmicMyo1.armSynced) {
            GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
                "Perform the Sync Gesture."
            );
        } 

		// Access the ThalmicMyo script attached to the Myo object.
		ThalmicMyo thalmicMyo2 = myo2.GetComponent<ThalmicMyo> ();

		if (!hub.hubInitialized) {
			GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
				"Cannot contact Myo Connect. Is Myo Connect running?\n" +
				"Press Q to try again."
			);
		} else if (!thalmicMyo2.isPaired) {
			GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
				"No Myo currently paired."
			);
		} else if (!thalmicMyo2.armSynced) {
			GUI.Label(new Rect (12, 8, Screen.width, Screen.height),
				"Perform the Sync Gesture."
			);
		} 
    }

    void Update ()
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (Input.GetKeyDown ("q")) {
            hub.ResetHub();
        }
    }
}
