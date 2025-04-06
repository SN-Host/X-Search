using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using HtmlAgilityPack;
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

        /// <summary>
        /// Serializes a domain profile to XML given a stream.
        /// </summary>
		public void SaveToFile(Stream stream, string filePath)
		{
			LastFilePath = filePath;

			XmlSerializer serializer = new XmlSerializer(typeof(DomainProfile));

			serializer.Serialize(stream, this);

			stream.Close();
        }

        /// <summary>
        /// Deserializes a domain profile from XML given a stream.
        /// </summary>
        public void LoadFromFile(Stream stream, Action<Domain, ErrorReportArgs> onSearchUrlPatternRejected)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DomainProfile));

            DomainProfile? profile = serializer.Deserialize(stream) as DomainProfile;

            if (profile == null)
            {
                return;
            }

            // Clear current domains to make way for the new.
            Domains.Clear();

            foreach (Domain domain in profile.Domains)
            {
                // Ensure domains handle search URL pattern events on reload.
                domain.OnSearchUrlPatternRejected += (sender, e) => onSearchUrlPatternRejected(sender, e);

                Domains.Add(domain);
            }

            stream.Close();
        }
    }
}
