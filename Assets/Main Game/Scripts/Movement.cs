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
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckInput();
            CheckDirection();
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
                _rightDir = false;
            }
            else if (!_rightDir)
            {
                _rightDir = true;
            }

            score++;
        }
    }
}
