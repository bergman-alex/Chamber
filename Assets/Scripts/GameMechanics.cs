using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    private float timer = 0f;
	private float timePerRoom = 10f;	// amount of time between room layout swaps
	private float gameStartDelay = 3f;	// delay from starting the game to first room spawn
	private int numberOfRooms = 10;		// total amount of room layouts
	public  int roomCounter = 0; 		// total amount of rooms visited
	private int lastRoomNumber;			// index of the last room visited

    [SerializeField] private GameObject turretPrefab = null;
    [SerializeField] private GameObject shurikenPrefab = null;
    [SerializeField] private GameObject spikesPrefab = null;
    [SerializeField] private GameObject swordPrefab = null;
    [SerializeField] private GameObject player = null;

    void Start()
    {
    	//PlayerPrefs.DeleteAll(); // Reset highscore
        lastRoomNumber = 0;
        InvokeRepeating("RoomCycle", gameStartDelay, timePerRoom);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f) // spikes randomizer
        {
            if (Random.Range(0f, 100f) < roomCounter)
            {
                SpawnObstacle(spikesPrefab, player.transform.position.x, player.transform.position.y, 0);
            }
            timer = 0f;
        }
    }

    void RoomCycle()
    {
    	DestroyObstacles();	// clear the room before spawning the next one
    	SpawnNewRoom();
        ++roomCounter;
    }

    void DestroyObstacles()	// destroys all obstacles and coins
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in obstacles)
        {
            GameObject.Destroy(obstacle);
        }
    }

    void SpawnObstacle(GameObject prefab, float x, float y, float rotation)
    {
    	Instantiate(prefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, rotation));
    }

    void SpawnNewRoom()
    {
    	int newRoomNumber = Random.Range(1, numberOfRooms + 1);	// randomizes the room to spawn

    	if (newRoomNumber == lastRoomNumber) // prevent the same room from spawning twice in a row
    	{
    		SpawnNewRoom();
    	}
    	else
    	{
    		SpawnRoom(newRoomNumber);
    		lastRoomNumber = newRoomNumber;
    	}
    }

    void SpawnRoom(int roomNumber)
    {
    	switch(roomNumber)
    	{
    		case 1: // two turrets
    			player.transform.position = new Vector3(0, 3.5f, 0);
        		SpawnObstacle(turretPrefab, -4f, 0, Random.Range(0, 360f));
        		SpawnObstacle(turretPrefab, 4f, 0, Random.Range(0, 360f));
        		break;

        	case 2: // three turrets along the top wall
        		player.transform.position = new Vector3(0, 0, 0);
        		SpawnObstacle(turretPrefab, -5.5f, 1.5f, Random.Range(0, 360f));
        		SpawnObstacle(turretPrefab, 0, 2.5f, Random.Range(0, 360f));
        		SpawnObstacle(turretPrefab, 5.5f, 1.5f, Random.Range(0, 360f));
        		break;

        	case 3: // four shurikens and one turret
        		player.transform.position = new Vector3(4.5f, 0, 0);
        		SpawnObstacle(shurikenPrefab, -6.5f, 2.5f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, -6.5f, -2.5f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, -3.5f, 2.5f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, -3.5f, -2.5f, Random.Range(0, 360f));
        		SpawnObstacle(turretPrefab, 0f, 2.5f, Random.Range(0, 360f));
        		break;

        	case 4: // two swords and three shurikens
        		player.transform.position = new Vector3(0, -3.5f, 0);
        		SpawnObstacle(swordPrefab, -4f, 0, Random.Range(-120f, 60f)); // rotation due to proximity to player spawn
        		SpawnObstacle(swordPrefab, 4f, 0, Random.Range(-60f, 120f));
        		SpawnObstacle(shurikenPrefab, -7f, 3.5f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, 7f, 3.5f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, 0, 3.5f, Random.Range(0, 360f));
        		break;

        	case 5: // one sword with a turret on either side
        		player.transform.position = new Vector3(0, -3.5f, 0);
        		SpawnObstacle(swordPrefab, 0, 0, 0);
        		SpawnObstacle(turretPrefab, -7f, 0, Random.Range(0, 360f));
        		SpawnObstacle(turretPrefab, 7f, 0, Random.Range(0, 360f));
        		break;

        	case 6: // four turrets along the right wall
        		player.transform.position = new Vector3(-6.5f, 0, 0);
        		SpawnObstacle(turretPrefab, 6.5f, 2.25f, Random.Range(0, 360f));
        		SpawnObstacle(turretPrefab, 6.5f, 0.75f, Random.Range(0, 360f));
        		SpawnObstacle(turretPrefab, 6.5f, -0.75f, Random.Range(0, 360f));
        		SpawnObstacle(turretPrefab, 6.5f, -2.25f, Random.Range(0, 360f));
        		break;

        	case 7: // six shurikens
        		player.transform.position = new Vector3(-6.5f, 0, 0);
        		SpawnObstacle(shurikenPrefab, 6.5f, 3f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, 6.5f, 2f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, 6.5f, 1f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, 6.5f, -1f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, 6.5f, -2f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, 6.5f, -3f, Random.Range(0, 360f));
        		break;

        	case 8: // three swords and two shurikens
        		player.transform.position = new Vector3(0, -3.5f, 0);
        		SpawnObstacle(swordPrefab, -4f, 0f, Random.Range(-120f, 60f));
        		SpawnObstacle(swordPrefab, 0, 0, 0);
        		SpawnObstacle(swordPrefab, 4f, 0f, Random.Range(-60f, 120f));
        		SpawnObstacle(shurikenPrefab, -7f, 3.5f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, 7f, 3.5f, Random.Range(0, 360f));
        		break;

        	case 9: // one turret and two shurikens
        		player.transform.position = new Vector3(-6.5f, 0, 0);
        		SpawnObstacle(shurikenPrefab, 6.5f, 3.5f, Random.Range(0, 360f));
        		SpawnObstacle(shurikenPrefab, 6.5f, -3.5f, Random.Range(0, 360f));
        		SpawnObstacle(turretPrefab, 0, 0, Random.Range(0, 360f));
        		break;

        	case 10: // one sword, one turret, one shuriken
        		player.transform.position = new Vector3(0, 0, 0);
        		SpawnObstacle(swordPrefab, -4f, 0, Random.Range(-180f, 0));
        		SpawnObstacle(shurikenPrefab, -6f, 0, Random.Range(0, 360f));
        		SpawnObstacle(turretPrefab, 6f, 0, Random.Range(0, 360f));
        		break;
    	}
    }
}
