﻿using System;
using System.Runtime.InteropServices;

namespace GetStartScreenColors
{
    public static class StarScreenColorsHelper
    {
        [DllImport("uxtheme.dll", EntryPoint = "#98", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern UInt32 GetImmersiveUserColorSetPreference(Boolean forceCheckRegistry, Boolean skipCheckOnFail);

        [DllImport("uxtheme.dll", EntryPoint = "#94", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern UInt32 GetImmersiveColorSetCount();

        [DllImport("uxtheme.dll", EntryPoint = "#95", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern UInt32 GetImmersiveColorFromColorSetEx(UInt32 immersiveColorSet, UInt32 immersiveColorType,
            Boolean ignoreHighContrast, UInt32 highContrastCacheMode);

        [DllImport("uxtheme.dll", EntryPoint = "#96", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern UInt32 GetImmersiveColorTypeFromName(IntPtr name);

        [DllImport("uxtheme.dll", EntryPoint = "#100", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern IntPtr GetImmersiveColorNamedTypeByIndex(UInt32 index);
    }
}
