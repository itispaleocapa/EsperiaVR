using UnityEngine;

public class Movements : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player;
    public float speed = 3;
    private CharacterController cc;
    void Start()
    {
        cc=player.GetComponent<CharacterController>();
    }

    public void MoveForward()
    {
        cc.SimpleMove(player.transform.forward * speed); 
    }

    public void MoveBackward()
    {
        cc.SimpleMove(-player.transform.forward * speed);
    }

    public void MoveLeft()
    {
        cc.SimpleMove(-player.transform.right * speed);
    }

    public void MoveRight()
    {
        cc.SimpleMove(player.transform.right * speed);
    }
}
