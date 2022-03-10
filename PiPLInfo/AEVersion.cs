using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiPLInfo
{
	public static class AE
	{
		public static readonly int[][] aaa = new int[][]
		{
		};
		public static readonly int PF_AE220_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE220_PLUG_IN_SUBVERS = 27;
		public static readonly int PF_AE184_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE184_PLUG_IN_SUBVERS = 26;
		public static readonly int PF_AE182_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE182_PLUG_IN_SUBVERS = 25;
		public static readonly int PF_AE180_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE180_PLUG_IN_SUBVERS = 24;
		public static readonly int PF_AE177_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE177_PLUG_IN_SUBVERS = 23;
		public static readonly int PF_AE176_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE176_PLUG_IN_SUBVERS = 22;
		public static readonly int PF_AE175_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE175_PLUG_IN_SUBVERS = 21;
		public static readonly int PF_AE171_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE171_PLUG_IN_SUBVERS = 20;
		public static readonly int PF_AE170_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE170_PLUG_IN_SUBVERS = 18;
		public static readonly int PF_AE161_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE161_PLUG_IN_SUBVERS = 17;
		public static readonly int PF_AE160_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE160_PLUG_IN_SUBVERS = 16;
		public static readonly int PF_AE151_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE151_PLUG_IN_SUBVERS = 15;
		public static readonly int PF_AE150_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE150_PLUG_IN_SUBVERS = 15;
		public static readonly int PF_AE142_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE142_PLUG_IN_SUBVRS = 14;
		public static readonly int PF_AE140_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE140_PLUG_IN_SUBVERS = 13;
		public static readonly int PF_AE138_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE138_PLUG_IN_SUBVERS = 11;
		public static readonly int PF_AE136_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE136_PLUG_IN_SUBVERS = 10;
		public static readonly int PF_AE135_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE135_PLUG_IN_SUBVERS = 9;
		public static readonly int PF_AE130_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE130_PLUG_IN_SUBVERS = 7;
		public static readonly int PF_AE122_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE122_PLUG_IN_SUBVERS = 6;
		public static readonly int PF_AE121_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE121_PLUG_IN_SUBVERS = 5;
		public static readonly int PF_AE120_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE120_PLUG_IN_SUBVERS = 4;
		public static readonly int PF_AE1101_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE1101_PLUG_IN_SUBVERS = 3;
		public static readonly int PF_AE110_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE110_PLUG_IN_SUBVERS = 2;
		public static readonly int PF_AE105_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE105_PLUG_IN_SUBVERS = 1;
		public static readonly int PF_AE100_PLUG_IN_VERSION = 13;
		public static readonly int PF_AE100_PLUG_IN_SUBVERS = 0;
		public static readonly int PF_AE90_PLUG_IN_VERSION = 12;
		public static readonly int PF_AE90_PLUG_IN_SUBVERS = 14;
		public static readonly int PF_AE80_PLUG_IN_VERSION = 12;
		public static readonly int PF_AE80_PLUG_IN_SUBVERS = 13;
		public static readonly int PF_AE70_PLUG_IN_VERSION = 12;
		public static readonly int PF_AE70_PLUG_IN_SUBVERS = 12;
		public static readonly int PF_AE65_PLUG_IN_VERSION = 12;
		public static readonly int PF_AE65_PLUG_IN_SUBVERS = 11;
		public static readonly int PF_AE41_PLUG_IN_VERSION = 12;
		public static readonly int PF_AE41_PLUG_IN_SUBVERS = 2;
		public static readonly int PF_AE40_PLUG_IN_VERSION = 12;
		public static readonly int PF_AE40_PLUG_IN_SUBVERS = 1;
		public static readonly int PF_AE31_PLUG_IN_VERSION = 11;
		public static readonly int PF_AE31_PLUG_IN_SUBVERS = 6;
		public static readonly int PF_AE31_PLUG_IN_SUBVERS_STRICTIFY = 8;
	}
	// ******************************************************
	public class AEVersion
	{
		private string m_name = "AE31";
		private int m_version = 11;
		private int m_subvers = 6;
		// **************************************
		public AEVersion(int v, int sv,string nm)
		{
			m_version = v;
			m_subvers = sv;
			m_name = nm;
		}
		// **************************************
		public string name { get { return m_name; } }
		public int version { get { return m_version; } }
		public int subvers { get { return m_subvers; } }
	}
	public class AEVersions
	{
		private List<AEVersion> m_versions= new List<AEVersion>();
		// **************************************
		public AEVersions()
		{
			m_versions.Add(new AEVersion(11, 6, "AE31"));
			m_versions.Add(new AEVersion(12, 1, "AE40"));
			m_versions.Add(new AEVersion(12, 2, "AE41"));
			m_versions.Add(new AEVersion(12, 11, "AE65"));
			m_versions.Add(new AEVersion(12, 12, "AE70"));
			m_versions.Add(new AEVersion(12, 13, "AE80(CS3)"));
			m_versions.Add(new AEVersion(12, 14, "AE90(CS4/CS5)"));
			m_versions.Add(new AEVersion(13, 0, "AE100(CS5)"));
			m_versions.Add(new AEVersion(13, 1, "AE105(CS5.5)"));
			m_versions.Add(new AEVersion(13, 2, "AE110(CS6)"));
			m_versions.Add(new AEVersion(13, 3, "AE1101(CS6)"));
			m_versions.Add(new AEVersion(13, 4, "AE120(CC)"));
			m_versions.Add(new AEVersion(13, 5, "AE121(CC)"));
			m_versions.Add(new AEVersion(13, 6, "AE122(CC)"));
			m_versions.Add(new AEVersion(13, 7, "AE130(CC2014)"));
			m_versions.Add(new AEVersion(13, 9, "AE135(CC2015)"));
			m_versions.Add(new AEVersion(13, 10, "AE136(CC2015)"));
			m_versions.Add(new AEVersion(13, 11, "AE138(CC2015)"));
			m_versions.Add(new AEVersion(13, 13, "AE140(CC2017)"));
			m_versions.Add(new AEVersion(13, 14, "AE142(CC2017)"));
			m_versions.Add(new AEVersion(13, 15, "AE150(CC2018)"));
			m_versions.Add(new AEVersion(13, 15, "AE151(CC2018)"));
			m_versions.Add(new AEVersion(13, 16, "AE160(CC2019)"));
			m_versions.Add(new AEVersion(13, 17, "AE161(CC2019)"));
			m_versions.Add(new AEVersion(13, 18, "AE170(CC2020)"));
			m_versions.Add(new AEVersion(13, 20, "AE171(CC2020)"));
			m_versions.Add(new AEVersion(13, 21, "AE175(CC2020)"));
			m_versions.Add(new AEVersion(13, 22, "AE176(CC2020)"));
			m_versions.Add(new AEVersion(13, 23, "AE177(CC2020)"));
			m_versions.Add(new AEVersion(13, 24, "AE180(CC2021)"));
			m_versions.Add(new AEVersion(13, 25, "AE182(CC2021)"));
			m_versions.Add(new AEVersion(13, 26, "AE184(CC2021)"));
			m_versions.Add(new AEVersion(13, 27, "AE220(CC2022)"));
		}
		public string Caption(int idx)
		{
			if (idx<0)
			{
				return "errer";
			}
			if (idx < m_versions.Count)
			{
				return m_versions[idx].name;
			}
			else
			{
				return m_versions[m_versions.Count - 1].name + " later";
			}
		}
		// *******************************************************************
		public string Caption(int v,int mv)
		{
			int idx = -1;
			if (m_versions.Count>0)
			{
				int vv = v * 100 +  mv;
				for(int i= m_versions.Count-1; i>=0 ;i--)
				{
					int vv2 = m_versions[i].version * 100 + m_versions[i].subvers;
					if (vv2<=vv)
					{
						idx = i;
						break;
					}
				}
			}
			return Caption(idx);
		}
		// *******************************************************************
		public string[] CaptionList
		{
			get
			{
				List<string> ret = new List<string>();
				for(int i=0; i<m_versions.Count;i++)
				{
					ret.Add(m_versions[i].name);
				}
				return ret.ToArray();
			}
		}
		// *******************************************************************

	}
}
