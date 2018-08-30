using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System;
using UnityEngine;

public static class ConsumerFactory {
    public static IKafkaConsumer AttatchConsumerComponent(GameObject obj, ConsumerConfig config)
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

    public static IDeserializer<T> GetDeserializer<T>(ConsumerConfig config)
    {
        switch (config.KeyType.ToLower())
        {
            case KafkaConsumerKeyTypes.NullType:
                return new NullDeserializer() as IDeserializer<T>;
            case KafkaConsumerKeyTypes.StringType:
                return new StringDeserializer() as IDeserializer<T>;
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
