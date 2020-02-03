using Newtonsoft.Json;
using UnityEngine;

public class AwesomeEnemy : MonoBehaviourExtended
{
    [SerializeField] private AwesomeEnemyData awesomeEnemyData;

    protected override string GetDataSerialized()
    {
        awesomeEnemyData.x = transform.position.x;
        awesomeEnemyData.y = transform.position.y;
        awesomeEnemyData.z = transform.position.z;
        return JsonConvert.SerializeObject(awesomeEnemyData);
    }

    public override void Deserialize(string content)
    {
        awesomeEnemyData = JsonConvert.DeserializeObject<AwesomeEnemyData>(content);
        transform.position = new Vector3(awesomeEnemyData.x, awesomeEnemyData.y, awesomeEnemyData.z);
    }

    [System.Serializable]
    public class AwesomeEnemyData
    {
        [JsonProperty] public float Health;

        [JsonProperty] public float x;
        [JsonProperty] public float y;
        [JsonProperty] public float z;
    }
}