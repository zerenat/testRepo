﻿#if !UNITY_EDITOR && UNITY_IOS
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace DigitsNFCToolkit
{
	/// <summary>Class for the native nfc functionality on iOS</summary>
	public class IOSNFC: NativeNFC
	{
		[DllImport("__Internal")]
        private static extern void _nativeNFC_initialize(string gameObjectName);
        [DllImport("__Internal")]
        private static extern bool _nativeNFC_isNFCTagInfoReadSupported();
        [DllImport("__Internal")]
        private static extern bool _nativeNFC_isNDEFReadSupported();
        [DllImport("__Internal")]
        private static extern bool _nativeNFC_isNDEFWriteSupported();
        [DllImport("__Internal")]
        private static extern void _nativeNFC_disable();
		[DllImport("__Internal")]
        private static extern void _nativeNFC_enable();
		[DllImport("__Internal")]
        private static extern void _nativeNFC_requestNDEFWrite(string messageJSON);
		[DllImport("__Internal")]
        private static extern void _nativeNFC_cancelNDEFWriteRequest();

		public override void Initialize()
		{
			_nativeNFC_initialize(gameObject.name);
		}

        public override bool IsNFCTagInfoReadSupported()
        {
            return _nativeNFC_isNFCTagInfoReadSupported();
        }

        public override bool IsNDEFReadSupported()
        {
            return _nativeNFC_isNDEFReadSupported();
        }

        public override bool IsNDEFWriteSupported()
        {
            return _nativeNFC_isNDEFWriteSupported();
        }

		public override void Enable()
		{
			_nativeNFC_enable();
		}

		public override void Disable()
		{
			_nativeNFC_disable();
		}

		public override void RequestNDEFWrite(string messageJSON)
		{
			_nativeNFC_requestNDEFWrite(messageJSON);
		}

		public override void CancelNDEFWriteRequest()
		{
			_nativeNFC_cancelNDEFWriteRequest();
		}
	}
}
#endif