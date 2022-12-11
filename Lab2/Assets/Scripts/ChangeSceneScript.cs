using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    private const string scene1Trigger = "Red thing";
    private const string scene2Trigger = "Blue thing";
    private const string scene1 = "Scene1";
    private const string scene2 = "Scene2";
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.name == scene2Trigger)
        {
            SceneManager.LoadScene(scene2);
        }
        if (col.gameObject.name == scene1Trigger)
        {
            SceneManager.LoadScene(scene1);
        }
    }
}
