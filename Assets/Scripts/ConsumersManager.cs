using System;
using System.Collections.Generic;
using UnityEngine;

public class ConsumersManager : MonoBehaviour {

    private static ConsumersManager _instance;

    public static ConsumersManager Instance {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ConsumersManager>();
            }
            return _instance;
        }
    }

    public Action<IKafkaConsumer> ConsumerAdded;

    [SerializeField]
    private List<IKafkaConsumer> _consumers = new List<IKafkaConsumer>();

    [SerializeField]
    private Transform _consumerSpawn;

    [SerializeField]
    private GameObject _particleSystemPrefab;

    private void Start () {
		
	}
	
	private void Update () {
		
	}

    public void AddConsumer(ConsumerConfig config)
    {

        var consumerObj = new GameObject("Consumer-" + config.Topic);
        consumerObj.transform.position = _consumerSpawn.position;

        var kafkaConsumer = AttatchKafkaConsumerComponent(consumerObj, config);

        kafkaConsumer.Configure(config, _particleSystemPrefab);

        Debug.Log("Consumer null? " + (kafkaConsumer == null));

        _consumers.Add(kafkaConsumer);

        if(ConsumerAdded != null)
            ConsumerAdded.Invoke(kafkaConsumer);
    }

    private static IKafkaConsumer AttatchKafkaConsumerComponent(GameObject obj, ConsumerConfig config)
    {
        switch (config.KeyType.ToLower())
        {
            case KafkaConsumerKeyTypes.NullType:
                return obj.AddComponent<KafkaConsumerNullKey>();
            case KafkaConsumerKeyTypes.StringType:
                return obj.AddComponent<KafkaConsumerStringKey>();
            default:
                throw new ArgumentException(
                    string.Format("Kafka consumer key type <{0}> is not of supported type: Null | string"),
                    config.KeyType
                );
        }
    }
}

// Generic Monobehaviour workaround
public class KafkaConsumerNullKey : KafkaConsumer<Confluent.Kafka.Null> { }
public class KafkaConsumerStringKey : KafkaConsumer<string> { }
