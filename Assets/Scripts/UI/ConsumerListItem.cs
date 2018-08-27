namespace KafkaVisualizer3D.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ConsumerListItem : MonoBehaviour {

        [SerializeField]
        private Text _description;

        private void Start () {
		
	    }
	
	    private void Update () {
		
	    }

        public void Configure(ConsumerConfig config)
        {
            _description.text = config.Servers + " | " + config.Topic;
        }
    }
}
