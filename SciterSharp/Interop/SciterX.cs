﻿// Copyright 2015 Ramon F. Mendes
//
// This file is part of SciterSharp.
// 
// SciterSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// SciterSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with SciterSharp.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SciterSharp.Interop
{
	public static class SciterX
	{
		private static ISciterAPI? _api = null;

		public static ISciterAPI GetSicterAPI()
		{
			if(_api==null)
            {
                _api = (ISciterAPI)Marshal.PtrToStructure(IntPtr.Size == 8 ? SciterAPI64() : SciterAPI32(), typeof(ISciterAPI));

                // from time to time, Sciter changes its ABI
                // here we test the minimum Sciter version this library is compatible with
                uint major = _api.Value.SciterVersion(1);
                uint minor = _api.Value.SciterVersion(0);
                Debug.Assert(major == 0x00030003);
                Debug.Assert(minor >= 0x00000006);
                Debug.Assert(_api.Value.version==0);
            }

            return _api.Value;
		}

		[DllImport("sciter32", EntryPoint = "SciterAPI")]
		private static extern IntPtr SciterAPI32();

		[DllImport("sciter64", EntryPoint = "SciterAPI")]
		private static extern IntPtr SciterAPI64();


		[StructLayout(LayoutKind.Sequential)]
		public struct ISciterAPI
		{
			public int version;
			public FPTR_SciterClassName SciterClassName;
			public FPTR_SciterVersion SciterVersion;
			public FPTR_SciterDataReady SciterDataReady;
			public FPTR_SciterDataReadyAsync SciterDataReadyAsync;
#if WIN32
			public FPTR_SciterProc SciterProc;
			public FPTR_SciterProcND SciterProcND;
#endif
			public FPTR_SciterLoadFile SciterLoadFile;
			public FPTR_SciterLoadHtml SciterLoadHtml;
			public FPTR_SciterSetCallback SciterSetCallback;
			public FPTR_SciterSetMasterCSS SciterSetMasterCSS;
			public FPTR_SciterAppendMasterCSS SciterAppendMasterCSS;
			public FPTR_SciterSetCSS SciterSetCSS;
			public FPTR_SciterSetMediaType SciterSetMediaType;
			public FPTR_SciterSetMediaVars SciterSetMediaVars;
			public FPTR_SciterGetMinWidth SciterGetMinWidth;
			public FPTR_SciterGetMinHeight SciterGetMinHeight;
			public FPTR_SciterCall SciterCall;
			public FPTR_SciterEval SciterEval;
			public FPTR_SciterUpdateWindow SciterUpdateWindow;
#if WIN32
			public FPTR_SciterTranslateMessage SciterTranslateMessage;
#endif
			public FPTR_SciterSetOption SciterSetOption;
			public FPTR_SciterGetPPI SciterGetPPI;
			public FPTR_SciterGetViewExpando SciterGetViewExpando;
#if WIN32
			public FPTR_SciterRenderD2D SciterRenderD2D;
			public FPTR_SciterD2DFactory SciterD2DFactory;
			public FPTR_SciterDWFactory SciterDWFactory;
#endif
			public FPTR_SciterGraphicsCaps SciterGraphicsCaps;
			public FPTR_SciterSetHomeURL SciterSetHomeURL;
#if OSX
			public FPTR_SciterCreateNSView SciterCreateNSView;
#endif
			public FPTR_SciterCreateWindow SciterCreateWindow;
			public FPTR_SciterSetupDebugOutput SciterSetupDebugOutput;

			// DOM Element API 
			public FPTR_Sciter_UseElement Sciter_UseElement;
			public FPTR_Sciter_UnuseElement Sciter_UnuseElement;
			public FPTR_SciterGetRootElement SciterGetRootElement;
			public FPTR_SciterGetFocusElement SciterGetFocusElement;
			public FPTR_SciterFindElement SciterFindElement;
			public FPTR_SciterGetChildrenCount SciterGetChildrenCount;
			public FPTR_SciterGetNthChild SciterGetNthChild;
			public FPTR_SciterGetParentElement SciterGetParentElement;
			public FPTR_SciterGetElementHtmlCB SciterGetElementHtmlCB;
			public FPTR_SciterGetElementTextCB SciterGetElementTextCB;
			public FPTR_SciterSetElementText SciterSetElementText;
			public FPTR_SciterGetAttributeCount SciterGetAttributeCount;
			public FPTR_SciterGetNthAttributeNameCB SciterGetNthAttributeNameCB;
			public FPTR_SciterGetNthAttributeValueCB SciterGetNthAttributeValueCB;
			public FPTR_SciterGetAttributeByNameCB SciterGetAttributeByNameCB;
			public FPTR_SciterSetAttributeByName SciterSetAttributeByName;
			public FPTR_SciterClearAttributes SciterClearAttributes;
			public FPTR_SciterGetElementIndex SciterGetElementIndex;
			public FPTR_SciterGetElementType SciterGetElementType;
			public FPTR_SciterGetElementTypeCB SciterGetElementTypeCB;
			public FPTR_SciterGetStyleAttributeCB SciterGetStyleAttributeCB;
			public FPTR_SciterSetStyleAttribute SciterSetStyleAttribute;
			public FPTR_SciterGetElementLocation SciterGetElementLocation;
			public FPTR_SciterScrollToView SciterScrollToView;
			public FPTR_SciterUpdateElement SciterUpdateElement;
			public FPTR_SciterRefreshElementArea SciterRefreshElementArea;
			public FPTR_SciterSetCapture SciterSetCapture;
			public FPTR_SciterReleaseCapture SciterReleaseCapture;
			public FPTR_SciterGetElementHwnd SciterGetElementHwnd;
			public FPTR_SciterCombineURL SciterCombineURL;
			public FPTR_SciterSelectElements SciterSelectElements;
			public FPTR_SciterSelectElementsW SciterSelectElementsW;
			public FPTR_SciterSelectParent SciterSelectParent;
			public FPTR_SciterSelectParentW SciterSelectParentW;
			public FPTR_SciterSetElementHtml SciterSetElementHtml;
			public FPTR_SciterGetElementUID SciterGetElementUID;
			public FPTR_SciterGetElementByUID SciterGetElementByUID;
			public FPTR_SciterShowPopup SciterShowPopup;
			public FPTR_SciterShowPopupAt SciterShowPopupAt;
			public FPTR_SciterHidePopup SciterHidePopup;
			public FPTR_SciterGetElementState SciterGetElementState;
			public FPTR_SciterSetElementState SciterSetElementState;
			public FPTR_SciterCreateElement SciterCreateElement;
			public FPTR_SciterCloneElement SciterCloneElement;
			public FPTR_SciterInsertElement SciterInsertElement;
			public FPTR_SciterDetachElement SciterDetachElement;
			public FPTR_SciterDeleteElement SciterDeleteElement;
			public FPTR_SciterSetTimer SciterSetTimer;
			public FPTR_SciterDetachEventHandler SciterDetachEventHandler;
			public FPTR_SciterAttachEventHandler SciterAttachEventHandler;
			public FPTR_SciterWindowAttachEventHandler SciterWindowAttachEventHandler;
			public FPTR_SciterWindowDetachEventHandler SciterWindowDetachEventHandler;
			public FPTR_SciterSendEvent SciterSendEvent;
			public FPTR_SciterPostEvent SciterPostEvent;
			public FPTR_SciterCallBehaviorMethod SciterCallBehaviorMethod;
			public FPTR_SciterRequestElementData SciterRequestElementData;
			public FPTR_SciterHttpRequest SciterHttpRequest;
			public FPTR_SciterGetScrollInfo SciterGetScrollInfo;
			public FPTR_SciterSetScrollPos SciterSetScrollPos;
			public FPTR_SciterGetElementIntrinsicWidths SciterGetElementIntrinsicWidths;
			public FPTR_SciterGetElementIntrinsicHeight SciterGetElementIntrinsicHeight;
			public FPTR_SciterIsElementVisible SciterIsElementVisible;
			public FPTR_SciterIsElementEnabled SciterIsElementEnabled;
			public FPTR_SciterSortElements SciterSortElements;
			public FPTR_SciterSwapElements SciterSwapElements;
			public FPTR_SciterTraverseUIEvent SciterTraverseUIEvent;
			public FPTR_SciterCallScriptingMethod SciterCallScriptingMethod;
			public FPTR_SciterCallScriptingFunction SciterCallScriptingFunction;
			public FPTR_SciterEvalElementScript SciterEvalElementScript;
			public FPTR_SciterAttachHwndToElement SciterAttachHwndToElement;
			public FPTR_SciterControlGetType SciterControlGetType;
			public FPTR_SciterGetValue SciterGetValue;
			public FPTR_SciterSetValue SciterSetValue;
			public FPTR_SciterGetExpando SciterGetExpando;
			public FPTR_SciterGetObject SciterGetObject;
			public FPTR_SciterGetElementNamespace SciterGetElementNamespace;
			public FPTR_SciterGetHighlightedElement SciterGetHighlightedElement;
			public FPTR_SciterSetHighlightedElement SciterSetHighlightedElement;

			// DOM Node API 
			public FPTR_SciterNodeAddRef SciterNodeAddRef;
			public FPTR_SciterNodeRelease SciterNodeRelease;
			public FPTR_SciterNodeCastFromElement SciterNodeCastFromElement;
			public FPTR_SciterNodeCastToElement SciterNodeCastToElement;
			public FPTR_SciterNodeFirstChild SciterNodeFirstChild;
			public FPTR_SciterNodeLastChild SciterNodeLastChild;
			public FPTR_SciterNodeNextSibling SciterNodeNextSibling;
			public FPTR_SciterNodePrevSibling SciterNodePrevSibling;
			public FPTR_SciterNodeParent SciterNodeParent;
			public FPTR_SciterNodeNthChild SciterNodeNthChild;
			public FPTR_SciterNodeChildrenCount SciterNodeChildrenCount;
			public FPTR_SciterNodeType SciterNodeType;
			public FPTR_SciterNodeGetText SciterNodeGetText;
			public FPTR_SciterNodeSetText SciterNodeSetText;
			public FPTR_SciterNodeInsert SciterNodeInsert;
			public FPTR_SciterNodeRemove SciterNodeRemove;
			public FPTR_SciterCreateTextNode SciterCreateTextNode;
			public FPTR_SciterCreateCommentNode SciterCreateCommentNode;

			// Value API 
			public FPTR_ValueInit ValueInit;
			public FPTR_ValueClear ValueClear;
			public FPTR_ValueCompare ValueCompare;
			public FPTR_ValueCopy ValueCopy;
			public FPTR_ValueIsolate ValueIsolate;
			public FPTR_ValueType ValueType;
			public FPTR_ValueStringData ValueStringData;
			public FPTR_ValueStringDataSet ValueStringDataSet;
			public FPTR_ValueIntData ValueIntData;
			public FPTR_ValueIntDataSet ValueIntDataSet;
			public FPTR_ValueInt64Data ValueInt64Data;
			public FPTR_ValueInt64DataSet ValueInt64DataSet;
			public FPTR_ValueFloatData ValueFloatData;
			public FPTR_ValueFloatDataSet ValueFloatDataSet;
			public FPTR_ValueBinaryData ValueBinaryData;
			public FPTR_ValueBinaryDataSet ValueBinaryDataSet;
            public FPTR_ValueElementsCount ValueElementsCount;
			public FPTR_ValueNthElementValue ValueNthElementValue;
			public FPTR_ValueNthElementValueSet ValueNthElementValueSet;
			public FPTR_ValueNthElementKey ValueNthElementKey;
			public FPTR_ValueEnumElements ValueEnumElements;
			public FPTR_ValueSetValueToKey ValueSetValueToKey;
            public FPTR_ValueGetValueOfKey ValueGetValueOfKey;
			public FPTR_ValueToString ValueToString;
			public FPTR_ValueFromString ValueFromString;
			public FPTR_ValueInvoke ValueInvoke;
			public FPTR_ValueNativeFunctorSet ValueNativeFunctorSet;
			public FPTR_ValueIsNativeFunctor ValueIsNativeFunctor;

			// tiscript VM API
			public FPTR_TIScriptAPI TIScriptAPI;
			public FPTR_SciterGetVM SciterGetVM;

			public FPTR_Sciter_v2V Sciter_v2V;
			public FPTR_Sciter_V2v Sciter_V2v;

			public FPTR_SciterOpenArchive SciterOpenArchive;
            public FPTR_SciterGetArchiveItem SciterGetArchiveItem;
            public FPTR_SciterCloseArchive SciterCloseArchive;

			public FPTR_SciterFireEvent SciterFireEvent;

			public FPTR_SciterGetCallbackParam SciterGetCallbackParam;
            public FPTR_SciterPostCallback SciterPostCallback;


			// LPCWSTR	function() SciterClassName;
			[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
			public delegate IntPtr FPTR_SciterClassName();// use Marshal.PtrToStringUni(returned IntPtr) to get the actual string
			// UINT	function(BOOL major) SciterVersion;
			public delegate uint FPTR_SciterVersion(int major);
			// BOOL	function(HWINDOW hwnd, LPCWSTR uri, LPCBYTE data, UINT dataLength) SciterDataReady;
			public delegate bool FPTR_SciterDataReady(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)]string uri, byte[] data, uint dataLength);
			// BOOL	function(HWINDOW hwnd, LPCWSTR uri, LPCBYTE data, UINT dataLength, LPVOID requestId) SciterDataReadyAsync;
			public delegate bool FPTR_SciterDataReadyAsync(IntPtr hwnd, string uri, byte[] data, uint dataLength, IntPtr requestId);
#if WIN32
			// LRESULT	function(HWINDOW hwnd, UINT msg, WPARAM wParam, LPARAM lParam) SciterProc;
			public delegate IntPtr FPTR_SciterProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
			// LRESULT	function(HWINDOW hwnd, UINT msg, WPARAM wParam, LPARAM lParam, BOOL* pbHandled) SciterProcND;
			public delegate IntPtr FPTR_SciterProcND(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool pbHandled);
#endif
			// BOOL	function(HWINDOW hWndSciter, LPCWSTR filename) SciterLoadFile;
			public delegate bool FPTR_SciterLoadFile(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)]string filename);
			// BOOL function(HWINDOW hWndSciter, LPCBYTE html, UINT htmlSize, LPCWSTR baseUrl) SciterLoadHtml;
			public delegate bool FPTR_SciterLoadHtml(IntPtr hwnd, byte[] html, uint htmlSize, string baseUrl);
			// VOID	function(HWINDOW hWndSciter, LPSciterHostCallback cb, LPVOID cbParam) SciterSetCallback;
			public delegate void FPTR_SciterSetCallback(IntPtr hwnd, IntPtr cb, IntPtr param);// TODO
			// BOOL	function(LPCBYTE utf8, UINT numBytes) SciterSetMasterCSS;
			public delegate bool FPTR_SciterSetMasterCSS(byte[] utf8, uint numBytes);
			// BOOL	function(LPCBYTE utf8, UINT numBytes) SciterAppendMasterCSS;
			public delegate bool FPTR_SciterAppendMasterCSS(byte[] utf8, uint numBytes);
			// BOOL	function(HWINDOW hWndSciter, LPCBYTE utf8, UINT numBytes, LPCWSTR baseUrl, LPCWSTR mediaType) SciterSetCSS;
			public delegate bool FPTR_SciterSetCSS(IntPtr hwnd, byte[] utf8, uint numBytes, string baseUrl, string mediaType);
			// BOOL	function(HWINDOW hWndSciter, LPCWSTR mediaType) SciterSetMediaType;
			public delegate bool FPTR_SciterSetMediaType(IntPtr hwnd, string mediaType);
			// BOOL	function(HWINDOW hWndSciter, const SCITER_VALUE *mediaVars) SciterSetMediaVars;
			public delegate bool FPTR_SciterSetMediaVars(IntPtr hwnd, IntPtr mediaVars);// TODO
			// UINT	function(HWINDOW hWndSciter) SciterGetMinWidth;
			public delegate uint FPTR_SciterGetMinWidth(IntPtr hwnd);
			// UINT	function(HWINDOW hWndSciter, UINT width) SciterGetMinHeight;
			public delegate uint FPTR_SciterGetMinHeight(IntPtr hwnd, uint width);
			//BOOL	function(HWINDOW hWnd, LPCSTR functionName, UINT argc, const SCITER_VALUE* argv, SCITER_VALUE* retval) SciterCall;
			public delegate bool FPTR_SciterCall(IntPtr hwnd, [MarshalAs(UnmanagedType.LPStr)]string functionName, uint argc, SciterXValue.VALUE[] argv, out SciterXValue.VALUE retval);
			// BOOL	function(HWINDOW hwnd, LPCWSTR script, UINT scriptLength, SCITER_VALUE* pretval) SciterEval;
			public delegate bool FPTR_SciterEval(IntPtr hwnd, string script, uint scriptLength, out SciterXValue.VALUE pretval);
			// VOID	function(HWINDOW hwnd) SciterUpdateWindow;
			public delegate bool FPTR_SciterUpdateWindow(IntPtr hwnd);
