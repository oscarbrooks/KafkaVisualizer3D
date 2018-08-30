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

        var kafkaConsumer = ConsumerFactory.AttatchConsumerComponent(consumerObj, config);

        kafkaConsumer.ConfigureConsumer(config);

        kafkaConsumer.Initialize(_particleSystemPrefab);

        _consumers.Add(kafkaConsumer);

        if(ConsumerAdded != null)
            ConsumerAdded.Invoke(kafkaConsumer);
    }
}
