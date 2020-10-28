using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public Player player;
    public Board board;
    public AnimationManager animationManager;

    public List<IUpdate> updaters = new List<IUpdate>();
    // Start is called before the first frame update
    void Start()
    {
        animationManager = new AnimationManager();
        updaters.Add(animationManager);
        player = new Player();
        updaters.Add(player);
        board = new Board();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var updater in updaters)
        {
            updater.Update();
        }
    }

    public void Draw()
    {
        board.LocalPlayerDraw();
    }
}
