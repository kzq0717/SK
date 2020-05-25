using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace SK
{
    public class HardwareInfo
    {
        //private static string publicKey = @"<RSAKeyValue><Modulus>sb1zuR5gPeESE/0Cwikah1g5B6ooIfI99mHXQfSkljhWGZvuxGZPX8/lMOo/TKfyvcrR5SsXg7uZA9fQY5+oVBRrUU+mMvTpowcHC3sHYkA4HsNlYmFEm/qoWyIebDpdQYRhpIj3EaV4ZiOAZNZc1NoCIMXJMN8WL2QRwPpSlsE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>  ";
        private static string publicKey = @"<RSAKeyValue><Modulus>7nrPVroeXy02q3lDM1oFN2RJv7KfruHhnI+n4uKLs5vw4g3K0L6zFWp8+JW1NQv4l38ZXpPTPyIVcQ9UEnrzHD4U2jtfB6C8CI22bBTVlWvdM2/Ti8+ivO0l7LmWGZyq0ImjVGzb438SqxGy0crice1y06zcXM+7aDgDo/NdxiU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        /*
         * 硬件
        Win32_Processor, // CPU 处理器
        Win32_PhysicalMemory, // 物理内存条
        Win32_Keyboard, // 键盘
        Win32_PointingDevice, // 点输入设备，包括鼠标。
        Win32_FloppyDrive, // 软盘驱动器
        Win32_DiskDrive, // 硬盘驱动器
        Win32_CDROMDrive, // 光盘驱动器
        Win32_BaseBoard, // 主板
        Win32_BIOS, // BIOS 芯片
        Win32_ParallelPort, // 并口
        Win32_SerialPort, // 串口
        Win32_SerialPortConfiguration, // 串口配置
        Win32_SoundDevice, // 多媒体设置，一般指声卡。
        Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
        Win32_USBController, // USB 控制器
        Win32_NetworkAdapter, // 网络适配器
        Win32_NetworkAdapterConfiguration, // 网络适配器设置
        Win32_Printer, // 打印机
        Win32_PrinterConfiguration, // 打印机设置
        Win32_PrintJob, // 打印机任务
        Win32_TCPIPPrinterPort, // 打印机端口
        Win32_POTSModem, // MODEM
        Win32_POTSModemToSerialPort, // MODEM 端口
        Win32_DesktopMonitor, // 显示器
        Win32_DisplayConfiguration, // 显卡
        Win32_DisplayControllerConfiguration, // 显卡设置
        Win32_VideoController, // 显卡细节。
        Win32_VideoSettings, // 显卡支持的显示模式。

        // 操作系统
        Win32_TimeZone, // 时区
        Win32_SystemDriver, // 驱动程序
        Win32_DiskPartition, // 磁盘分区
        Win32_LogicalDisk, // 逻辑磁盘
        Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
        Win32_LogicalMemoryConfiguration, // 逻辑内存配置
        Win32_PageFile, // 系统页文件信息
        Win32_PageFileSetting, // 页文件设置
        Win32_BootConfiguration, // 系统启动配置
        Win32_ComputerSystem, // 计算机信息简要
        Win32_OperatingSystem, // 操作系统信息
        Win32_StartupCommand, // 系统自动启动程序
        Win32_Service, // 系统安装的服务
        Win32_Group, // 系统管理组
        Win32_GroupUser, // 系统组帐号
        Win32_UserAccount, // 用户帐号
        Win32_Process, // 系统进程
        Win32_Thread, // 系统线程
        Win32_Share, // 共享
        Win32_NetworkClient, // 已安装的网络客户端
        Win32_NetworkProtocol, // 已安装的网络协议
        Win32_PnPEntity,//all device
         * 
         */

        /// <summary>获取磁盘序列号
        /// </summary>
        /// <returns></returns>
        public static string GetDiskVolumeSerialNumber() {
            try
            {
                ManagementObject _disk = new ManagementObject(@"Win32_LogicalDisk.deviceid=""c:""");
                _disk.Get();
                return _disk["VolumeSerialNumber"].ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>Get CPU ID
        /// </summary>
        /// <returns></returns>
        public static string GetProcessorID()
        {
            try {
                ManagementObjectSearcher _mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_Processor");
                ManagementObjectCollection _mbsList = _mbs.Get();
                string _id = string.Empty;
                foreach(ManagementObject _mo in _mbsList)
                {
                    _id = _mo["ProcessorId"].ToString();
                    break;
                }
                return _id;
            } catch(Exception ex) {
                throw ex;
            }
        }


        /// <summary>Get motherboard serial number
        /// </summary>主板编号
        /// <returns></returns>
        public static string GetMotherboardID() {

            try
            {
                ManagementObjectSearcher _mbs = new ManagementObjectSearcher("Select SerialNumber From Win32_BaseBoard");
                ManagementObjectCollection _mbsList = _mbs.Get();
                string _id = string.Empty;
                foreach (ManagementObject _mo in _mbsList)
                {
                    _id = _mo["SerialNumber"].ToString();
                    break;
                }
                return _id;
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        /// <summary>Get motherboard serial number
        /// </summary>主板编号
        /// <returns></returns>
        public static string GetMotherboardID_ByKey()
        {

            try
            {
                ManagementObjectSearcher _mbs = new ManagementObjectSearcher("Select SerialNumber From Win32_BaseBoard");
                ManagementObjectCollection _mbsList = _mbs.Get();
                string _id = string.Empty;
                foreach (ManagementObject _mo in _mbsList)
                {
                    _id = _mo["SerialNumber"].ToString();
                    break;
                }
                return SecurityHelper.RSAEncrypt(publicKey,_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<string>SplitInParts(string input,int partLength)
        {
            if (input == null)
                throw new ArgumentException("input");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");
            for (int i = 0; i < input.Length; i += partLength)
                yield return input.Substring(i, Math.Min(partLength, input.Length - i));
        }

        /// <summary>
        /// Combine CPU ID, Disk C Volume Serial Number and Motherboard Serial Number as device Id
        /// </summary>
        /// <returns></returns>
        /// 
        public static string GenerateUID(string appName)
        {
            //Combine the IDs and get bytes
            string _id = string.Concat(appName, GetProcessorID(), GetMotherboardID(), GetDiskVolumeSerialNumber());
            byte[] _byteIds = Encoding.UTF8.GetBytes(_id);

            //Use MD5 to get the fixed length checksum of the ID string
            MD5CryptoServiceProvider _md5 = new MD5CryptoServiceProvider();
            byte[] _checksum = _md5.ComputeHash(_byteIds);

            //Convert checksum into 4 ulong parts and use BASE36 to encode both
            string _part1Id = BASE36.Encode(BitConverter.ToUInt32(_checksum, 0));
            string _part2Id = BASE36.Encode(BitConverter.ToUInt32(_checksum, 4));
            string _part3Id = BASE36.Encode(BitConverter.ToUInt32(_checksum, 8));
            string _part4Id = BASE36.Encode(BitConverter.ToUInt32(_checksum, 12));

            //Concat these 4 part into one string
            return string.Format("{0}-{1}-{2}-{3}", _part1Id, _part2Id, _part3Id, _part4Id);
        }


        public static byte[]GetUIDInBytes(string UID)
        {
            //Split 4 part Id into 4 ulong
            string[] _ids = UID.Split('-');

            if (_ids.Length != 4) throw new ArgumentException("Wrong UID");

            //Combine 4 part Id into one byte array
            byte[] _value = new byte[16];
            Buffer.BlockCopy(BitConverter.GetBytes(BASE36.Decode(_ids[0])), 0, _value, 0, 8);
            Buffer.BlockCopy(BitConverter.GetBytes(BASE36.Decode(_ids[1])), 0, _value, 8, 8);
            Buffer.BlockCopy(BitConverter.GetBytes(BASE36.Decode(_ids[2])), 0, _value, 16, 8);
            Buffer.BlockCopy(BitConverter.GetBytes(BASE36.Decode(_ids[3])), 0, _value, 24, 8);

            return _value;
        }


        /// <summary>验证UID格式
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static bool ValidateUIDFormat(string UID)
        {
            if (!string.IsNullOrEmpty(UID))
            {
                string[] _ids = UID.Split('-');
                return (_ids.Length == 4);
            }
            else
            {
                return false;
            }
        }

        /// <summary>获取MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            string macAddress = "";
            using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc) {
                    if ((bool)mo["IPEnabled"] == true) 
                        macAddress = mo["MacAddress"].ToString();
                    mo.Dispose();
                }
            }
            return macAddress;
        }


        #region 通过NetworkInterface获取MAC地址
        /// <summary>
        /// 通过NetworkInterface获取MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacByNetworkInterface()
        {
            try
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    return BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes());
                }
            }
            catch (Exception)
            {
            }
            return "00-00-00-00-00-00";
        }
        #endregion
    }
}
