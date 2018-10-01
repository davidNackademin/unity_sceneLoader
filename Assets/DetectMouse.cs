using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouse : MonoBehaviour {


    private void OnMouseDown()
    {
        GameObject.Find("SceneHandler").GetComponent<SceneHandler>().ChangeScene("Level2");
    }



}
