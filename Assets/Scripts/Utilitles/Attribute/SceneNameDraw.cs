using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SceneNameAttribute))]
public class SceneNameDraw : PropertyDrawer
{
    int Index = -1;
    GUIContent[] sceneNames;
    readonly string[] scenePathSplit = {"/",".unity"};
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (EditorBuildSettings.scenes.Length==0)
        {
            return;
        }
    }
    private void GetSceneNameArray(SerializedProperty property)
    {
        var scenes = EditorBuildSettings.scenes;
        sceneNames = new GUIContent[scenes.Length];

        for (int i =0;i<sceneNames.Length;i++)
        {
            string path = scenes[i].path;

            string[] splitPath = path.Split(scenePathSplit,System.StringSplitOptions.RemoveEmptyEntries);

            string sceneName = "";

            if (splitPath.Length>0)
            {
                sceneName = splitPath[splitPath.Length-1];
            }
            else
            {
                sceneName = "(Deleta Scene)";
            }
            sceneName[i]=new GUIContent(sceneName);
        }
    }
}
