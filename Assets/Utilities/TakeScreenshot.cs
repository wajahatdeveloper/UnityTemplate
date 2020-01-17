using UnityEngine;
using System.Collections;

public class TakeScreenshot : MonoBehaviour
{    
	private int screenshotCount = 0;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{        
			string screenshotFilename;
			do
			{
				screenshotCount++;
				screenshotFilename = "screenshot" + screenshotCount + ".png";

			} while (System.IO.File.Exists(screenshotFilename));

            // here 2 means the selected resolution in editor will be multiplied my this
			ScreenCapture.CaptureScreenshot(screenshotFilename,2);
		}
	}
}