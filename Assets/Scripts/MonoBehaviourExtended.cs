using UnityEditor;
using UnityEngine;

public abstract class MonoBehaviourExtended : MonoBehaviour
{
    public PrefabInfo GetPrefabInfo()
    {
        return new PrefabInfo
        {
            prefabPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(gameObject),
            content = GetDataSerialized()
        };
    }

    protected virtual string GetDataSerialized()
    {
        return "";
    }

    public virtual void Deserialize(string content) { }
}