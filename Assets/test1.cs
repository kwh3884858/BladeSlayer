using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skylight;
public class test1 : MonoBehaviour
{

	VirtualMachineInterface virtualMachineInterface;


	void Start ()
	{
		virtualMachineInterface = new VirtualMachineInterface ();
		virtualMachineInterface.Start ();
	}

	private void Update ()
	{
		virtualMachineInterface.Update ();
	}
}
