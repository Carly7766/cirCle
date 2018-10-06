using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMonoBehaviour : MonoBehaviour {

	Transform m_Transform;

	// Summary:
	//     The Transform attached to this GameObject.
	public new Transform transform {
		get {
			if(m_Transform == null) {
				m_Transform = GetComponent<Transform>();
			}
			return m_Transform;
		}
	}

	Rigidbody m_Rigidbody;
	// Summary:
	//     The RigidBody attached to this GameObject.
	public new Rigidbody rigidbody {
		get{
			if(m_Rigidbody == null) {
				m_Rigidbody = GetComponent<Rigidbody>();
			}
			return m_Rigidbody;
		}
	}

	Rigidbody2D m_Rigidbody2D;
	// Summary:
	//     The RigidBody2D attached to this GameObject.
	public new Rigidbody2D rigidbody2D {
		get{
			if(m_Rigidbody2D == null) {
				m_Rigidbody2D = GetComponent<Rigidbody2D>();
			}
			return m_Rigidbody2D;
		}
	}


}
