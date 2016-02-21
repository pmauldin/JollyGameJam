using UnityEngine;
using System.Collections;
[ExecuteInEditMode()]

public class RotatableGuiItem : MonoBehaviour {

    public Texture2D dialTex;
    public Texture2D needleTex;
    public Vector2 dialPos;
    public float topSpeed;
    public float stopAngle;
    public float topSpeedAngle;
    public float speed;

    void OnGUI()
    {

        Vector2 centre = new Vector2(dialPos.x + dialTex.width / 2, dialPos.y + dialTex.height / 2);
        float speedFraction = speed / topSpeed;
        float needleAngle = Mathf.Lerp(stopAngle, topSpeedAngle, speedFraction);
        Matrix4x4 savedMatrix = GUI.matrix;
        GUI.DrawTexture(new Rect(dialPos.x, dialPos.y, dialTex.width, dialTex.height), dialTex);
        GUIUtility.RotateAroundPivot(needleAngle, centre);
        GUI.DrawTexture(new Rect(centre.x, centre.y - needleTex.height / 2, needleTex.width, needleTex.height), needleTex);
        GUI.matrix = savedMatrix;
    }
}
