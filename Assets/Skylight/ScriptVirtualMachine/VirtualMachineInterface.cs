using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Skylight
{
	public class NewBehaviourScript
	{

		ScriptVirtualMachine scriptVirtualMachine;
		// ---- Host API ------------------------------------------------------------------------------

		/******************************************************************************************
		*
		*   HAPI_PrintString ()
		*
		*   This is a simple host API function that scripts can call to print strings a specified
		*   number of times, as well as receive an arbitrary return value.
		*/

		void HAPI_PrintString (int iThreadIndex)
		{
			// Read in the parameters

			string pstrString = scriptVirtualMachine.XS_GetParamAsString (iThreadIndex, 0);
			int iCount = scriptVirtualMachine.XS_GetParamAsInt (iThreadIndex, 1);

			// Print the specified string the specified number of times (print everything with a
			// leading tab to separate it from the text printed by the host)

			for (int iCurrString = 0; iCurrString < iCount; ++iCurrString)
				Debug.Log ("\t" + pstrString + "\n");

			// Return a value

			scriptVirtualMachine.XS_ReturnString (iThreadIndex, 2, "This is a return value.");
		}

		// ---- Main ----------------------------------------------------------------------------------

		int Start ()
		{
			// Print the logo

			Debug.Log ("XVM Final\n");
			Debug.Log ("XtremeScript Virtual Machine\n");
			Debug.Log ("Written by Alex Varanese\n");
			Debug.Log ("\n");

			// Initialize the runtime environment

			scriptVirtualMachine.XS_Init ();

			// Declare the thread indices

			int iThreadIndex = 0;

			// An error code

			int iErrorCode;

			// Load the demo script

			iErrorCode = scriptVirtualMachine.XS_LoadScript ("SCRIPT", ref iThreadIndex, ScriptVirtualMachine.XS_THREAD_PRIORITY_USER);

			// Check for an error

			if (iErrorCode != ScriptVirtualMachine.XS_LOAD_OK) {
				// Print the error based on the code

				Debug.Log ("Error: ");

				switch (iErrorCode) {
				case ScriptVirtualMachine.XS_LOAD_ERROR_FILE_IO:
					Debug.Log ("File I/O error");
					break;

				case ScriptVirtualMachine.XS_LOAD_ERROR_INVALID_XSE:
					Debug.Log ("Invalid .XSE file");
					break;

				case ScriptVirtualMachine.XS_LOAD_ERROR_UNSUPPORTED_VERS:
					Debug.Log ("Unsupported .XSE version");
					break;

				case ScriptVirtualMachine.XS_LOAD_ERROR_OUT_OF_MEMORY:
					Debug.Log ("Out of memory");
					break;

				case ScriptVirtualMachine.XS_LOAD_ERROR_OUT_OF_THREADS:
					Debug.Log ("Out of threads");
					break;
				}

				Debug.Log (".\n");
				return 0;
			} else {
				// Print a success message

				Debug.Log ("Script loaded successfully.\n");
			}
			Debug.Log ("\n");

			// Register the string printing function

			scriptVirtualMachine.XS_RegisterHostAPIFunc (ScriptVirtualMachine.XS_GLOBAL_FUNC, "PrintString", HAPI_PrintString);

			// Start up the script

			scriptVirtualMachine.XS_StartScript (iThreadIndex);

			// Call a script function

			Debug.Log ("Calling DoStuff () asynchronously:\n");
			Debug.Log ("\n");

			scriptVirtualMachine.XS_CallScriptFunc (iThreadIndex, "DoStuff");

			// Get the return value and print it

			float fPi = scriptVirtualMachine.XS_GetReturnValueAsFloat (iThreadIndex);
			Debug.Log ("\nReturn value received from script: " + fPi + "\n");
			Debug.Log ("\n");

			// Invoke a function and run the host alongside it

			Debug.Log ("Invoking InvokeLoop () (Press any key to stop):\n");
			Debug.Log ("\n");

			scriptVirtualMachine.XS_InvokeScriptFunc (iThreadIndex, "InvokeLoop");

			while (InputService.Instance ().GetInput (KeyMap.A))
				scriptVirtualMachine.XS_RunScripts (50);

			// Free resources and perform general cleanup

			scriptVirtualMachine.XS_ShutDown ();

			return 0;
		}

	}

}
