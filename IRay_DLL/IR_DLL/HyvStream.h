#ifdef HYVSREAM_EXPORTS
#define HYVSREAM_API __declspec(dllexport)
#else
#define HYVSTREAM_API __declspec(dllimport)
#endif

enum MSG_TYPE
{
	MSG_INIT = 0,
	MSG_PLAY,
	MSG_DEC,
};

enum DECV_TYPE
{
	DECV_YUV = 0,     //YV12
	DECV_RGB          //RGB32
};

enum TRANS_TYPE
{
	TRANS_TCP = 0,
	TRANS_UDP,
};

#define IN
#define OUT
#define INOUT

#define MAX_PIC_WIDTH 1920
#define MAX_PIC_HEIGHT 1080
#define MAX_YUVPIC_SIZE (1024 * 1024 * 4)  //YUV数据值一定要大于（视频宽 * 视频高 * 1.5）
#define MAX_RGBPIC_SIZE (1024 * 1024 * 9)  //RGB数据值一定要大于（视频宽 * 视频高 * 4）

typedef void(*VideoCallBack)(OUT char* pData, OUT int iWidth, OUT int iHeight, INOUT void* pContext);
typedef void (*MsgCallBack)(OUT int iMsgType, OUT bool bSuccess, INOUT void* pContext);
typedef void (*OtherCallBack)(OUT char* pData, OUT int iSize, INOUT void* pContext);

class HYVSTREAM_API CHyvStream {
public:
	static void InitSdk();
	static void UnInitSdk();
	static CHyvStream *Create();

	void Release();
	void SetVideoCallBack(VideoCallBack pVideoCallBack, void *pContext);
	void SetOtherCallBack(OtherCallBack pOtherCallBack, void *pContext);
	void SetMsgCallBack(MsgCallBack pMsgCallBack, void *pContext);
	
	void SetTransType(int iTransType);
	void SetDecvType(int iDecvType);
	bool Start(char *strUrl);   //播放视频
	void Stop();                //停止视频
	
	void GetVideoSize(int &iWidth, int &iHeight);//获取解码视频宽高
};

