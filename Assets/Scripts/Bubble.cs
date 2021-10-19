using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    private BubbleManager _bubbleManager;
    private void Start()
    {
        _bubbleManager = GetComponentInParent<BubbleManager>();
    }

    private void OnMouseDown()
    {
        _bubbleManager.TriggerEvent();
        DestroyBubble();
    }

    private void DestroyBubble()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}