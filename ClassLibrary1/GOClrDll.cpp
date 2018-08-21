// 这是主 DLL 文件。
#using <system.drawing.dll>
#include "stdafx.h"
#include "GOClrDll.h"
#include "opencv/cv.h"
#include "opencv2/core/core.hpp"
#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"

#include <opencv2/core/utility.hpp>
#include "opencv2/imgproc.hpp"
#include "opencv2/imgcodecs.hpp"

using namespace std;
using namespace cv;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;
using namespace System::Drawing;
using namespace System::Drawing::Imaging;

using namespace GOClrDll;


System::Drawing::Bitmap^ MatToBitmap(const cv::Mat& img)
{
	if (img.type() != CV_8UC3)
	{
		throw gcnew NotSupportedException("Only images of type CV_8UC3 are supported for conversion to Bitmap");
	}

	//create the bitmap and get the pointer to the data
	PixelFormat fmt(PixelFormat::Format24bppRgb);
	Bitmap ^bmpimg = gcnew Bitmap(img.cols, img.rows, fmt);

	BitmapData ^data = bmpimg->LockBits(System::Drawing::Rectangle(0, 0, img.cols, img.rows), ImageLockMode::WriteOnly, fmt);

	Byte *dstData = reinterpret_cast<Byte*>(data->Scan0.ToPointer());

	unsigned char *srcData = img.data;

	for (int row = 0; row < data->Height; ++row)
	{
		memcpy(reinterpret_cast<void*>(&dstData[row*data->Stride]), reinterpret_cast<void*>(&srcData[row*img.step]), img.cols*img.channels());
	}

	bmpimg->UnlockBits(data);

	return bmpimg;
}

static vector<cv::Point> FindBiggestContour(cv::Mat src){
	int max_area_contour_idx = 0;
	double max_area = -1;
	vector<vector<cv::Point> >contours;
	findContours(src,contours,RETR_LIST,CHAIN_APPROX_SIMPLE);
	//handle case if no contours are detected
	if(0 == contours.size())
		return vector<cv::Point>(NULL);
	for (uint i=0;i<contours.size();i++){
		double temp_area = contourArea(contours[i]);
		if (max_area < temp_area ){
			max_area_contour_idx = i;
			max_area = temp_area;
		}
	}
	return contours[max_area_contour_idx];
}

Bitmap^  GOClrClass::testMethod(cli::array<unsigned char>^ pCBuf1)
{
	////////////////////////////////将输入cli::array<unsigned char>转换为cv::Mat/////////////////////////
	pin_ptr<System::Byte> p1 = &pCBuf1[0];
	unsigned char* pby1 = p1;
	cv::Mat img_data1(pCBuf1->Length,1,CV_8U,pby1);
	cv::Mat img_object = cv::imdecode(img_data1,IMREAD_UNCHANGED);
	if (!img_object.data)
		return nullptr;

	////////////////////////////////////////////OpenCV的算法处理过程////////////////////////////////////
	vector<vector<cv::Point> > contours;
	vector<Vec4i> hierarchy;

	Mat drawing = img_object.clone();
	cvtColor(img_object,img_object,COLOR_BGR2GRAY);
	cv::threshold(img_object,img_object,100,255,THRESH_OTSU);
	bitwise_not(img_object,img_object);//反色
	//Mat drawing = img_object.clone();
	////寻找最大轮廓
	vector<cv::Point> biggestContour = FindBiggestContour(img_object);
	if (0==biggestContour.size())
	    return nullptr;
	////对最大轮廓创建可倾斜的边界框
	RotatedRect minRect = minAreaRect(biggestContour);
	Point2f rect_points[4];
	minRect.points( rect_points );
	for( int j = 0; j < 4; j++ )
		line( drawing, rect_points[j], rect_points[(j+1)%4], Scalar(0,255,0), 1, 8 );

	//cvtColor(drawing,drawing,COLOR_GRAY2BGR);
	/////////////////////////将cv::Mat转换为Bitmap(只能传输cv_8u3格式数据）///////////////////////////////
	if (!drawing.data)
		return nullptr;
	Bitmap^ bitmap = MatToBitmap(drawing);
	return bitmap;
}



