using UnityEngine;
using UnityEngine.U2D;

public class EnemyMovement : MonoBehaviour
{


    public float speed = 1.0f;     
    public float moveDistance = 8.0f;
    private SpriteRenderer sprite;
    private Vector2 startPos;    
    private Vector2 endPos;        
    private int direction = 1;     

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector2.right * moveDistance;
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;

    }

    // Update is called once per frame
    void Update()
    {
     
        transform.Translate(direction * speed * Time.deltaTime * Vector2.right);

       
        if (transform.position.x >= endPos.x || transform.position.x <= startPos.x)
        {
            direction *= -1;
            if (sprite.flipX == false)
                sprite.flipX = true;
            else 
                sprite.flipX = false;

        }
    }
}
