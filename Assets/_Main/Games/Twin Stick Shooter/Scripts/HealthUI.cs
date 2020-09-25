using UnityEngine;

namespace PTCollection.TwinStickShooter
{
    public class HealthUI : MonoBehaviour
    {
        private PlayerHealth playerHealth;

        private void Awake() => playerHealth = FindObjectOfType<PlayerHealth>();

        private void OnEnable() => playerHealth.OnHealthChanged += UpdateHealth;
        private void Disable() => playerHealth.OnHealthChanged -= UpdateHealth;

        private void UpdateHealth(int newHealth)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i < newHealth)
                    transform.GetChild(i).gameObject.SetActive(true);
                else
                    transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
