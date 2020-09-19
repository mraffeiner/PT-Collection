using TMPro;
using UnityEngine;

namespace PTCollection.EndlessRunner
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SeedUI : MonoBehaviour
    {
        private WorldRandomizer randomizer;
        private TextMeshProUGUI textMesh;
        private int currentValue = 0;

        private void Awake()
        {
            randomizer = FindObjectOfType<WorldRandomizer>();
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (currentValue != randomizer.WorldSeed)
            {
                textMesh.text = randomizer.WorldSeed.ToString();
                currentValue = randomizer.WorldSeed;
            }
        }
    }
}
