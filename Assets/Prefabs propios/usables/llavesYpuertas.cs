
using UnityEngine;
using UnityEngine.SceneManagement;

public class llavesYpuertas : MonoBehaviour
{
   
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    [ContextMenu("Open")]
    public void Open()
    {
        animator.SetTrigger("Open");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Gg", LoadSceneMode.Single);
        }
            
    }

    
}
