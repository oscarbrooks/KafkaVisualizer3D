using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class KafkaConsumer : MonoBehaviour
{
    private Consumer<Null, string> _consumer;

    public ConsumerConfig Config { get; set; }

    [SerializeField]
    private ParticleSystem _particleSystem;

    private const string ConsumerGroupId = "kafka-visualizer-3d";

    private void Start()
    {
        var conf = new Dictionary<string, object>
        {
            { "group.id", ConsumerGroupId },
            { "bootstrap.servers", Config.Servers }
        };

        _consumer = new Consumer<Null, string>(conf, null, new StringDeserializer(Encoding.UTF8));

        _consumer.OnMessage += OnMessage;

        _consumer.OnError += (_, error)
            => Debug.Log($"Error: {error}");

        _consumer.OnConsumeError += (_, msg)
            => Debug.Log($"Consume error ({msg.TopicPartitionOffset}): {msg.Error}");

        _consumer.Subscribe(Config.Topic);

        StartCoroutine(Poll());
    }

    private void Update()
    {
    }

    public void Configure(ConsumerConfig config)
    {
        Config = config;
    }

    private IEnumerator Poll()
    {
        while (true)
        {
            _consumer.Poll(0);

            if (Config.PollingRateMs == -1) yield return new WaitForEndOfFrame();

            yield return new WaitForSeconds(Config.PollingRateMs / 1000f);
        }
    }

    private void OnMessage(object _, Message<Null, string> msg)
    {
        Debug.Log($"Read '{msg.Value}' from: {msg.TopicPartitionOffset}");
        _particleSystem.Emit(1);
    }
}
