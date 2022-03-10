using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
namespace PiPLInfo
{



	public class PiPLFile
	{
		private byte[] PiPL_BYTE = new byte[] { 0x50, 0x00, 0x49, 0x00, 0x50, 0x00, 0x4C, 0x00 };
		private byte[] PiPL_END = new byte[] { 0x3C, 0x3F, 0x78, 0x6D, 0x6C, 0x20 };
		private byte[] PiPL_END2 = new byte[] { 0x3C,0x61};

		private string m_path = "";
		private byte[]  m_buf = new byte[0];

		public int PF_PLUG_IN_VERSION = 0;
		public int PF_PLUG_IN_SUBVERS = 0;

		public int AE_Effect_Global_OutFlags = 0;
		public int AE_Effect_Global_OutFlags_2 = 0;

		public string Name = "";
		public string Category = "";
		public string MatchName = "";

		public int MAJOR_VERSION = 0;
		public int MINOR_VERSION = 0;
		public int BUG_VERSION = 0;
		public int STAGE_VERSION = 0;
		public int BUILD_VERSION = 0;

		private AEVersions aev = new AEVersions();
		public PiPLFile(string p)
		{
			if (LoadFile(p))
			{
				analysis();
			}

		}
		public string DispByte()
		{
			string ret = "";
			if (m_buf.Length <= 0) return ret;
			ret += "\r\n";
			ret += " Category: " + Category + "\r\n";
			ret += "     Name: " + Name + "\r\n";
			ret += "MatchName: " + MatchName + "\r\n";
			ret += "\r\n";
			ret += String.Format("MAJOR_VERSION:{0}\r\n",MAJOR_VERSION);
			ret += String.Format("MINOR_VERSION:{0}\r\n", MINOR_VERSION);
			ret += String.Format("BUG_VERSION:{0}\r\n", BUG_VERSION);
			ret += "STAGE_VERSION:";
			switch(STAGE_VERSION)
			{
				case 0: 
					ret += "PF_Stage_DEVELOP";break;
				case 1:
					ret += "PF_Stage_ALPHA"; break;
				case 2:
					ret += "PF_Stage_BETA"; break;
				case 3:
				default:
					ret += "PF_Stage_RELEASE"; break;
			}
			ret += "\r\n";
			ret += String.Format("BUILD_VERSION:{0}\r\n", BUILD_VERSION);
			ret += "\r\n";

			ret += "SDK Version" + aev.Caption(PF_PLUG_IN_VERSION, PF_PLUG_IN_SUBVERS) + "\r\n";
			ret += "\r\n";
			ret += String.Format("AE_Effect_Global_OutFlags = {0}\r\n", AE_Effect_Global_OutFlags);
			ret += AEoutflags.flg0(AE_Effect_Global_OutFlags);
			ret += "\r\n";

			ret += String.Format("AE_Effect_Global_OutFlags_2 = {0}\r\n", AE_Effect_Global_OutFlags_2);
			ret += AEoutflags.flg2(AE_Effect_Global_OutFlags_2);
			ret += "\r\n";
			return ret;
		}
		private int FindByte(byte[] buf,byte[] tag, int start = 0)
		{
			int ret = -1;
			if ((buf.Length <= 0) || (start >= buf.Length)||(tag.Length<=0)) return ret;

			for(int i=start;i<(buf.Length-tag.Length);i++)
			{
				if (buf[i]==tag[0])
				{
					bool flg = true;
					for(int j=1;j<tag.Length;j++)
					{
						if (buf[i+j]!=tag[j])
						{
							flg = false;
							break;
						}
					}
					if(flg)
					{
						ret = i;
						break;
					}
				}
			}
			return ret;
		}
		private int FindPiPL(byte[] buf)
		{
			return FindByte(buf, PiPL_BYTE, 0);
		}
		private int FindPiPLEnd(byte[] buf,int start)
		{
			int ret = -1;
			ret = FindByte(buf, PiPL_END, start);
			if (ret<0) ret = FindByte(buf, PiPL_END2, start);
			return ret;
		}
		public bool LoadFile(string p)
		{
			bool ret = false;
			m_buf = new byte[0];

			if (File.Exists(p) == false)
			{
				return ret;
			}
			FileStream fs = new FileStream(
				p,
				FileMode.Open,
				FileAccess.Read);
			byte[] bs = new byte[fs.Length];
			try
			{
				int sz = fs.Read(bs, 0, bs.Length);
				if (sz==bs.Length)
				{
					int idx = FindPiPL(bs);
					if (idx >= 0)
					{
						int en = FindPiPLEnd(bs, idx);
						if (en>idx)
						{
							int szz = en - idx;
							m_buf = new byte[szz];
							for (int i=0;i<szz;i++)
							{
								m_buf[i] = bs[i + idx];
							}
							ret = true;
						}

					}
				}

			}
			finally
			{
				fs.Close();
			}
			return ret;
		}

