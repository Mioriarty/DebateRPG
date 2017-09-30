using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class BattleStarter {

	private static Vector3 oldPlayerPos;
	private static Vector3[] oldEnemyPos;
	private static string arenaName;
	private static GameObject[] objToRespawn;

	public static void initBattle(Player player, GameObject[] enemies, string arenaTitle = "Default"){
		if (arenaName == null) {
			arenaName = arenaTitle;

			// Instatiate Arena
			GameObject prefab = Resources.Load<GameObject> ("Prefabs/Arenas/"+arenaName);
			GameObject arena = GameObject.Instantiate (prefab);

			// Disable all danerous objects
			GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
			player.prepareForBattle ();
			camera.GetComponent<CameraController> ().enabled = false;

			// Position all GameObjects
			camera.transform.position = Utils.vec2To3 (Utils.vec3To2 (arena.transform.position), camera.transform.position.z);
			int enemyPtr = 0;

			foreach (Transform spawn in arena.transform) {
				if (spawn.tag == "Spawnpoint") {
					switch (spawn.name) {
					case "Player":
						player.transform.position = spawn.position;
						break;
					case "Enemy":
						if (enemyPtr < enemies.Length)
							enemies [enemyPtr++].transform.position = spawn.position;
						break;
					}

				}
			}

		}


	}
}
