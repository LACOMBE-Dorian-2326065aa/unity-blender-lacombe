using UnityEngine;
using UnityEngine.InputSystem;

namespace BUT
{
    public class CameraMovementOrbital : MonoBehaviour
    {
        [Header("Références")]
        [SerializeField] private Transform m_Target;
        [Header("Réglages")]
        [SerializeField] private float m_Distance = 5f;
        [SerializeField] private float m_SpeedRotation = 150f;
        [SerializeField] private float m_HeightOffset = 2f;
        [SerializeField] private Vector2 m_RotationXLimits = new Vector2(-30f, 60f);

        private Vector3 m_CurrentRotation;

        private void Start()
        {
            Vector3 angles = transform.rotation.eulerAngles;
            m_CurrentRotation = new Vector3(angles.x, angles.y, 0f);
        }

        public void Rotate(InputAction.CallbackContext _context)
        {
            if (!_context.performed) return;

            Vector2 look = _context.ReadValue<Vector2>();

            m_CurrentRotation.y += look.x * m_SpeedRotation * Time.deltaTime;
            m_CurrentRotation.x -= look.y * m_SpeedRotation * Time.deltaTime;
            m_CurrentRotation.x = Mathf.Clamp(m_CurrentRotation.x, m_RotationXLimits.x, m_RotationXLimits.y);
        }

        private void LateUpdate()
        {
            if (m_Target == null) return;

            Quaternion rotation = Quaternion.Euler(m_CurrentRotation.x, m_CurrentRotation.y, 0f);

            Vector3 pivot = m_Target.position + Vector3.up * m_HeightOffset;

            Vector3 offset = rotation * new Vector3(0, 0, -m_Distance);
            transform.position = pivot + offset;

            transform.LookAt(pivot);
        }
    }
}
