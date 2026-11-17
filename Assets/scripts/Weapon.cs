    using UnityEngine;

    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rb2d;
        [SerializeField]
        private int _rotationSpeed = 100;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            _rb2d.MoveRotation(_rb2d.rotation + _rotationSpeed * Time.fixedDeltaTime);
        }
    }
