using System;
using System.Runtime.InteropServices;

namespace Termgine.BetterConsole {
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ConsoleFont {
		public uint Index;
		public short SizeX, SizeY;
	}

	public static class ConsoleHelper {

		[DllImport("kernel32")]
		private static extern bool SetConsoleFont(IntPtr hOutput, uint index);

		private enum StdHandle {
			OutputHandle = -11
		}

		[DllImport("kernel32")]
		private static extern IntPtr GetStdHandle(StdHandle index);

		public static bool SetConsoleFont(uint index) {
			return SetConsoleFont(GetStdHandle(StdHandle.OutputHandle), index);
		}

		[DllImport("kernel32")]
		private static extern bool GetConsoleFontInfo(IntPtr hOutput, [MarshalAs(UnmanagedType.Bool)]bool bMaximize, 
			uint count, [MarshalAs(UnmanagedType.LPArray), Out] ConsoleFont[] fonts);

		[DllImport("kernel32")]
		private static extern uint GetNumberOfConsoleFonts();

		public static uint ConsoleFontsCount => GetNumberOfConsoleFonts();

	  public static ConsoleFont[] ConsoleFonts {
			get {
				ConsoleFont[] fonts = new ConsoleFont[GetNumberOfConsoleFonts()];
				if(fonts.Length > 0)
					GetConsoleFontInfo(GetStdHandle(StdHandle.OutputHandle), false, (uint)fonts.Length, fonts);
				return fonts;
			}
		}

	}
}
