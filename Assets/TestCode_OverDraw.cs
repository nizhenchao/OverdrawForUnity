using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode_OverDraw : MonoBehaviour {

    public bool isOverDraw;
    private bool Fog = false;
    private Color backGroundColor;
    private CameraClearFlags clearFlags;
    private new Camera camera;
    // Use this for initialization
    void Start ()
    {
        camera = GetComponent<Camera>();
        Fog = RenderSettings.fog;
        backGroundColor = camera.backgroundColor;
        clearFlags = camera.clearFlags;
    }

    // Update is called once per frame
    void OnGUI() {
        if (GUI.Button(new Rect(Screen.width / 2 - 400, 100, 95, 25), "OverDraw"))
        {
            if (!isOverDraw)
            {
                var overDrawShader = Shader.Find("Camera/Effect/OverDraw");
                if (overDrawShader != null)
                {
                    RenderSettings.fog = false;
                    camera.clearFlags = CameraClearFlags.Color;
                    camera.backgroundColor = Color.black;
                    camera.SetReplacementShader(overDrawShader, "RenderType");
                    camera.SetReplacementShader(overDrawShader, "Queue");
                    isOverDraw = true;
                }
            }
            else
            {
                //reset
                RenderSettings.fog = Fog;
                camera.ResetReplacementShader();
                camera.backgroundColor = backGroundColor;
                camera.clearFlags = clearFlags;
                isOverDraw = false;
            }
        }
    }
}