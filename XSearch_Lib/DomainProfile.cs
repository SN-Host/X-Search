using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using HtmlAgilityPack;
using static XSearch_Lib.SearchHandler;
using static XSearch_Lib.XSearch_Strings;

namespace XSearch_Lib
{
	/// <summary>
	/// Intended to hold information about domain profiles for saving/loading purposes.
	/// </summary>
	public class DomainProfile
	{

		/// <summary>
		/// Previous save location of a domain profile, if any.
		/// </summary>
		public string? LastFilePath { get; set; } = null;

		/// <summary>
		/// Must be left public so DataGridViews can use this as a datasource.
		/// </summary>
		public BindingList<Domain> Domains { get; set; } = new BindingList<Domain>();

		[XmlIgnore]
		public IEnumerable<Domain> ActiveDomains => Domains.Where(x => x.Active);

		public string GetNewIdForDomain(Domain domain)
		{
			string newId = domain.GetHashCode().ToString();

			// If the ID is already used in the domain, come up with a new one.
			while (Domains.Where(x => x.DomainId == newId).Count() > 0)
			{
				// What to do here to modify the hash code, if anything?
			}

			return newId;
		}

		public void SaveDomainProfile(Stream stream, string filePath)
		{
			LastFilePath = filePath;

			XmlSerializer serializer = new XmlSerializer(typeof(DomainProfile));

			serializer.Serialize(stream, this);

			stream.Close();
		}

	}
}
