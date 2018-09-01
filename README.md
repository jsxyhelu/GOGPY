基于OpenCV编写图像处理项目，除了算法以外，比较重要一个问题就是界面设计问题。对于c++语系的程序员来说，一般来说有QT/MFC两种考虑。QT的确功能强大，特别是QML编写android界面很有一套（https://www.cnblogs.com/jsxyhelu/p/8286476.html）
，在树莓派上进行设计也很方便（https://www.cnblogs.com/jsxyhelu/p/7839062.html）
；但是使用QT的一个现实问题就是和现有平台的结合，比如客户需要将结果导出到excel中，使用QT就比较别扭（当然不是说不可以）。所以现在我一般这样来做：对于Android和PI，或者需要在Linux上运行的项目，使用QT编写界面，调用Opencv函数；对于需要在windows上运行的项目，使用MFC编写界面，直接就可以引用OpenCV。
有人会吐槽MFC使用起来非常麻烦，这点我非常同意。但MFC经过这么多年的发展，今日仍有活力，并且短时间内不会消失。因为相比较其他一些所见即所得的语言和环境来说（QT/Csharp）,mfc的消息映射机制和坐标体系等，的确有它的优势，对于图像处理程序来说尤其如此；加以积累，能够快速做出很多专业的东西；近期出现的ribbon界面也为mfc加分不少（https://www.cnblogs.com/jsxyhelu/p/9209052.html）
选择了MFC这个方向，思考图像处理程序问题，一般来说分为“处理图像”和"处理视频"两类：对于图像处理来说，我提供的GOPaint框架（https://www.cnblogs.com/jsxyhelu/p/6440910.html）
能够提供一个基本的静态图像处理框架；而GOMFCTemplate2（https://www.cnblogs.com/jsxyhelu/p/GOMFCTemplate2.html）
则适合用来处理视频。这两种都分别成功运用于多种视频处理项目中。
但是这里我想更进一步：希望能够用Csharp编写界面，因为它更好用；但是又不想引入EmguCV类似的库，因为里面很多东西不是我需要的。那么最直接的方法就是使用Csharp调用基于Opencv编写的类库文件(Dll)的，我取名叫做GreenOpenCsharpWarper(GOCW)
经过比较长时间的探索研究，目前的GOCW已经可以直接以函数的形式在内存中传递bitmap和Mat对象，达到了函数级别的应用。因为这里涉及到托管代码编写，也就是CLR程序编写，所以有比较复杂的地方；为了展现GOCW的优良特性，我编写实现GOGPY项目，也就是一个"Csharp编写界面，OpenCV实现算法的实时视频处理程序”，相关细节都包含其中。之所以叫“GPY”,是采集硬件这块，我采用了成像质量较好的高拍仪设备（GaoPaiYi)

详细内容请参考 https://www.cnblogs.com/jsxyhelu/p/9509181.html
