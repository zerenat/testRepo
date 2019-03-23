using UnityEngine;

namespace DigitsNFCToolkit
{
	/// <summary>Access point for the NativeNFC for current platform</summary>
	public class NativeNFCManager: MonoBehaviour
	{
		/// <summary>GameObject name of this class</summary>
		private const string NAME = "NativeNFCManager";

		/// <summary>The singleton instance of NativeNFCManager</summary>
		private static NativeNFCManager instance;

		/// <summary>The NativeNFC instance of current platform</summary>
		private NativeNFC nfc;

		/// <summary>The singleton instance of NativeNFCManager</summary>
		private static NativeNFCManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = GameObject.FindObjectOfType<NativeNFCManager>();
					if(instance == null)
					{
						GameObject gameObject = new GameObject(NAME);
						instance = gameObject.AddComponent<NativeNFCManager>();
					}
				}

				return instance;
			}
		}

		/// <summary>The NativeNFC instance of current platform</summary>
		public static NativeNFC NFC
		{
			get { return Instance.nfc; }
		}

		#region UNITY
		private void Awake()
		{
#if UNITY_EDITOR
			Debug.LogWarning("Native NFC can't be accessed in the Editor");
#elif UNITY_ANDROID
			nfc = gameObject.AddComponent<AndroidNFC>();
			nfc.Initialize();
#elif UNITY_IOS
			nfc = gameObject.AddComponent<IOSNFC>();
			nfc.Initialize();
#else
			Debug.LogWarning("Native NFC is only supported on Android");
#endif
		}

		private void OnDestroy()
		{
			instance = null;
		}
		#endregion

		public static void TryDestroy()
		{
			if(instance != null && instance.gameObject != null)
			{
				Destroy(instance.gameObject);
			}
		}

		/// <summary>Checks if NFC Tag Info Read is supported on this device</summary>
		public static bool IsNFCTagInfoReadSupported()
		{
			NativeNFC nativeNFC = Instance.nfc;
			return nativeNFC.IsNFCTagInfoReadSupported();
		}

		/// <summary>Checks if NDEF Read is supported on this device</summary>
		public static bool IsNDEFReadSupported()
		{
			NativeNFC nativeNFC = Instance.nfc;
			return nativeNFC.IsNDEFReadSupported();
		}

		/// <summary>Checks if NDEF Write is supported on this device</summary>
		public static bool IsNDEFWriteSupported()
		{
			NativeNFC nativeNFC = Instance.nfc;
			return nativeNFC.IsNDEFWriteSupported();
		}

		/// <summary>Enables NFC Reading and Writing</summary>
		public static void Enable()
		{
			NativeNFC nativeNFC = Instance.nfc;
			nativeNFC.Enable();
		}

		/// <summary>Disables NFC Reading and Writing</summary>
		public static void Disable()
		{
			NativeNFC nativeNFC = Instance.nfc;
			nativeNFC.Disable();
		}

		/// <summary>Start a write request for given NDEF Message</summary>
		public static void RequestNDEFWrite(NDEFMessage message)
		{
			NativeNFC nativeNFC = Instance.nfc;
			nativeNFC.RequestNDEFWrite(message.ToJSON().ToString());
		}

		/// <summary>Cancel pending NDEF Message write request (if any)</summary>
		public static void CancelNDEFWriteRequest()
		{
			NativeNFC nativeNFC = Instance.nfc;
			nativeNFC.CancelNDEFWriteRequest();
		}

		/// <summary>Adds given OnNFCTagDetected listener</summary>
		public static void AddNFCTagDetectedListener(OnNFCTagDetected listener)
		{
			NativeNFC nativeNFC = Instance.nfc;
			nativeNFC.NFCTagDetected += listener;
		}

		/// <summary>Removes given OnNFCTagDetected listener</summary>
		public static void RemoveNFCTagDetectedListener(OnNFCTagDetected listener)
		{
			NativeNFC nativeNFC = Instance.nfc;
			nativeNFC.NFCTagDetected -= listener;
		}

		/// <summary>Adds given OnNDEFReadFinished listener</summary>
		public static void AddNDEFReadFinishedListener(OnNDEFReadFinished listener)
		{
			NativeNFC nativeNFC = Instance.nfc;
			nativeNFC.NDEFReadFinished += listener;
		}

		/// <summary>Removes given OnNDEFReadFinished listener</summary>
		public static void RemoveNDEFReadFinishedListener(OnNDEFReadFinished listener)
		{
			NativeNFC nativeNFC = Instance.nfc;
			nativeNFC.NDEFReadFinished -= listener;
		}

		/// <summary>Adds given OnNDEFWriteFinished listener</summary>
		public static void AddNDEFWriteFinishedListener(OnNDEFWriteFinished listener)
		{
			NativeNFC nativeNFC = Instance.nfc;
			nativeNFC.NDEFWriteFinished += listener;
		}

		/// <summary>Adds given OnNDEFWriteFinished listener</summary>
		public static void RemoveNDEFWriteFinishedListener(OnNDEFWriteFinished listener)
		{
			NativeNFC nativeNFC = Instance.nfc;
			nativeNFC.NDEFWriteFinished -= listener;
		}
	}
}