		private void analysis()
		{
			if (m_buf.Length <= 0) return;
			int idx = -1;
			byte[] MIB8RVSe = new byte[] { 0x4D, 0x49, 0x42, 0x38, 0x52, 0x56, 0x53, 0x65 };
			idx = FindByte(m_buf, MIB8RVSe, 0);
			if(idx>=0)
			{
				PF_PLUG_IN_VERSION = (int)m_buf[idx + 16];
				PF_PLUG_IN_SUBVERS = (int)m_buf[idx + 18];

			}
			byte[] MIB8OLGe = new byte[] { 0x4D, 0x49, 0x42, 0x38, 0x4F, 0x4C, 0x47, 0x65 };
			int idx2  = FindByte(m_buf, MIB8OLGe, 0);
			AE_Effect_Global_OutFlags = 0;
			if (idx2 >= 0)
			{
				AE_Effect_Global_OutFlags = (int)m_buf[idx2 + 16] | (int)m_buf[idx2 + 17] << 8 | (int)m_buf[idx2 + 18] << 16 | (int)m_buf[idx2 + 19] << 24;
			}
			// MIB82LGe 4D 49 42 38 32 4C 47 65
			byte[] MIB82LGe = new byte[] { 0x4D, 0x49, 0x42, 0x38, 0x32, 0x4C, 0x47, 0x65 };
			int idx3 = FindByte(m_buf, MIB82LGe, idx2);
			AE_Effect_Global_OutFlags_2 = 0;
			if (idx3 >= 0)
			{
				AE_Effect_Global_OutFlags_2 = (int)m_buf[idx3 + 16] | (int)m_buf[idx3 + 17] << 8 | (int)m_buf[idx3 + 18] << 16 | (int)m_buf[idx3 + 19] << 24;
			}

			Name = "";
			byte[] MIB8eman = new byte[] { 0x4D, 0x49, 0x42, 0x38, 0x65, 0x6D, 0x61, 0x6E };
			
			idx = FindByte(m_buf, MIB8eman, 0);
			if (idx>=0)
			{
				int sz = (int)m_buf[idx + 16];
				if (sz > 0)
				{
					byte[] bb = new byte[sz];
					for ( int i=0; i<sz;i++)
					{
						bb[i] = m_buf[idx + 17 + i];
					}
					string s = Encoding.GetEncoding("shift_jis").GetString(bb);
					Name = s;
				}
			}
			Category = "";
			byte[] MIB8gtac = new byte[] { 0x4D, 0x49, 0x42, 0x38, 0x67, 0x74, 0x61, 0x63 };
			idx = FindByte(m_buf, MIB8gtac, 0);
			if (idx >= 0)
			{
				int sz = (int)m_buf[idx + 16];
				if (sz > 0)
				{
					byte[] bb = new byte[sz];
					for (int i = 0; i < sz; i++)
					{
						bb[i] = m_buf[idx + 17 + i];
					}
					string s = Encoding.GetEncoding("shift_jis").GetString(bb);
					Category = s;
				}
			}
			MatchName = "";
			byte[] MIB8ANMe = new byte [] { 0x4D, 0x49, 0x42, 0x38, 0x41, 0x4E, 0x4D, 0x65 };
			idx = FindByte(m_buf, MIB8ANMe, 0);
			if (idx >= 0)
			{
				int sz = (int)m_buf[idx + 16];
				if (sz > 0)
				{
					byte[] bb = new byte[sz];
					for (int i = 0; i < sz; i++)
					{
						bb[i] = m_buf[idx + 17 + i];
					}
					string s = Encoding.GetEncoding("shift_jis").GetString(bb);
					MatchName = s;
				}
			}
			byte[] MIB8REVe = new byte[] { 0x4D, 0x49, 0x42, 0x38, 0x52, 0x45, 0x56, 0x65 };
			idx = FindByte(m_buf, MIB8REVe, 0);
			if (idx >= 0)
			{
				uint v = 0;
				v = (uint)m_buf[idx + 16] | (uint)m_buf[idx + 17] << 8 | (uint)m_buf[idx + 18] << 16 | (uint)m_buf[idx + 19] << 24;

				BUILD_VERSION = (int)(v & 0x1FF);
				STAGE_VERSION = (int)((v>>9) & 0x3);
				BUG_VERSION = (int)((v >> 11) & 0xf);
				MINOR_VERSION = (int)((v >> 15) & 0xf);
				MAJOR_VERSION = (int)((v >> 19) & 0x7);
			}

		}
	}
}