#if WIN32
			// BOOL	function(MSG* lpMsg) SciterTranslateMessage;
			public delegate bool FPTR_SciterTranslateMessage(IntPtr lpMsg);// TODO: MSG
#endif
			// BOOL	function(HWINDOW hWnd, UINT option, UINT_PTR value ) SciterSetOption;
			public delegate bool FPTR_SciterSetOption(IntPtr hwnd, uint option, uint value);
			// VOID	function(HWINDOW hWndSciter, UINT* px, UINT* py) SciterGetPPI;
			public delegate void FPTR_SciterGetPPI(IntPtr hwnd, ref uint px, ref uint py);
			// BOOL	function(HWINDOW hwnd, VALUE* pval ) SciterGetViewExpando;
			public delegate bool FPTR_SciterGetViewExpando(IntPtr hwnd, IntPtr pval);// TODO
#if WIN32
			// BOOL	function(HWINDOW hWndSciter, ID2D1RenderTarget* prt) SciterRenderD2D;
			public delegate bool FPTR_SciterRenderD2D(IntPtr hwnd, IntPtr prt);// TODO
			// BOOL	function(ID2D1Factory ** ppf) SciterD2DFactory;
			public delegate bool FPTR_SciterD2DFactory(IntPtr ppf);// TODO
			// BOOL	function(IDWriteFactory ** ppf) SciterDWFactory;
			public delegate bool FPTR_SciterDWFactory(IntPtr ppf);// TODO
