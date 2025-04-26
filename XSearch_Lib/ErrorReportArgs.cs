namespace XSearch_Lib
{
    /// <summary>
    /// General purpose class for storing information about errors for event handlers.
    /// </summary>
    public class ErrorReportArgs
    {
        public string ErrorTitle
        {
            get
            {
                return errorTitle;
            }
        }
        private string errorTitle;

        public string ErrorText
        {
            get
            {
                return errorText;
            }
        }
        private string errorText;

        public ErrorReportArgs(string errorTitle, string errorText)
        {
            this.errorTitle = errorTitle;
            this.errorText = errorText;
        }
    }

}
