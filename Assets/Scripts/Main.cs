using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public Player player;
    public Board board;
    // Start is called before the first frame update
    void Start()
    {
        player = new Player();

        board = new Board();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Draw()
    {
        board.Draw();
    }
}
