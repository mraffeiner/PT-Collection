using UnityEngine;

namespace PTCollection.TwinStickShooter
{
    [RequireComponent(typeof(Collider2D))]
    public class RevealEnemies : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Enemy")
                other.GetComponent<Enemy>().Reveal();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Enemy")
                other.GetComponent<Enemy>().Hide();
        }
    }
}
