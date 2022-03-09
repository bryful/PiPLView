using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
namespace PiPLView
{
	public class PiPLFile
	{
		private byte[] PiPL_BYTE = new byte[] { 0x50, 0x00, 0x49, 0x00, 0x50, 0x00, 0x4C, 0x00 };
		private byte[] PiPL_END = new byte[] { 0x3C, 0x3F, 0x78, 0x6D, 0x6C, 0x20 };

		private string m_path = "";
		private byte[]  m_buf = new byte[0];

		public int PF_PLUG_IN_VERSION = 0;
		public int PF_PLUG_IN_SUBVERS = 0;

		public int AE_Effect_Global_OutFlags = 0;
		public int AE_Effect_Global_OutFlags_2 = 0;
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
			ret += String.Format("PF_PLUG_IN_VERSION = {0}\r\n", PF_PLUG_IN_VERSION);
			ret += String.Format("PF_PLUG_IN_SUBVERS = {0}\r\n", PF_PLUG_IN_SUBVERS);

			if ((PF_PLUG_IN_VERSION == 13) && (PF_PLUG_IN_SUBVERS >= 27))
			{
				ret += "SDK AE2022\r\n";
			}
			else if ((PF_PLUG_IN_VERSION == 13) && (PF_PLUG_IN_SUBVERS >= 20))
			{
				ret += "SDK CC2020\r\n";
			}
			else if ((PF_PLUG_IN_VERSION == 13) && (PF_PLUG_IN_SUBVERS >= 17))
			{
				ret += "SDK CC2019\r\n";
			}
			else if ((PF_PLUG_IN_VERSION == 13) && (PF_PLUG_IN_SUBVERS >= 15))
			{
				ret += "SDK CC2018\r\n";
			}
			else if ((PF_PLUG_IN_VERSION == 13) && (PF_PLUG_IN_SUBVERS >= 9))
			{
				ret += "SDK CC2015\r\n";
			}
			else if ((PF_PLUG_IN_VERSION == 13) && (PF_PLUG_IN_SUBVERS >= 2))
			{
				ret += "SDK CS6\r\n";
			}
			else
			{
				ret += "SDK 超古い\r\n";
			}


			ret += String.Format("AE_Effect_Global_OutFlags = {0}\r\n", AE_Effect_Global_OutFlags);
			ret += String.Format("AE_Effect_Global_OutFlags_2 = {0}\r\n", AE_Effect_Global_OutFlags_2);
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
			return FindByte(buf, PiPL_END, start);
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

		}
	}
}
