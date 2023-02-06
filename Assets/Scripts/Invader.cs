using UnityEngine;


public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;

    public float animationTime = 1.0f;
    public System.Action killed;

    private SpriteRenderer _spriteRenderer;
    
    private int animationFrame;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        animationFrame++;

        if( animationFrame >= this.animationSprites.Length)
        {
            animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("laser"))
        {

            this.killed.Invoke();

            this.gameObject.SetActive(false);
        }
    }
    
}
