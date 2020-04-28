// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using System.IO;

// public class shareHighscore : MonoBehaviour
// {
//     public GameObject panel_share;
//     public Text txtPanelHighscore;
//     public Text txtHomeHighscore;

//     public void ShareScore() { //on click button share
//         txtPanelHighscore.text = txtHomeHighscore.text;

//         panel_share.SetActive(true);
//         StartCoroutine ("TakeScreenshotAndShare");
//     }

//     IEnumerator TakeScreenshotAndShare(){
//         yield return new WaitForEndOfFrame ();

// 		Texture2D tx = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
// 		tx.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
// 		tx.Apply ();

// 		string path = Path.Combine (Application.temporaryCachePath, "sharedImage.png");//image name
// 		File.WriteAllBytes (path, tx.EncodeToPNG ());

// 		Destroy (tx); //to avoid memory leaks

// 		new NativeShare ()
// 			.AddFile (path)
// 			.SetSubject ("This is my score")
// 			.SetText ("share your score with your friends")
// 			.Share ();


// 		panel_share.SetActive (false); //hide the panel
//     }

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VoxelBusters;
using VoxelBusters.NativePlugins;

public class shareHighscore : MonoBehaviour
{
	private bool isSharing = false;

	public void RateMyApp()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			NPBinding.Utility.OpenStoreLink ("com.RoixoGames.TwinSuns");
		}
	}

	public void ShareSocialMedia ()
	{
		isSharing = true;
	}

	void LateUpdate ()
	{
		if (isSharing == true)
		{
			isSharing = false;

			StartCoroutine (CaptureScreenShoot());
		}
	}

	IEnumerator CaptureScreenShoot ()
	{
		yield return new WaitForEndOfFrame ();

		Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture ();

		ShareSheet (texture);

		Object.Destroy (texture);
			
	}

	private void ShareSheet (Texture2D texture)
	{
		ShareSheet _shareSheet = new ShareSheet ();

		_shareSheet.Text = "Hello world!!!";
		_shareSheet.AttachImage (texture);
		_shareSheet.URL = "https://twitter.com/RoixoGames";

		NPBinding.Sharing.ShowView (_shareSheet, FinishSharing);
	}

	private void FinishSharing (eShareResult _result)
	{
		Debug.Log (_result);
	}
}