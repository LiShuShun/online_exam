using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_examination_system.Liuyingjie
{
    class CCtrlEffect
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HOR_POSITIVE = 0x0001;//从左到右打开窗口
        private const int AW_HOR_NEGATIVE = 0x0002;//从右到左打开窗口
        private const int AW_VER_POSITIVE = 0x0004;//从上到下打开窗口
        private const int AW_VER_NEGATIVE = 0x0008;//从下到上打开窗口
        private const int AW_CENTER = 0x0010;//从中央打开
        private const int AW_HIDE = 0x10000;//隐藏窗体
        private const int AW_ACTIVATE = 0x20000;//显示窗体
        private const int AW_SLIDE = 0x40000;
        private const int AW_BLEND = 0x80000;//淡入淡出效果
        //特效选择
        public enum Effect : int
        {
            HOR_POSITIVE = 1,     //从左到右打开窗口
            HOR_NEGATIVE = 2,     //从右到左打开窗口
            VER_POSITIVE = 4,     //从上到下打开窗口
            VER_NEGATIVE = 8,     //从下到上打开窗口
            CENTER = 0x10,        //从中央打开

        }
        /// <summary>
        /// 加载特效
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="e"></param>
        /// <param name="time"></param>
        public void LoadEffect(IntPtr hwnd, Effect e, int time)
        {
            AnimateWindow(hwnd, time, (int)e | AW_ACTIVATE);
        }
        /// <summary>
        /// 关闭特效
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="e"></param>
        /// <param name="time"></param>
        public void CloseEffect(IntPtr hwnd, Effect e, int time)
        {
            AnimateWindow(hwnd, time, (int)e | AW_HIDE | AW_SLIDE);
        }
    }
}
