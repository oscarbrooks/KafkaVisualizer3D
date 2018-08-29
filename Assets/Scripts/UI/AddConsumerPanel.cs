namespace KafkaVisualizer3D.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class AddConsumerPanel : MonoBehaviour {

        [SerializeField]
        private ConsumersManager _consumersManager;

        [SerializeField]
        private InputField _serversInput;

        [SerializeField]
        private Dropdown _keyTypeDropdown;

        [SerializeField]
        private InputField _topicInput;

        [SerializeField]
        private InputField _pollingRateInput;

        [SerializeField]
        private Button _addButton;

        [SerializeField]
        private Button _closeButton;

        private void Start () {
            _addButton.onClick.AddListener(AddConsumer);

            _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        }
	
	    private void Update () {
		
	    }

        public void AddConsumer()
        {
            var pollingRate = string.IsNullOrWhiteSpace(_pollingRateInput.text)
                ? 100 : int.Parse(_pollingRateInput.text);

            var config = new ConsumerConfig()
            {
                Servers = _serversInput.text,
                Topic = _topicInput.text,
                KeyType = _keyTypeDropdown.options[_keyTypeDropdown.value].text,
                PollingRateMs = pollingRate
            };

            _consumersManager.AddConsumer(config);
        }
    }
}

