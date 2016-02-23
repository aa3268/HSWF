using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	public void Restart()
	{
		Application.LoadLevel (1);
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
