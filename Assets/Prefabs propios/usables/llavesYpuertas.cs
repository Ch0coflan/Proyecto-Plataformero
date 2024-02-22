
using UnityEngine;
using UnityEngine.SceneManagement;

public class llavesYpuertas : MonoBehaviour
{
    private Menu Menu;
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        Menu.Gg();
    }

    [ContextMenu("Open")]
    public void Open()
    {
        animator.SetTrigger("Open");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Menu.Gg();
        }
            
    }

    
}
