// ClassLibrary1.h

#pragma once
using namespace System;
using namespace System::Data;
using namespace System::IO;
using namespace std;

namespace GOClrDll {



	public ref class GOClrClass
	{
		public :
		String^ GOClrClass::Method(cli::array<unsigned char>^ pCBuf1);
		//转换颜色的clr函数
		String^  GOClrClass::ConvetAndSplit1(cli::array<unsigned char>^ pCBuf1,int iparam);
		String^  GOClrClass::ConvetAndSplit2(cli::array<unsigned char>^ pCBuf1,int iparam);
		String^  GOClrClass::ConvetAndSplit0(cli::array<unsigned char>^ pCBuf1,int iparam);

	};
}
