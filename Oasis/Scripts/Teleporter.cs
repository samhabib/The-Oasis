using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour {
	public string destinationScene = "";
	void Start () {}

	void Update () {}

	void OnCollisionEnter(Collision col)
	{	print ("teleporter collision detected");
		print (col.gameObject.tag);
		if (col.gameObject.tag == "Player") {
			StartCoroutine(LoadYourAsyncScene());
		}
	}

	IEnumerator LoadYourAsyncScene()
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(destinationScene);
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}
