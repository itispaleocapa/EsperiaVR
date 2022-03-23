using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class combineMeshes : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        /* Quaternion oldRot = transform.rotation;
         Vector3 oldPos = transform.position;

         transform.rotation = Quaternion.identity;
         transform.position = Vector3.zero;

         MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();
         Debug.Log(name + " is combining " + filters.Length + " meshes!");

         Mesh finalMesh = new Mesh();

         CombineInstance[] combiners = new CombineInstance[filters.Length];

         for(int i=0; i<filters.Length; i++)
         {
             if (filters[i].transform == transform)
                 continue;
             combiners[i].subMeshIndex = 0;
             combiners[i].mesh = filters[i].sharedMesh;
             combiners[i].transform = filters[i].transform.localToWorldMatrix;
         }
         finalMesh.CombineMeshes(combiners);

         GetComponent<MeshFilter>().sharedMesh = finalMesh;

         transform.rotation = oldRot;
         transform.position = oldPos;

         for(int i=0; i<transform.childCount; i++)
         {
             transform.GetChild(i).gameObject.SetActive(false);
         }*/

        // ALL our children (und us) 
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>(false);
        // ALL the meshes in our children (just u big list) 
        List<Material> materials = new List<Material>();
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>(false); // <-- you on optimi7e this 
        foreach (MeshRenderer renderer in renderers)
        {
            if (renderer.transform == transform) continue;
            Material[] localMats = renderer.sharedMaterials;
            foreach (Material localMat in localMats)
                if (!materials.Contains(localMat))
                    materials.Add(localMat);
        }
        // Each material will have a mesh for it. 
        List<Mesh> submeshes = new List<Mesh>();
        foreach (Material material in materials)
        {
            // •ake rr combiner for each ()h)meh that is mapped to the right material.. 
            List<CombineInstance> combiners = new List<CombineInstance>();
            foreach (MeshFilter filter in filters)
            {
                // The fitter doesn't know whut muteriuts ure involved, get the renderer. 
                MeshRenderer renderer = filter.GetComponent<MeshRenderer>(); // < (Easy optimization is possible here, give it a try!) 
                if (renderer == null)
                {
                    Debug.LogError(filter.name + " has no meshRenderer");
                    continue;
                }
                // Ipt' toto if their materials ore the one we want right now. 
                Material[] localMaterials = renderer.sharedMaterials;
                for (int materialIndex = 0; materialIndex < localMaterials.Length; materialIndex++)
                {
                    if (localMaterials[materialIndex] != material) continue;
                    // This_sNtmech i.s the material. were Looking for right now. 
                    CombineInstance ci = new CombineInstance();
                    ci.mesh = filter.sharedMesh;
                    ci.subMeshIndex = materialIndex;
                    ci.transform = Matrix4x4.identity;
                    combiners.Add(ci);
                }
            }
            // Flatten into a single mesh. 
            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combiners.ToArray(), true);
            submeshes.Add(mesh);
        }
        // the final mesh: combine aLL the material specific meshes as independent submeshes.
        List<CombineInstance> finalCombiners = new List<CombineInstance>();
        foreach (Mesh mesh in submeshes)
        {
            CombineInstance ci = new CombineInstance();
            ci.mesh = mesh; ci.subMeshIndex = 0;
            ci.transform = Matrix4x4.identity;
            finalCombiners.Add(ci);
        }
        Mesh finalMesh = new Mesh();
        finalMesh.CombineMeshes(finalCombiners.ToArray(), false);
        GetComponent<MeshFilter>().sharedMesh = finalMesh;
        Debug.Log("Final mesh has " + submeshes.Count + " materials.");
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

    }

}
