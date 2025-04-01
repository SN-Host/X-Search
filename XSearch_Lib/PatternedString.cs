using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSearch_Lib
{
    public class PatternedString
    {
        // CONSTANTS //

        /// <summary>
        /// Title of for any errors pertaining to missing placeholder patterns.
        /// </summary>
        public const string TOOLTIP_TITLE_WARNING_NOPLACEHOLDER = "Missing placeholder";

        // FIELDS //

        /// <summary>
        /// Determines the strings that must be present in a setter call to RawPattern to avoid input rejection.
        /// If AllowInvalidRawPatternSets is set to true, lacking these won't prevent input but will still call the rejection event.
        /// </summary>
        public HashSet<string> RequiredPlaceholderPatterns;

        private string rawPattern = string.Empty;

        // CONSTRUCTORS // 

        /// <summary>
        /// Exists only for the purposes of XML serialization. Do not use to create new instances.
        /// </summary>
        private PatternedString()
        {
            RequiredPlaceholderPatterns = new HashSet<string>();
            RawPatternPredicate = DefaultPatternPredicate;
        }

        public PatternedString(HashSet<string>? requiredPlaceholderPatterns = null, Action<ErrorReportArgs>? predicateFailedAction = null)
        {
            RawPatternPredicate = DefaultPatternPredicate;
            RequiredPlaceholderPatterns = requiredPlaceholderPatterns ?? new HashSet<string>();
            RawPattern = String.Join(string.Empty, RequiredPlaceholderPatterns);
            if (predicateFailedAction is Action<ErrorReportArgs> action)
            {
                PredicateFailedAction = action;
            }
        }

        // PROPERTIES //

        /// <summary>
        /// Whether or not this PatternedString is allowed to be set to values that don't include all required placeholders.
        /// </summary>
        public bool AllowInvalidRawPatternSets { get; set; } = false;

        /// <summary>
        /// Gets or sets the full formatted PatterenedString with all its placeholders.
        /// </summary>
        public string RawPattern
        {
            get
            {
                return rawPattern;
            }
            set
            {
                // Avoid the set if we don't pass the predicate and do not allow invalid raw pattern inputs.
                if (!RawPatternPredicate(value) && !AllowInvalidRawPatternSets)
                {
                    return;
                }

                rawPattern = value;
            }
        }

        /// <summary>
        /// Action to take upon failing validation when attempting to set RawPattern.
        /// </summary>
        [XmlIgnore]
        public Action<ErrorReportArgs> PredicateFailedAction { get; set; } = delegate { };

        /// <summary>
        /// Predicate to test the validity of a PatternedString RawPattern when setting it.
        /// </summary>
        [XmlIgnore]
        public Predicate<string> RawPatternPredicate { get; set; }

        // METHODS //

        /// <summary>
        /// Default predicate for checking validity of an entered string's validity for this pattern.
        /// </summary>
        /// <param name="rawPattern"></param>
        /// <returns></returns>
        private bool DefaultPatternPredicate(string rawPattern)
        {
            bool validated = true;
            string tooltipTitle = string.Empty;
            string tooltipText = string.Empty;

            // Validate presence of placeholder patterns.
            if (!ValidatePlaceholderPatterns(RequiredPlaceholderPatterns, rawPattern, ref tooltipTitle, ref tooltipText))
            {
                validated = false;
            }

            // Run action if validation failed.
            if (!validated)
            {
                PredicateFailedAction(new ErrorReportArgs(tooltipTitle, tooltipText));
                //OnSearchUrlPatternRejected(this, new ErrorReportArgs(tooltipTitle, tooltipText));
            }

            return validated;
        }

        /// <summary>
        /// Ensures a source string contains a given set of placeholder patterns.
        /// </summary>
        /// <param name="placeholderPatterns">The array of placeholder patterns to confirm.</param>
        /// <param name="source">The source text to check.</param>
        /// <param name="tooltipTitle">The string to hold outputted tooltip title text, if any.</param>
        /// <param name="tooltipText">The string to hold outputted tooltip body text, if any.</param>
        /// <returns>True if all placeholder patterns were found, false otherwise.</returns>
        private bool ValidatePlaceholderPatterns(HashSet<string> placeholderPatterns, string source, ref string tooltipTitle, ref string tooltipText)
        {
            bool validated = true;

            foreach (string placeholderPattern in placeholderPatterns)
            {
                if (!Regex.Matches(source, placeholderPattern).Any())
                {
                    tooltipTitle += tooltipTitle == string.Empty ? TOOLTIP_TITLE_WARNING_NOPLACEHOLDER : ", " + TOOLTIP_TITLE_WARNING_NOPLACEHOLDER;

                    // TODO: Replace with constant?
                    string tmpTooltipText = string.Format("You must include the placeholder pattern {0}.", placeholderPattern);

                    // Change tooltip string if this pattern allows invalid inputs.
                    if (AllowInvalidRawPatternSets)
                    {
                        tmpTooltipText = string.Format("You have not included the placeholder pattern {0}. This will limit dynamic generation of this input.", placeholderPattern);
                    }

                    tooltipText += tooltipText == string.Empty ? tmpTooltipText : "\n" + tmpTooltipText;

                    validated = false;
                }
            }

            return validated;
        }

    }
}
