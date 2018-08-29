namespace KafkaVisualizer3D.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ConsumersPanel : MonoBehaviour {

        [SerializeField]
        private Button _addConsumerButton;

        [SerializeField]
        private GameObject _addConsumerPanel;

        [SerializeField]
        private GameObject _consumerListItemPrefab;

        [SerializeField]
        private GameObject _scrollViewContent;

	    private void Start () {
            _addConsumerButton.onClick.AddListener(() => _addConsumerPanel.SetActive(true));

            ConsumersManager.Instance.ConsumerAdded += OnConsumerAdded;
	    }

	    private void Update () {

	    }

        private void OnConsumerAdded(IKafkaConsumer kafkaConsumer)
        {
            Debug.Log("Picked Up");
            var listItem = Instantiate(_consumerListItemPrefab, _scrollViewContent.transform)
                .GetComponent<ConsumerListItem>();

            listItem.Configure(kafkaConsumer.Config);
        }
    }
}
