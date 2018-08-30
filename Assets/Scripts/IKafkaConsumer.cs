using UnityEngine;

public interface IKafkaConsumer {
    ConsumerConfig Config { get; set; }
    void ConfigureConsumer(ConsumerConfig config);
    void Initialize(GameObject particleSystemPrefab);
}
