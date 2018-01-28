using System.Text;

namespace Wx.Utility.Secutiry
{
    public class DecryptPwdHelper
    {
        public static string EncodeString(string pwdStr)
        {
            return EncodePwd(EncodePwd(EncodePwd(EncodePwd(EncodePwd(pwdStr)))));
        }

        public static string DecodeString(string pwdStr)
        {
            return DecodePwd(DecodePwd(DecodePwd(DecodePwd(DecodePwd(pwdStr)))));
        }

        public static string EncodePwd(string pwd)
        {
            int iLen = pwd.Length;
            int off = iLen % 94;
            StringBuilder outstr = new StringBuilder();
            int a;
            for (int i = 0; i < pwd.Length; ++i)
            {
                a = (pwd[i] - 33 + off + i % 94) % 94 + 33;
                outstr.Append((char)a);
            }
            return outstr.ToString();
        }

        public static string DecodePwd(string pwd)
        {
            int iLen = pwd.Length;
            int off = iLen % 94;
            int iOff, iDiff;
            StringBuilder outstr = new StringBuilder();
            int a;
            for (int i = 0; i < iLen; ++i)
            {
                iOff = i % 94;
                iDiff = off + iOff - pwd[i] + 33;
                if (iDiff > 0)
                {
                    a = pwd[i] + (iDiff / 95 + 1) * 94 - off - iOff;
                }
                else
                {
                    a = pwd[i] - off - iOff;
                }
                outstr.Append((char)a);
            }
            return outstr.ToString();
        }
    }
}
