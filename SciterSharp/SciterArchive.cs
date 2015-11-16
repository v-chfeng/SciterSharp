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
using SciterSharp.Interop;

namespace SciterSharp
{
	public class SciterArchive
	{
		private static SciterX.ISciterAPI _api = SciterX.GetSicterAPI();
		private IntPtr _har;

		public void Open(byte[] res_array)
		{
			Debug.Assert(_har == IntPtr.Zero);
			_har = _api.SciterOpenArchive(res_array, (uint) res_array.Length);
			Debug.Assert(_har != IntPtr.Zero);
		}

		public void Close()
		{
			Debug.Assert(_har != IntPtr.Zero);
			_api.SciterCloseArchive(_har);
			_har = IntPtr.Zero;
		}

		public byte[] Get(string path)
		{
			Debug.Assert(_har != IntPtr.Zero);

			IntPtr data_ptr;
			uint data_count;

			bool found = _api.SciterGetArchiveItem(_har, path, out data_ptr, out data_count);
			if(found == false)
				return null;

			byte[] res = new byte[data_count];
			Marshal.Copy(data_ptr, res, 0, (int) data_count);
			return res;
		}
	}
}