using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneSerializer
{
    [MenuItem("Tools/Serialize scene")]
    public static void SerializeScene()
    {
        MonoBehaviourExtended[] objects = Object.FindObjectsOfType<MonoBehaviourExtended>();
        PrefabInfo[] prefabs = new PrefabInfo[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            prefabs[i] = objects[i].GetPrefabInfo();
        }

        string path = $"Assets/SerializedScenes/{SceneManager.GetActiveScene().name}.json";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(JsonConvert.SerializeObject(prefabs));
        writer.Close();
        AssetDatabase.Refresh();
    }

    [MenuItem("Assets/Load Scene")]
    public static void LoadScene()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        string sceneObjectsSerialized = AssetDatabase.LoadAssetAtPath<TextAsset>(path).text;
        PrefabInfo[] objects = JsonConvert.DeserializeObject<PrefabInfo[]>(sceneObjectsSerialized);
        foreach (PrefabInfo serializedObject in objects)
        {
            serializedObject.Instantiate();
        }
    }
}

[System.Serializable]
public class PrefabInfo
{
    [JsonProperty] [HideInInspector] public string prefabPath;
    [JsonProperty] [HideInInspector] public string content;

    public void Instantiate()
    {
        GameObject newObject = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath));
        newObject.GetComponent<MonoBehaviourExtended>().Deserialize(content);
    }
}