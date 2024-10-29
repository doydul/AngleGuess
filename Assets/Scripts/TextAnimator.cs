using UnityEngine;
using TMPro;

public class TextAnimator : MonoBehaviour {
    
    public TMP_Text element;
    
    public async Awaitable AnimateText(string text) {
        float duration = text.Length * 0.05f;
        float startTime = Time.time;
        while (Time.time - startTime < duration) {
            float t = (Time.time - startTime) / duration;
            // float x = t < 0.5f ? 8 * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 4) / 2;
            float x = t < 0.5f ? 2 * t * t : 1 - Mathf.Pow(-2 * t + 2, 2) / 2;
            int charCount = (int)(text.Length * x);
            element.text = text.Substring(0, charCount);
            await Awaitable.NextFrameAsync();
        }
        element.text = text;
    }
    
    public void SetText(string text) => element.text = text;
}