using System;
using System.Collections;
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

    public Action<KafkaConsumer> ConsumerAdded;

    [SerializeField]
    private List<KafkaConsumer> _consumers;

    [SerializeField]
    private Transform _consumerSpawn;

    [SerializeField]
    private GameObject _consumerPrefab;

	private void Start () {
		
	}
	
	private void Update () {
		
	}

    public void AddConsumer(ConsumerConfig config)
    {
        Debug.Log("Added Consumer " + config.Servers + " " + config.Topic);

        var consumerClone = Instantiate(_consumerPrefab);
        consumerClone.transform.position = _consumerSpawn.position;

        var kafkaConsumer = consumerClone.GetComponent<KafkaConsumer>();

        kafkaConsumer.Configure(config);

        _consumers.Add(kafkaConsumer);

        if(ConsumerAdded != null)
            ConsumerAdded.Invoke(kafkaConsumer);
    }
}
