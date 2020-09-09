using UnityEngine;

public static class GameSpeed
{
    private static float factor;

    public static float Factor
    {
        get => factor;
        set
        {
            factor = value;
            Time.timeScale = factor;
            Time.fixedDeltaTime = factor * 0.02f;
        }
    }
}
