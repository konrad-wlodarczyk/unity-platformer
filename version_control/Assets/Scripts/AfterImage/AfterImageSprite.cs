using UnityEngine;

public class AfterImageSprite : MonoBehaviour
{
    [SerializeField]
    private float activeTime = 20f;
    private float timeActivated;
    private float alpha;
    [SerializeField]
    private float alphaSet = 0.8f;
    [SerializeField]
    private float alphaDecay = 15f;

    private Transform player;

    private SpriteRenderer SR;
    private SpriteRenderer playerSR;

    private Color color;

    private void OnEnable()
    {
        if (SR == null)
            SR = GetComponent<SpriteRenderer>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerSR == null)
            playerSR = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        SR.sprite = playerSR.sprite;
        SR.color = new Color(1f, 1f, 1f, alpha);

        transform.position = player.position;
        transform.rotation = player.rotation;

        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha -= alphaDecay * Time.deltaTime;
        color = new Color(0.5f, 0f, 0.5f, alpha);
        SR.color = color;

        if (alpha <= 0f || Time.time >= timeActivated + activeTime)
        {
            AfterImagePool.Instance.AddToPool(gameObject);
        }
    }
}