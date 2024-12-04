using UnityEditor;

[CustomEditor(typeof(LayoutComp))]
public class LayoutCompEditor : Editor
{
    private SerializedProperty data1Property;
    private SerializedProperty data2Property;
    private SerializedProperty data3Property;
    private SerializedProperty data4Property;
    private SerializedProperty data5Property;
    private SerializedProperty data6Property;
    private SerializedProperty data7Property;

    private bool flodState = false;

    private void OnEnable()
    {
        data1Property = serializedObject.FindProperty("data1");
        data2Property = serializedObject.FindProperty("data2");
        data3Property = serializedObject.FindProperty("data3");
        data4Property = serializedObject.FindProperty("data4");
        data5Property = serializedObject.FindProperty("data5");
        data6Property = serializedObject.FindProperty("data6");
        data7Property = serializedObject.FindProperty("data7");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        flodState = EditorGUILayout.Foldout(flodState, "Layout");

        if (flodState)
        {
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(data1Property);
            data2Property.stringValue = EditorGUILayout.TextField("Data 2", data2Property.stringValue);
            EditorGUILayout.PropertyField(data3Property);
            EditorGUILayout.PropertyField(data4Property);
            EditorGUILayout.PropertyField(data5Property);
            EditorGUILayout.PropertyField(data6Property);
            EditorGUILayout.PropertyField(data7Property);

            EditorGUI.indentLevel--;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
