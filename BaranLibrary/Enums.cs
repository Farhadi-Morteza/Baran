namespace Baran.Windows.Forms
{
    //Input Language
    public enum InputLanguage
    {
        /// <summary>
        /// فارسی
        /// </summary>
        Farsi,
        /// <summary>
        /// انگليسی
        /// </summary>
        English
    }

    //Text Modes
    public enum InputType
    {
        /// <summary>
        /// متنی
        /// </summary>
        Text,
        /// <summary>
        /// عددی
        /// </summary>
        Numeric,
        /// <summary>
        /// پولی
        /// </summary>
        Currency,
        /// <summary>
        /// تاریخ
        /// </summary>
        Date
    }

    public enum DateFormat
    {
        yymmdd = 0,
        yyyymmdd = 1
    }

    public enum Editable
    {
        Editable,
        Immutable
    }

}

