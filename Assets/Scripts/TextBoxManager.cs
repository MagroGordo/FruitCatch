using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image image; // Reference to the Image component
    public float displayTime = 2.0f; // Time in seconds the image should be displayed

    void Start()
    {
        // Initially hide the image
        image.gameObject.SetActive(false);
    }

    public void ShowImage()
    {
        // Show the image
        image.gameObject.SetActive(true);
        // Call the HideImage method after displayTime seconds
        Invoke("HideImage", displayTime);
    }

    void HideImage()
    {
        // Hide the image
        image.gameObject.SetActive(false);
    }
}
