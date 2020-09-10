using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public TextAsset textAsset;

    public Player player;
    public Board board;
    // Start is called before the first frame update
    void Start()
    {
        board = new Board();
        player = new Player();


      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
