using UnityEngine;

namespace SketchMap {
    public class DemoMap : MonoBehaviour {
        void Start() {
            MapStats.Reset();
            Wall.CreateWall(transform, new Rect(-5.25f, -5, .25f, 10), Color.black);
            Wall.CreateWall(transform, new Rect(4.75f, -5, .25f, 10), Color.black);
            Wall.CreateWall(transform, new Rect(-5, 4.75f, 10, .25f), Color.black);
            Wall.CreateWall(transform, new Rect(-5, -5, 10, .25f), Color.black);
            Wall.CreateWall(transform, new Rect(-5, -3, 7.5f, .25f), Color.black);
            Wall.CreateWall(transform, new Rect(-5, -1, 7.5f, .25f), Color.black);
            Wall.CreateWall(transform, new Rect(-2.5f, 1, 5, .25f), Color.black);
            Wall.CreateWall(transform, new Rect(-2.5f, 3, 7.5f, .25f), Color.black);
            Gem.CreateGem(transform, new Vector2(-2, -4), Color.red);
            Gem.CreateGem(transform, new Vector2(0, 2), Color.green);
            Gem.CreateGem(transform, new Vector2(-1, 4), Color.blue);
            Gem.CreateGem(transform, new Vector2(2, 0), Color.yellow);
            Player.CreatePlayer(transform, new Vector2(-1, 0));
        }
    }
}