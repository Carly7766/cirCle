using System.Collections;
using UnityEngine;
using UnityEngine.Internal;

public static partial class TransformExtension {

#region SetPosition
    public static Vector3 SetPosition(this Transform transform, float x, float y, float z) {
        transform.position = new Vector3(x, y, z);
        return transform.position;
    }

    public static Vector3 SetPosition(this Transform transform, float x, float y) {
        transform.position = new Vector3(x, y);
        return transform.position;
    }

        public static Vector3 SetPosition(this Transform transform, Vector3 position) {
        transform.position = position;
        return transform.position;
    }
#endregion

#region AddPosition
    public static Vector3 AddPosition(this Transform transform, float x, float y, float z) {
        transform.position += new Vector3(x, y, z);
        return transform.position;
    }

    public static Vector3 AddPosition(this Transform transform, float x, float y) {
        transform.position += new Vector3(x, y);
        return transform.position;
    }

    public static Vector3 AddPosition(this Transform transform,Vector3 position) {
        transform.position += position;
        return transform.position;
    }
#endregion

#region LookAt2D

    public static void LookAt2D(this Transform transform, Transform target, [DefaultValue("Vector2.up")] Vector2 worldUp) {
        transform.rotation = Quaternion.FromToRotation(worldUp, target.position);
    }

    public static void LookAt2D(this Transform transform, Vector2 worldPosition, [DefaultValue("Vector2.up")] Vector2 worldUp) {
        transform.rotation = Quaternion.FromToRotation(worldUp, worldPosition);
    }

    public static void LookAt2D(this Transform transform, Transform target) {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, target.position);
    }

    public static void LookAt2D(this Transform transform, Vector2 worldPosition) {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, worldPosition);
    }
#endregion
}