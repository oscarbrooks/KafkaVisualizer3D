using UnityEngine;

public interface IKafkaConsumer {
    ConsumerConfig Config { get; set; }
    void Configure(ConsumerConfig config, GameObject particleSystemPrefab);
}