#endif
			// BOOL	function(LPUINT pcaps) SciterGraphicsCaps;
			public delegate bool FPTR_SciterGraphicsCaps(ref uint pcaps);
			// BOOL	function(HWINDOW hWndSciter, LPCWSTR baseUrl) SciterSetHomeURL;
			public delegate bool FPTR_SciterSetHomeURL(IntPtr hwnd, string baseUrl);
#if OSX
			// HWINDOW function( LPRECT frame ) SciterCreateNSView;// returns NSView*
			public delegate IntPtr FPTR_SciterCreateNSView(ref Types.RECT frame);
#endif
			// HWINDOW	function(UINT creationFlags, LPRECT frame, SciterWindowDelegate* delegt, LPVOID delegateParam, HWINDOW parent) SciterCreateWindow;
			public delegate IntPtr FPTR_SciterCreateWindow(SciterXDef.SCITER_CREATE_WINDOW_FLAGS creationFlags, ref PInvokeUtils.RECT frame, SciterXDef.FPTR_SciterWindowDelegate delegt, IntPtr delegateParam, IntPtr parent);
			//VOID	function(
			//  HWINDOW               hwndOrNull,// HWINDOW or null if this is global output handler
			//  LPVOID                param,     // param to be passed "as is" to the pfOutput
			//  DEBUG_OUTPUT_PROC     pfOutput   // output function, output stream alike thing.
			//  ) SciterSetupDebugOutput;
			public delegate IntPtr FPTR_SciterSetupDebugOutput(IntPtr hwndOrNull, IntPtr param, SciterXDef.FPTR_DEBUG_OUTPUT_PROC pfOutput);

			//|
			//| DOM Element API
			//|

			// SCDOM_RESULT function(HELEMENT he) Sciter_UseElement;
			public delegate int FPTR_Sciter_UseElement(IntPtr he);
			// SCDOM_RESULT function(HELEMENT he) Sciter_UnuseElement;
			public delegate int FPTR_Sciter_UnuseElement(IntPtr he);
			//SCDOM_RESULT function(HWINDOW hwnd, HELEMENT *phe) SciterGetRootElement;
			public delegate int FPTR_SciterGetRootElement(IntPtr hwnd, out IntPtr phe);
			//SCDOM_RESULT function(HWINDOW hwnd, HELEMENT *phe) SciterGetFocusElement;
			public delegate int FPTR_SciterGetFocusElement(IntPtr hwnd, out IntPtr phe);
			//SCDOM_RESULT function(HWINDOW hwnd, POINT pt, HELEMENT* phe) SciterFindElement;
			public delegate int FPTR_SciterFindElement(IntPtr hwnd, PInvokeUtils.POINT pt, out IntPtr phe);
			//SCDOM_RESULT function(HELEMENT he, UINT* count) SciterGetChildrenCount;
			public delegate int FPTR_SciterGetChildrenCount(IntPtr he, ref uint count);
			//SCDOM_RESULT function(HELEMENT he, UINT n, HELEMENT* phe) SciterGetNthChild;
			public delegate int FPTR_SciterGetNthChild(IntPtr he, uint n, out IntPtr phe);
			//SCDOM_RESULT function(HELEMENT he, HELEMENT* p_parent_he) SciterGetParentElement;
			public delegate int FPTR_SciterGetParentElement(IntPtr he, out IntPtr p_parent_he);
			//SCDOM_RESULT function(HELEMENT he, BOOL outer, LPCBYTE_RECEIVER rcv, LPVOID rcv_param) SciterGetElementHtmlCB;
			public delegate int FPTR_SciterGetElementHtmlCB(IntPtr he, bool outer, SciterXDom.FPTR_LPCBYTE_RECEIVER rcv, IntPtr rcv_param);
			//SCDOM_RESULT function(HELEMENT he, LPCWSTR_RECEIVER rcv, LPVOID rcv_param) SciterGetElementTextCB;
			public delegate int FPTR_SciterGetElementTextCB(IntPtr he, SciterXDom.FPTR_LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
			//SCDOM_RESULT function(HELEMENT he, LPCWSTR utf16, UINT length) SciterSetElementText;
			public delegate int FPTR_SciterSetElementText(IntPtr he, [MarshalAs(UnmanagedType.LPWStr)]string utf16, uint length);
			//SCDOM_RESULT function(HELEMENT he, LPUINT p_count) SciterGetAttributeCount;
			public delegate int FPTR_SciterGetAttributeCount(IntPtr he, ref uint p_count);
			//SCDOM_RESULT function(HELEMENT he, UINT n, LPCSTR_RECEIVER rcv, LPVOID rcv_param) SciterGetNthAttributeNameCB;
			public delegate int FPTR_SciterGetNthAttributeNameCB(IntPtr he, uint n, SciterXDom.FPTR_LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
			//SCDOM_RESULT function(HELEMENT he, UINT n, LPCWSTR_RECEIVER rcv, LPVOID rcv_param) SciterGetNthAttributeValueCB;
			public delegate int FPTR_SciterGetNthAttributeValueCB(IntPtr he, uint n, SciterXDom.FPTR_LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
			//SCDOM_RESULT function(HELEMENT he, LPCSTR name, LPCWSTR_RECEIVER rcv, LPVOID rcv_param) SciterGetAttributeByNameCB;
			public delegate int FPTR_SciterGetAttributeByNameCB(IntPtr he, [MarshalAs(UnmanagedType.LPStr)]string name, SciterXDom.FPTR_LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
			//SCDOM_RESULT function(HELEMENT he, LPCSTR name, LPCWSTR value) SciterSetAttributeByName;
			public delegate int FPTR_SciterSetAttributeByName(IntPtr he, [MarshalAs(UnmanagedType.LPStr)]string name, [MarshalAs(UnmanagedType.LPWStr)]string value);
			//SCDOM_RESULT function(HELEMENT he) SciterClearAttributes;
			public delegate int FPTR_SciterClearAttributes(IntPtr he);
			//SCDOM_RESULT function(HELEMENT he, LPUINT p_index) SciterGetElementIndex;
			public delegate int FPTR_SciterGetElementIndex(IntPtr he, ref uint p_index);
			//SCDOM_RESULT function(HELEMENT he, LPCSTR* p_type) SciterGetElementType;
			public delegate int FPTR_SciterGetElementType(IntPtr he, [MarshalAs(UnmanagedType.LPStr)]out string p_type);
			//SCDOM_RESULT function(HELEMENT he, LPCSTR_RECEIVER rcv, LPVOID rcv_param) SciterGetElementTypeCB;
			public delegate int FPTR_SciterGetElementTypeCB(IntPtr he, SciterXDom.FPTR_LPCSTR_RECEIVER rcv, IntPtr rcv_param);
			//SCDOM_RESULT function(HELEMENT he, LPCSTR name, LPCWSTR_RECEIVER rcv, LPVOID rcv_param) SciterGetStyleAttributeCB;
			public delegate int FPTR_SciterGetStyleAttributeCB(IntPtr he, [MarshalAs(UnmanagedType.LPStr)]string name, SciterXDom.FPTR_LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
			//SCDOM_RESULT function(HELEMENT he, LPCSTR name, LPCWSTR value) SciterSetStyleAttribute;
			public delegate int FPTR_SciterSetStyleAttribute(IntPtr he, [MarshalAs(UnmanagedType.LPStr)]string name, [MarshalAs(UnmanagedType.LPWStr)]string value);
			//SCDOM_RESULT function(HELEMENT he, LPRECT p_location, UINT areas /*ELEMENT_AREAS*/) SciterGetElementLocation;
			public delegate int FPTR_SciterGetElementLocation(IntPtr he, ref PInvokeUtils.RECT p_location, uint areas);
			//SCDOM_RESULT function(HELEMENT he, UINT SciterScrollFlags) SciterScrollToView;
			public delegate int FPTR_SciterScrollToView(IntPtr he, uint SciterScrollFlags);
			//SCDOM_RESULT function(HELEMENT he, BOOL andForceRender) SciterUpdateElement;
			public delegate int FPTR_SciterUpdateElement(IntPtr he, bool andForceRender);
			//SCDOM_RESULT function(HELEMENT he, RECT rc) SciterRefreshElementArea;
			public delegate int FPTR_SciterRefreshElementArea(IntPtr he, PInvokeUtils.RECT rc);
			//SCDOM_RESULT function(HELEMENT he) SciterSetCapture;
			public delegate int FPTR_SciterSetCapture(IntPtr he);
			//SCDOM_RESULT function(HELEMENT he) SciterReleaseCapture;
			public delegate int FPTR_SciterReleaseCapture(IntPtr he);
			//SCDOM_RESULT function(HELEMENT he, HWINDOW* p_hwnd, BOOL rootWindow) SciterGetElementHwnd;
			public delegate int FPTR_SciterGetElementHwnd(IntPtr he, ref IntPtr p_hwnd, bool rootWindow);
			//SCDOM_RESULT function(HELEMENT he, LPWSTR szUrlBuffer, UINT UrlBufferSize) SciterCombineURL;
			public delegate int FPTR_SciterCombineURL(IntPtr he, [MarshalAs(UnmanagedType.LPWStr)]string szUrlBuffer, uint UrlBufferSize);
			//SCDOM_RESULT function(HELEMENT  he, LPCSTR    CSS_selectors, SciterElementCallback callback, LPVOID param) SciterSelectElements;
			public delegate int FPTR_SciterSelectElements(IntPtr he, [MarshalAs(UnmanagedType.LPStr)]string CSS_selectors, SciterXDom.FPTR_SciterElementCallback callback, IntPtr param);
			//SCDOM_RESULT function(HELEMENT  he, LPCWSTR   CSS_selectors, SciterElementCallback callback, LPVOID param) SciterSelectElementsW;
			public delegate int FPTR_SciterSelectElementsW(IntPtr he, [MarshalAs(UnmanagedType.LPWStr)]string CSS_selectors, SciterXDom.FPTR_SciterElementCallback callback, IntPtr param);
			//SCDOM_RESULT function(HELEMENT  he, LPCSTR    selector, UINT      depth, HELEMENT* heFound) SciterSelectParent;
			public delegate int FPTR_SciterSelectParent(IntPtr he, [MarshalAs(UnmanagedType.LPStr)]string selector, uint depth, out IntPtr heFound);
			//SCDOM_RESULT function(HELEMENT  he, LPCWSTR   selector, UINT      depth, HELEMENT* heFound) SciterSelectParentW;
			public delegate int FPTR_SciterSelectParentW(IntPtr he, [MarshalAs(UnmanagedType.LPWStr)]string selector, uint depth, out IntPtr heFound);
			//SCDOM_RESULT function(HELEMENT he, const BYTE* html, UINT htmlLength, UINT where) SciterSetElementHtml;
			public delegate int FPTR_SciterSetElementHtml(IntPtr he, byte[] html, uint htmlLength, uint where);
			//SCDOM_RESULT function(HELEMENT he, UINT* puid) SciterGetElementUID;
			public delegate int FPTR_SciterGetElementUID(IntPtr he, ref uint puid);
			//SCDOM_RESULT function(HWINDOW hwnd, UINT uid, HELEMENT* phe) SciterGetElementByUID;
			public delegate int FPTR_SciterGetElementByUID(IntPtr hwnd, uint uid, out IntPtr phe);
			//SCDOM_RESULT function(HELEMENT hePopup, HELEMENT heAnchor, UINT placement) SciterShowPopup;
			public delegate int FPTR_SciterShowPopup(IntPtr he, IntPtr heAnchor, uint placement);
			//SCDOM_RESULT function(HELEMENT hePopup, POINT pos, BOOL animate) SciterShowPopupAt;
			public delegate int FPTR_SciterShowPopupAt(IntPtr he, PInvokeUtils.POINT pos, bool animate);
			//SCDOM_RESULT function(HELEMENT he) SciterHidePopup;
			public delegate int FPTR_SciterHidePopup(IntPtr he);
			//SCDOM_RESULT function( HELEMENT he, UINT* pstateBits) SciterGetElementState;
			public delegate int FPTR_SciterGetElementState(IntPtr he, ref uint pstateBits);
			//SCDOM_RESULT function( HELEMENT he, UINT stateBitsToSet, UINT stateBitsToClear, BOOL updateView) SciterSetElementState;
			public delegate int FPTR_SciterSetElementState(IntPtr he, uint stateBitsToSet, uint stateBitsToClear, bool updateView);
			//SCDOM_RESULT function( LPCSTR tagname, LPCWSTR textOrNull, /*out*/ HELEMENT *phe ) SciterCreateElement;
			public delegate int FPTR_SciterCreateElement(IntPtr he, [MarshalAs(UnmanagedType.LPWStr)]string textOrNull, out IntPtr phe);
			//SCDOM_RESULT function( HELEMENT he, /*out*/ HELEMENT *phe ) SciterCloneElement;
			public delegate int FPTR_SciterCloneElement(IntPtr he, out IntPtr phe);
			//SCDOM_RESULT function( HELEMENT he, HELEMENT hparent, UINT index ) SciterInsertElement;
			public delegate int FPTR_SciterInsertElement(IntPtr he, IntPtr hparent, uint index);
			//SCDOM_RESULT function( HELEMENT he ) SciterDetachElement;
			public delegate int FPTR_SciterDetachElement(IntPtr he);
			//SCDOM_RESULT function(HELEMENT he) SciterDeleteElement;
			public delegate int FPTR_SciterDeleteElement(IntPtr he);
			//SCDOM_RESULT function( HELEMENT he, UINT milliseconds, UINT_PTR timer_id ) SciterSetTimer;
			public delegate int FPTR_SciterSetTimer(IntPtr he, uint milliseconds, IntPtr timer_id);
			//SCDOM_RESULT function( HELEMENT he, LPELEMENT_EVENT_PROC pep, LPVOID tag ) SciterDetachEventHandler;
			public delegate int FPTR_SciterDetachEventHandler(IntPtr he, SciterXBehaviors.FPTR_ElementEventProc pep, IntPtr tag);
			//SCDOM_RESULT function( HELEMENT he, LPELEMENT_EVENT_PROC pep, LPVOID tag ) SciterAttachEventHandler;
			public delegate int FPTR_SciterAttachEventHandler(IntPtr he, SciterXBehaviors.FPTR_ElementEventProc pep, IntPtr tag);
			//SCDOM_RESULT function( HWINDOW hwndLayout, LPELEMENT_EVENT_PROC pep, LPVOID tag, UINT subscription ) SciterWindowAttachEventHandler;
			public delegate int FPTR_SciterWindowAttachEventHandler(IntPtr hwndLayout, SciterXBehaviors.FPTR_ElementEventProc pep, IntPtr tag, uint subscription);
			//SCDOM_RESULT function( HWINDOW hwndLayout, LPELEMENT_EVENT_PROC pep, LPVOID tag ) SciterWindowDetachEventHandler;
			public delegate int FPTR_SciterWindowDetachEventHandler(IntPtr hwndLayout, SciterXBehaviors.FPTR_ElementEventProc pep, IntPtr tag);
			//SCDOM_RESULT function( HELEMENT he, UINT appEventCode, HELEMENT heSource, UINT_PTR reason, /*out*/ BOOL* handled) SciterSendEvent;
			public delegate int FPTR_SciterSendEvent(IntPtr he, uint appEventCode, IntPtr heSource, IntPtr reason);
			//SCDOM_RESULT function( HELEMENT he, UINT appEventCode, HELEMENT heSource, UINT_PTR reason) SciterPostEvent;
			public delegate int FPTR_SciterPostEvent(IntPtr he, uint appEventCode, IntPtr heSource, IntPtr reason);
			//SCDOM_RESULT function(HELEMENT he, METHOD_PARAMS* params) SciterCallBehaviorMethod;
			public delegate int FPTR_SciterCallBehaviorMethod(IntPtr he, ref SciterXDom.METHOD_PARAMS param);
			//SCDOM_RESULT function( HELEMENT he, LPCWSTR url, UINT dataType, HELEMENT initiator ) SciterRequestElementData;
			public delegate int FPTR_SciterRequestElementData(IntPtr he, [MarshalAs(UnmanagedType.LPWStr)]string url, uint dataType, IntPtr initiator);
			//SCDOM_RESULT function( HELEMENT he,						// element to deliver data 
			//							LPCWSTR         url,			// url 
			//							UINT            dataType,		// data type, see SciterResourceType.
			//							UINT            requestType,	// one of REQUEST_TYPE values
			//							REQUEST_PARAM*  requestParams,	// parameters
			//							UINT            nParams			// number of parameters 
			//							) SciterHttpRequest;
			public delegate int FPTR_SciterHttpRequest(IntPtr he, [MarshalAs(UnmanagedType.LPWStr)]string url, uint dataType, uint requestType, ref SciterXDom.REQUEST_PARAM requestParams, uint nParams);
			//SCDOM_RESULT function( HELEMENT he, LPPOINT scrollPos, LPRECT viewRect, LPSIZE contentSize ) SciterGetScrollInfo;
			public delegate int FPTR_SciterGetScrollInfo(IntPtr he, ref PInvokeUtils.POINT scrollPos, ref PInvokeUtils.RECT viewRect, ref PInvokeUtils.SIZE contentSize);
			//SCDOM_RESULT function( HELEMENT he, POINT scrollPos, BOOL smooth ) SciterSetScrollPos;
			public delegate int FPTR_SciterSetScrollPos(IntPtr he, PInvokeUtils.POINT scrollPos, bool smooth);
			//SCDOM_RESULT function( HELEMENT he, INT* pMinWidth, INT* pMaxWidth ) SciterGetElementIntrinsicWidths;
			public delegate int FPTR_SciterGetElementIntrinsicWidths(IntPtr he, ref int pMinWidth, ref int pMaxWidth);
			//SCDOM_RESULT function( HELEMENT he, INT forWidth, INT* pHeight ) SciterGetElementIntrinsicHeight;
			public delegate int FPTR_SciterGetElementIntrinsicHeight(IntPtr he, int forWidth, ref int pHeight);
			//SCDOM_RESULT function( HELEMENT he, BOOL* pVisible) SciterIsElementVisible;
			public delegate int FPTR_SciterIsElementVisible(IntPtr he, ref bool pVisible);
			//SCDOM_RESULT function( HELEMENT he, BOOL* pEnabled ) SciterIsElementEnabled;
			public delegate int FPTR_SciterIsElementEnabled(IntPtr he, ref bool pEnabled);
			//SCDOM_RESULT function( HELEMENT he, UINT firstIndex, UINT lastIndex, ELEMENT_COMPARATOR* cmpFunc, LPVOID cmpFuncParam ) SciterSortElements;
			public delegate int FPTR_SciterSortElements(IntPtr he, uint firstIndex, uint lastIndex, SciterXDom.FPTR_ELEMENT_COMPARATOR cmpFunc, IntPtr cmpFuncParam);
			//SCDOM_RESULT function( HELEMENT he1, HELEMENT he2 ) SciterSwapElements;
			public delegate int FPTR_SciterSwapElements(IntPtr he, IntPtr he2);
			//SCDOM_RESULT function( UINT evt, LPVOID eventCtlStruct, BOOL* bOutProcessed ) SciterTraverseUIEvent;
			public delegate int FPTR_SciterTraverseUIEvent(IntPtr he, IntPtr eventCtlStruct, ref bool bOutProcessed);
			//SCDOM_RESULT function( HELEMENT he, LPCSTR name, const VALUE* argv, UINT argc, VALUE* retval ) SciterCallScriptingMethod;
			public delegate int FPTR_SciterCallScriptingMethod(IntPtr he, [MarshalAs(UnmanagedType.LPStr)]string name, ref SciterXValue.VALUE argv, uint argc, ref SciterXValue.VALUE retval);
			//SCDOM_RESULT function( HELEMENT he, LPCSTR name, const VALUE* argv, UINT argc, VALUE* retval ) SciterCallScriptingFunction;
			public delegate int FPTR_SciterCallScriptingFunction(IntPtr he, [MarshalAs(UnmanagedType.LPStr)]string name, ref SciterXValue.VALUE argv, uint argc, ref SciterXValue.VALUE retval);
			//SCDOM_RESULT function( HELEMENT he, LPCWSTR script, UINT scriptLength, VALUE* retval ) SciterEvalElementScript;
			public delegate int FPTR_SciterEvalElementScript(IntPtr he, [MarshalAs(UnmanagedType.LPWStr)]string script, uint scriptLength, ref SciterXValue.VALUE retval);
			//SCDOM_RESULT function( HELEMENT he, HWINDOW hwnd) SciterAttachHwndToElement;
			public delegate int FPTR_SciterAttachHwndToElement(IntPtr he, IntPtr hwnd);
			//SCDOM_RESULT function( HELEMENT he, /*CTL_TYPE*/ UINT *pType ) SciterControlGetType;
			public delegate int FPTR_SciterControlGetType(IntPtr he, ref uint pType);
			//SCDOM_RESULT function( HELEMENT he, VALUE* pval ) SciterGetValue;
			public delegate int FPTR_SciterGetValue(IntPtr he, ref SciterXValue.VALUE pval);
			//SCDOM_RESULT function( HELEMENT he, const VALUE* pval ) SciterSetValue;
			public delegate int FPTR_SciterSetValue(IntPtr he, ref SciterXValue.VALUE pval);
			//SCDOM_RESULT function( HELEMENT he, VALUE* pval, BOOL forceCreation ) SciterGetExpando;
			public delegate int FPTR_SciterGetExpando(IntPtr he, ref SciterXValue.VALUE pval, bool forceCreation);
			//SCDOM_RESULT function( HELEMENT he, tiscript_value* pval, BOOL forceCreation ) SciterGetObject;
			public delegate int FPTR_SciterGetObject(IntPtr he, ref TIScript.tiscript_value pval, bool forceCreation);
			//SCDOM_RESULT function( HELEMENT he, tiscript_value* pval) SciterGetElementNamespace;
			public delegate int FPTR_SciterGetElementNamespace(IntPtr he, out TIScript.tiscript_value pval);
			//SCDOM_RESULT function( HWINDOW hwnd, HELEMENT* phe) SciterGetHighlightedElement;
			public delegate int FPTR_SciterGetHighlightedElement(IntPtr hwnd, out IntPtr phe);
			//SCDOM_RESULT function( HWINDOW hwnd, HELEMENT he) SciterSetHighlightedElement;
			public delegate int FPTR_SciterSetHighlightedElement(IntPtr hwnd, IntPtr he);

			//|
			//| DOM Node API
			//|

			//SCDOM_RESULT function(HNODE hn) SciterNodeAddRef;
			public delegate int FPTR_SciterNodeAddRef(IntPtr hn);
			//SCDOM_RESULT function(HNODE hn) SciterNodeRelease;
			public delegate int FPTR_SciterNodeRelease(IntPtr hn);
			//SCDOM_RESULT function(HELEMENT he, HNODE* phn) SciterNodeCastFromElement;
			public delegate int FPTR_SciterNodeCastFromElement(IntPtr hn, ref IntPtr phn);
			//SCDOM_RESULT function(HNODE hn, HELEMENT* he) SciterNodeCastToElement;
			public delegate int FPTR_SciterNodeCastToElement(IntPtr hn, ref IntPtr he);
			//SCDOM_RESULT function(HNODE hn, HNODE* phn) SciterNodeFirstChild;
			public delegate int FPTR_SciterNodeFirstChild(IntPtr hn, ref IntPtr phn);
			//SCDOM_RESULT function(HNODE hn, HNODE* phn) SciterNodeLastChild;
			public delegate int FPTR_SciterNodeLastChild(IntPtr hn, ref IntPtr phn);
			//SCDOM_RESULT function(HNODE hn, HNODE* phn) SciterNodeNextSibling;
			public delegate int FPTR_SciterNodeNextSibling(IntPtr hn, ref IntPtr phn);
			//SCDOM_RESULT function(HNODE hn, HNODE* phn) SciterNodePrevSibling;
			public delegate int FPTR_SciterNodePrevSibling(IntPtr hn, ref IntPtr phn);
			//SCDOM_RESULT function(HNODE hnode, HELEMENT* pheParent) SciterNodeParent;
			public delegate int FPTR_SciterNodeParent(IntPtr hn, ref IntPtr pheParent);
			//SCDOM_RESULT function(HNODE hnode, UINT n, HNODE* phn) SciterNodeNthChild;
			public delegate int FPTR_SciterNodeNthChild(IntPtr hn, uint n, ref IntPtr phn);
			//SCDOM_RESULT function(HNODE hnode, UINT* pn) SciterNodeChildrenCount;
			public delegate int FPTR_SciterNodeChildrenCount(IntPtr hn, ref uint pn);
			//SCDOM_RESULT function(HNODE hnode, UINT* pNodeType /*NODE_TYPE*/) SciterNodeType;
			public delegate int FPTR_SciterNodeType(IntPtr hn, ref uint pn);
			//SCDOM_RESULT function(HNODE hnode, LPCWSTR_RECEIVER rcv, LPVOID rcv_param) SciterNodeGetText;
			public delegate int FPTR_SciterNodeGetText(IntPtr hn, SciterXDom.FPTR_LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
			//SCDOM_RESULT function(HNODE hnode, LPCWSTR text, UINT textLength) SciterNodeSetText;
			public delegate int FPTR_SciterNodeSetText(IntPtr hn, [MarshalAs(UnmanagedType.LPWStr)]string text, uint textLength);
			//SCDOM_RESULT function(HNODE hnode, UINT where /*NODE_INS_TARGET*/, HNODE what) SciterNodeInsert;
			public delegate int FPTR_SciterNodeInsert(IntPtr hn, uint where, IntPtr what);
			//SCDOM_RESULT function(HNODE hnode, BOOL finalize) SciterNodeRemove;
			public delegate int FPTR_SciterNodeRemove(IntPtr hn, bool finalize);
			//SCDOM_RESULT function(LPCWSTR text, UINT textLength, HNODE* phnode) SciterCreateTextNode;
			public delegate int FPTR_SciterCreateTextNode(IntPtr hn, uint textLength, ref IntPtr phnode);
			//SCDOM_RESULT function(LPCWSTR text, UINT textLength, HNODE* phnode) SciterCreateCommentNode;
			public delegate int FPTR_SciterCreateCommentNode(IntPtr hn, uint textLength, ref IntPtr phnode);

			//|
			//| Value API
			//|
			// UINT function( VALUE* pval ) ValueInit;
			public delegate int FPTR_ValueInit(out SciterXValue.VALUE pval);
			// UINT function( VALUE* pval ) ValueClear;
			public delegate int FPTR_ValueClear(out SciterXValue.VALUE pval);
			// UINT function( const VALUE* pval1, const VALUE* pval2 ) ValueCompare;
			public delegate int FPTR_ValueCompare(ref SciterXValue.VALUE pval, ref IntPtr pval2);
			// UINT function( VALUE* pdst, const VALUE* psrc ) ValueCopy;
			public delegate int FPTR_ValueCopy(out SciterXValue.VALUE pdst, ref SciterXValue.VALUE psrc);
			// UINT function( VALUE* pdst ) ValueIsolate;
			public delegate int FPTR_ValueIsolate(ref SciterXValue.VALUE pdst);
			// UINT function( const VALUE* pval, UINT* pType, UINT* pUnits ) ValueType;
			public delegate int FPTR_ValueType(ref SciterXValue.VALUE pval, out uint pType, out uint pUnits);
			// UINT function( const VALUE* pval, LPCWSTR* pChars, UINT* pNumChars ) ValueStringData;
			public delegate int FPTR_ValueStringData(ref SciterXValue.VALUE pval, out IntPtr pChars, out uint pNumChars);
			// UINT function( VALUE* pval, LPCWSTR chars, UINT numChars, UINT units ) ValueStringDataSet;
			public delegate int FPTR_ValueStringDataSet(ref SciterXValue.VALUE pval, [MarshalAs(UnmanagedType.LPWStr)]string chars, uint numChars, uint units);
			// UINT function( const VALUE* pval, INT* pData ) ValueIntData;
			public delegate int FPTR_ValueIntData(ref SciterXValue.VALUE pval, out int pData);
			// UINT function( VALUE* pval, INT data, UINT type, UINT units ) ValueIntDataSet;
			public delegate int FPTR_ValueIntDataSet(ref SciterXValue.VALUE pval, int data, uint type, uint units);
			// UINT function( const VALUE* pval, INT64* pData ) ValueInt64Data;
			public delegate int FPTR_ValueInt64Data(ref SciterXValue.VALUE pval, out long pData);
			// UINT function( VALUE* pval, INT64 data, UINT type, UINT units ) ValueInt64DataSet;
			public delegate int FPTR_ValueInt64DataSet(ref SciterXValue.VALUE pval, long data, uint type, uint units);
			// UINT function( const VALUE* pval, FLOAT_VALUE* pData ) ValueFloatData;
			public delegate int FPTR_ValueFloatData(ref SciterXValue.VALUE pval, out double pData);
			// UINT function( VALUE* pval, FLOAT_VALUE data, UINT type, UINT units ) ValueFloatDataSet;
			public delegate int FPTR_ValueFloatDataSet(ref SciterXValue.VALUE pval, double data, uint type, uint units);
			// UINT function( const VALUE* pval, LPCBYTE* pBytes, UINT* pnBytes ) ValueBinaryData;
			public delegate int FPTR_ValueBinaryData(ref SciterXValue.VALUE pval, out IntPtr pBytes, out uint pnBytes);
			// UINT function( VALUE* pval, LPCBYTE pBytes, UINT nBytes, UINT type, UINT units ) ValueBinaryDataSet;
			public delegate int FPTR_ValueBinaryDataSet(ref SciterXValue.VALUE pval, [MarshalAs(UnmanagedType.LPArray)]byte[] pBytes, uint nBytes, uint type, uint units);
			// UINT function( const VALUE* pval, INT* pn) ValueElementsCount;
			public delegate int FPTR_ValueElementsCount(ref SciterXValue.VALUE pval, out int pn);
			// UINT function( const VALUE* pval, INT n, VALUE* pretval) ValueNthElementValue;
			public delegate int FPTR_ValueNthElementValue(ref SciterXValue.VALUE pval, int n, out SciterXValue.VALUE pretval);
			// UINT function( VALUE* pval, INT n, const VALUE* pval_to_set) ValueNthElementValueSet;
			public delegate int FPTR_ValueNthElementValueSet(ref SciterXValue.VALUE pval, int n, ref SciterXValue.VALUE pval_to_set);
			// UINT function( const VALUE* pval, INT n, VALUE* pretval) ValueNthElementKey;
			public delegate int FPTR_ValueNthElementKey(ref SciterXValue.VALUE pval, int n, out SciterXValue.VALUE pretval);
			// UINT function( VALUE* pval, KeyValueCallback* penum, LPVOID param) ValueEnumElements;
			public delegate int FPTR_ValueEnumElements(ref SciterXValue.VALUE pval, SciterXValue.FPTR_KeyValueCallback penum, IntPtr param);
			// UINT function( VALUE* pval, const VALUE* pkey, const VALUE* pval_to_set) ValueSetValueToKey;
			public delegate int FPTR_ValueSetValueToKey(ref SciterXValue.VALUE pval, ref SciterXValue.VALUE pkey, ref SciterXValue.VALUE pval_to_set);
			// UINT function( const VALUE* pval, const VALUE* pkey, VALUE* pretval) ValueGetValueOfKey;
			public delegate int FPTR_ValueGetValueOfKey(ref SciterXValue.VALUE pval, ref SciterXValue.VALUE pkey, out SciterXValue.VALUE pretval);
			// UINT function( VALUE* pval, /*VALUE_STRING_CVT_TYPE*/ UINT how ) ValueToString;
			public delegate int FPTR_ValueToString(ref SciterXValue.VALUE pval, uint how);
			// UINT function( VALUE* pval, LPCWSTR str, UINT strLength, /*VALUE_STRING_CVT_TYPE*/ UINT how ) ValueFromString;
			public delegate int FPTR_ValueFromString(ref SciterXValue.VALUE pval, [MarshalAs(UnmanagedType.LPWStr)]string str, uint strLength, uint how);
			// UINT function( VALUE* pval, VALUE* pthis, UINT argc, const VALUE* argv, VALUE* pretval, LPCWSTR url) ValueInvoke;
			public delegate int FPTR_ValueInvoke(ref SciterXValue.VALUE pval, ref SciterXValue.VALUE pthis, uint argc, SciterXValue.VALUE[] argv, out SciterXValue.VALUE pretval, [MarshalAs(UnmanagedType.LPWStr)]string url);
			// UINT function( VALUE* pval, NATIVE_FUNCTOR_INVOKE*  pinvoke, NATIVE_FUNCTOR_RELEASE* prelease, VOID* tag) ValueNativeFunctorSet;
			public delegate int FPTR_ValueNativeFunctorSet(ref SciterXValue.VALUE pval, SciterXValue.FPTR_NATIVE_FUNCTOR_INVOKE pinvoke, SciterXValue.FPTR_NATIVE_FUNCTOR_RELEASE prelease, IntPtr tag);
			// BOOL function( const VALUE* pval) ValueIsNativeFunctor;
			public delegate int FPTR_ValueIsNativeFunctor(ref SciterXValue.VALUE pval);

            // tiscript VM API
            // tiscript_native_interface* function() TIScriptAPI;
			public delegate IntPtr FPTR_TIScriptAPI();
            // HVM function(HWINDOW hwnd) SciterGetVM;
			public delegate IntPtr FPTR_SciterGetVM();

            // BOOL function(HVM vm, tiscript_value script_value, VALUE* value, BOOL isolate) Sciter_v2V;
			public delegate bool FPTR_Sciter_v2V(IntPtr vm, TIScript.tiscript_value script_value, ref SciterXValue.VALUE value, bool isolate);
            // BOOL function(HVM vm, const VALUE* valuev, tiscript_value* script_value) Sciter_V2v;
			public delegate bool FPTR_Sciter_V2v(IntPtr vm, ref SciterXValue.VALUE value, ref TIScript.tiscript_value script_value);

			// HSARCHIVE function(LPCBYTE archiveData, UINT archiveDataLength) SciterOpenArchive;
			public delegate IntPtr FPTR_SciterOpenArchive(byte[] archiveData, uint archiveDataLength);
			// BOOL function(HSARCHIVE harc, LPCWSTR path, LPCBYTE* pdata, UINT* pdataLength) SciterGetArchiveItem;
			public delegate bool FPTR_SciterGetArchiveItem(IntPtr harc, [MarshalAs(UnmanagedType.LPWStr)]string path, out IntPtr pdata, out uint pdataLength);
			// BOOL function(HSARCHIVE harc) SciterCloseArchive;
			public delegate bool FPTR_SciterCloseArchive(IntPtr harc);

			// SCDOM_RESULT function( const BEHAVIOR_EVENT_PARAMS* evt, BOOL post, BOOL *handled ) SciterFireEvent;
			public delegate int FPTR_SciterFireEvent(ref SciterXBehaviors.BEHAVIOR_EVENT_PARAMS evt, bool post, out bool handled);

			// LPVOID function(HWINDOW hwnd) SciterGetCallbackParam;
			public delegate IntPtr FPTR_SciterGetCallbackParam(IntPtr hwnd);
			// UINT_PTR function(HWINDOW hwnd, UINT_PTR wparam, UINT_PTR lparam, UINT timeoutms) SciterPostCallback;// if timeoutms>0 then it is a send, not a post
			public delegate IntPtr FPTR_SciterPostCallback(IntPtr hwnd, IntPtr wparam, IntPtr lparam, uint timeoutms);
		}
	}
}