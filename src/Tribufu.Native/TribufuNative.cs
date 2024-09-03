// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using System.Runtime.InteropServices;

namespace Tribufu.Native
{
    public class TribufuNative
    {
        [DllImport("tribufu_sdk")]
        public static extern void tribufu_sdk_shutdown();
    }
}
