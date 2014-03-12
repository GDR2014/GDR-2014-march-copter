using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AspectLock))]
public class AspectLockEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if( GUILayout.Button( "Recalculate" ) ) ((AspectLock)target).Recalculate();
    }
}
