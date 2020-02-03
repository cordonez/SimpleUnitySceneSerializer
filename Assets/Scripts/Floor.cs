using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class Floor : MonoBehaviourExtended
{
    [SerializeField] private FloorData floorData;

    protected override string GetDataSerialized()
    {
        floorData.x = transform.position.x;
        floorData.y = transform.position.y;
        floorData.z = transform.position.z;

        floorData.xScale = transform.localScale.x;
        floorData.yScale = transform.localScale.y;
        floorData.zScale = transform.localScale.z;
        return JsonConvert.SerializeObject(floorData);
    }

    public override void Deserialize(string content)
    {
        floorData = JsonConvert.DeserializeObject<FloorData>(content);
        transform.position = new Vector3(floorData.x, floorData.y, floorData.z);
        transform.localScale = new Vector3(floorData.xScale, floorData.yScale, floorData.zScale);
    }

    [System.Serializable]
    public class FloorData
    {
        [JsonProperty] public float x;
        [JsonProperty] public float y;
        [JsonProperty] public float z;

        [JsonProperty] public float xScale;
        [JsonProperty] public float yScale;
        [JsonProperty] public float zScale;
    }
}