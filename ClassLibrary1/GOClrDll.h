// ClassLibrary1.h

#pragma once
#using <system.drawing.dll>

#include "stdafx.h"
#include "opencv/cv.h"
#include "opencv2/core/core.hpp"
#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"

#include <opencv2/core/utility.hpp>
#include "opencv2/imgproc.hpp"
#include "opencv2/imgcodecs.hpp"

using namespace System;
using namespace System::Data;
using namespace System::IO;
using namespace System::Drawing;
using namespace System::Drawing::Imaging;

using namespace std;


namespace GOClrDll {



	public ref class GOClrClass
	{
		public :
		//常态化保存的testmethod
		Bitmap^  GOClrClass::testMethod(cli::array<unsigned char>^ pCBuf1);
		Bitmap^  GOClrClass::fetchresult(cli::array<unsigned char>^ pCBuf1,bool ifAdjust,int method);
	};
}
