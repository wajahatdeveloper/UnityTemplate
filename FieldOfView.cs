using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour {


    public bool Detect = true;
    public Transform DetectedTarget;

    public UnityEvent OnPlayerFound;

    public float RayCastOffSet = 2.0f;
    public float viewRadius;
    public float chaseRadius;
    [Range(0, 360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public float meshResolution;
    public MeshFilter viewMeshFilter;
    protected Mesh viewMesh;
    bool Scream = false;
    Animator m_Animator;
    

    private void OnEnable()
    {
       // StartCoroutine(FindTargetsWithDelay(0.2f));
    }

    private void Start()
    {
        GetRefferences();
        MeshDeclare();
    }


    public  void GetRefferences()
    {

        viewMeshFilter.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
        m_Animator = GetComponent<Animator>();
    }



    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
            DrawFieldOfView();
           
        }
    }

    private void Update()
    {
        FindVisibleTargets();
        DrawFieldOfView();
    }


    void FindVisibleTargets()
    {

       
        Collider[] targetsInRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInRadius.Length; i++)
        {
            Transform target = targetsInRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position + new Vector3(0, RayCastOffSet, 0), dirToTarget, distToTarget, obstacleMask))
                {
                    DetectedTarget = target;
                    Detect = true;

                    if (OnPlayerFound != null)
                    {
                        OnPlayerFound.Invoke();
                    }

                    if(!Scream)
                    m_Animator.CrossFadeInFixedTime("Scream", 0.1f);

                    Scream = true;
                }
               
            }



        }

        if (Detect)
        {
            float distance = Vector3.Distance(transform.position, DetectedTarget.position);


            if (distance >= chaseRadius)
            {
                m_Animator.CrossFadeInFixedTime("Anger", 0.1f);
                DetectedTarget = null;
                Detect = false;
                Scream = false;
            }


        }

    }



    #region MeshDraw
    protected void MeshDeclare()
    {

        if (!viewMeshFilter) return;

        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;


    }

    protected void DrawFieldOfView()
    {

        if (!viewMeshFilter) return;

        if (!Detect)
        {
            viewMeshFilter.gameObject.SetActive(true);

        }
        else
        {
            viewMeshFilter.gameObject.SetActive(false);
            return;
        }


        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAnglesSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAnglesSize * i;
            ViewCastinfo newViewCast = ViewCast(angle);
            viewPoints.Add(newViewCast.point);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];
        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {

            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }

        }

        viewMeshFilter.transform.localPosition = new Vector3(0, 0.35f, 0);

       
        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }

    protected ViewCastinfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngel(globalAngle, true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask))
        {
            return new ViewCastinfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastinfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }


    public Vector3 DirFromAngel(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }


    public struct ViewCastinfo
    {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastinfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
    #endregion


}
