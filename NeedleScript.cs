using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NeedleScript : MonoBehaviour {
    Texture2D dialTex;
    Texture2D needleTex;
    Vector2 dialPos;
    float topSpeed;
    float stopAngle;
    float topSpeedAngle;
    float speed;
    void OnGUI() {
        GUI.DrawTexture(Rect(dialPos.x, dialPos.y, dialTex.width, dialTex.height), dialTex);
        var centre = Vector2(dialPos.x + dialTex.width / 2, dialPos.y + dialTex.height / 2);
        var savedMatrix = GUI.matrix;
        var speedFraction = speed / topSpeed;
        var needleAngle = Mathf.Lerp(stopAngle, topSpeedAngle, speedFraction);
        GUIUtility.RotateAroundPivot(needleAngle, centre);
        GUI.DrawTexture(Rect(centre.x, centre.y - needleTex.height / 2, needleTex.width, needleTex.height), needleTex);
        GUI.matrix = savedMatrix;
    }
}
