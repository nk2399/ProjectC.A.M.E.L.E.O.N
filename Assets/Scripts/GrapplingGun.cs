using UnityEngine;

public class GrapplingGun : MonoBehaviour
{

    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public LayerMask canBreakWithGrapple;
    public LayerMask ButterflyPowerup;
    public Transform gunTip, cam, player;
    private float maxDistance = 450f;
    private SpringJoint joint;
    public GameObject destroyedVersion;
    public Camera cam2;
    public int addlife ;
    public GameObject Carmel;

    private void Start()
    {
        cam2 = Carmel.GetComponent<CarmelAngain>().cam;
    }
    private void Awake()
    {
        cam2 = Carmel.GetComponent<CarmelAngain>().cam;
        addlife = Carmel.GetComponent<CarmelAngain>().lifecounter;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            StopGrapple();
        }
    }



    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple()
    {

        RaycastHit hit;
         if (Physics.Raycast(cam2.transform.position, cam2.transform.forward, out hit, maxDistance, whatIsGrappleable))
         {
             print("hit");
             grapplePoint = hit.point;
             joint = player.gameObject.AddComponent<SpringJoint>();
             joint.autoConfigureConnectedAnchor = false;
             joint.connectedAnchor = grapplePoint;

             float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

             //The distance grapple will try to keep from grapple point. 
             joint.maxDistance = distanceFromPoint * 0.8f;
             joint.minDistance = distanceFromPoint * 0.25f;

             //Adjust these values to fit your game.
             joint.spring = 4.5f;
             joint.damper = 7f;
             joint.massScale = 4.5f;
         }

         else if(Physics.Raycast(cam2.transform.position, cam2.transform.forward, out hit, maxDistance, canBreakWithGrapple))
         {

             grapplePoint = hit.point;
             joint = player.gameObject.AddComponent<SpringJoint>();
             joint.autoConfigureConnectedAnchor = false;
             joint.connectedAnchor = grapplePoint;

             float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

             //The distance grapple will try to keep from grapple point. 
             joint.maxDistance = distanceFromPoint * 0.8f;
             joint.minDistance = distanceFromPoint * 0.25f;

             //Adjust these values to fit your game.
             joint.spring = 4.5f;
             joint.damper = 7f;
             joint.massScale = 4.5f;


             Destroy(hit.transform.gameObject );
             Instantiate(destroyedVersion, hit.transform.position, hit.transform.rotation);
         }

       else if (Physics.Raycast(cam2.transform.position, cam2.transform.forward, out hit, maxDistance, ButterflyPowerup))
        {
            print("i was hit too");
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint* 0.8f;
            joint.minDistance = distanceFromPoint* 0.25f;

            
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;



            // add life to carmelscript
            Carmel.GetComponent<CarmelAngain>().lifecounter += 10;


            Destroy(hit.transform.gameObject);
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple()
    {
        Destroy(joint);
    }



    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}