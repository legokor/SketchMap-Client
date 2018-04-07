using UnityEngine;

namespace SketchMap {
    public class DemoMap : MonoBehaviour {
        void Start() {
            MapStats.Reset();
            Wall.CreateWall(transform, new Vector2(-5, -5), new Vector2(5, -5), Color.black);
            Wall.CreateWall(transform, new Vector2(-5, 5), new Vector2(5, 5), Color.black);
            Wall.CreateWall(transform, new Vector2(5, 5), new Vector2(5, -5), Color.black);
            Wall.CreateWall(transform, new Vector2(-5, 5), new Vector2(-5, -5), Color.black);
            Wall.CreateWall(transform, new Vector2(-5, 0), new Vector2(2, -2), Color.black);
            Wall.CreateWall(transform, new Vector2(-5, 0), new Vector2(2, 2), Color.black);
            Wall.CreateWall(transform, new Vector2(-5, 2), new Vector2(2, 4), Color.black);
            Gem.CreateGem(transform, new Vector2(-2, -4), Color.red);
            Gem.CreateGem(transform, new Vector2(0, 2), Color.green);
            Gem.CreateGem(transform, new Vector2(-1, 4), Color.blue);
            Gem.CreateGem(transform, new Vector2(2, 0), Color.yellow);
            Player.CreatePlayer(transform, new Vector2(-1, 0));
        }
    }
}