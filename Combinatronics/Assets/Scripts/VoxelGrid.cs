using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VoxelGrid : MonoBehaviour
{
    [SerializeField]
    private Vector3Int GridDimension = new Vector3Int(10, 20, 5);

    private Voxel[,,] _voxels;
    private GameObject _goVoxelPrefab;


    // Start is called before the first frame update
    void Start()
    {
        _goVoxelPrefab = Resources.Load("Prefabs/VoxelCube") as GameObject
        CreateVoxelGrid();


        private void CreateVoxelGrid();

        _voxels = new Voxel[GridDimension.x, GridDimension.y, GridDimension.z];

        for (int x = 0; x < GridDimension.x; x++)
        {
            for (int y = 0; y < GridDimension.y; y++)
            {
                for (int z = 0; z < GridDimension.z; z++)
                {
                    _voxels[x, y, z] = new Voxel(new Vector3Int(x, y, z), _goVoxelPrefab);

                }
            }
        }

        //Dog barry = new Dog("Barry", "Kevins dog");
        //Dog tobias = new Dog("Tobias", "Kevins dog");


        //barry.Bark(3);
        //tobias.Bark(6);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleRaycast();

        }

        private void HandleRaycast()
        {
            Debug.Log("Clicked");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Transform objectHit = hit.transform;

                if (objectHit.CompareTag("Voxel"))
                {
                    objectHit.gameObject.GetComponent<VoxelTrigger>().TriggerVoxel.Status = VoxelState.Dead;


                }

            }
        }

    }
