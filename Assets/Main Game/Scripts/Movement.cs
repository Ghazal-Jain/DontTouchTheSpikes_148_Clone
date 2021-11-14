using TMPro;
using UnityEngine;

namespace Main_Game.Scripts
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private bool _rightDir = true;
        [SerializeField] private int score = 0;
        [SerializeField] private float speed = 3.0f;
        [SerializeField] private float jumpFactor = 5.0f;

        public TextMeshProUGUI scoreDisplay;
        public SpikeController spikes;
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckInput();
            CheckDirection();
            scoreDisplay.SetText( score.ToString());
        }

        private void CheckDirection()
        {
            if (_rightDir)
            {
                transform.Translate(Vector3.right * (speed * Time.deltaTime));
            }
            else
            {
                transform.Translate(Vector3.left * (speed * Time.deltaTime));
            }
        }

        private void CheckInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rigidbody.velocity = new Vector2(0, jumpFactor);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_rightDir)
            {
                spikes.HideRightSpikes();
                _rightDir = false;
                spikes.GenerateSpike(Spike.Left,1);
            }
            else if (!_rightDir)
            {
                spikes.HideLeftSpikes();
                _rightDir = true;
                spikes.GenerateSpike(Spike.Right,1);
            }

            score++;
        }
    }
}
