using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Vec2d))]
public class Vec2dInspector : Editor
{
    public override void OnInspectorGUI()
    {
        /*
        Vec2d vec = (Vec2d)target;

        Rect rect = new Rect(0, 0, 20, 10);

        EditorGUI.LabelField(rect, "X:");

        rect.x = 25;
        vec.x = EditorGUI.DoubleField(rect, vec.x);

        rect = new Rect(0, 20, 20, 10);

        EditorGUI.LabelField(rect, "Y:");

        rect.x = 25;
        vec.y = EditorGUI.DoubleField(rect, vec.y);
*/
    }
}
