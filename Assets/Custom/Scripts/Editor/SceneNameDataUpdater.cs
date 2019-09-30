using System.IO;
using System.Linq;
using UnityEditor;

public static class SceneNameDataUpdater
{
    [MenuItem("Assets/Custom/UpdateSceneNameData")]
    public static void UpdateSceneNameData()
    {
        var sceneNameData = Selection.activeObject as StringArrayObject;
        if (sceneNameData == null) { return; }

        sceneNameData.values = EditorBuildSettings.scenes
            .Skip(1)
            .Select(_scene => Path.GetFileNameWithoutExtension(_scene.path))
            .ToArray();

        EditorUtility.SetDirty(sceneNameData);
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Assets/Custom/UpdateSceneNameData", true)]
    public static bool UpdateSceneNameDataValidater()
    {
        return Selection.activeObject != null && Selection.activeObject is StringArrayObject;
    }
}