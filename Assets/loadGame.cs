using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool isSpace = Input.GetKeyDown (KeyCode.Space);

		if (isSpace) {
			SceneManager.LoadScene ("Museum");
		}
	}
}
