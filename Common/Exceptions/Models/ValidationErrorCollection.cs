using System.Collections;
using System.Text;

namespace Common.Exceptions.Models
{
    /// <summary>
    /// A collection of ValidationError objects that is used to collect
    /// errors that occur doing calls to the Validate method.
    /// </summary>
    public class ValidationErrorCollection : CollectionBase
    {
        /// <summary>
        /// Indexer property for the collection that returns and sets an item
        /// </summary>
        public ValidationError this[int index]
        {
            get => (ValidationError) this.List[index];
            set => this.List[index] = (object) value;
        }

        /// <summary>
        /// Adds a new error to the collection
        /// <seealso>Class ValidationError</seealso>
        /// </summary>
        /// <param name="error">Validation Error object</param>
        /// <returns>Void</returns>
        public void Add(ValidationError error)
        {
            this.List.Add((object) error);
        }

        /// <summary>
        /// Adds a new error to the collection
        /// <seealso>Class ValidationErrorCollection</seealso>
        /// </summary>
        /// <param name="message">Message of the error</param>
        /// <param name="fieldName">
        /// optional field name that it applies to (used for Databinding errors on
        /// controls)
        /// </param>
        /// <param name="id">An optional ID you assign the error</param>
        /// <returns>Void</returns>
        public void Add(string message, string fieldName = "", string id = "")
        {
            this.Add(new ValidationError()
            {
                Message = message,
                ControlID = fieldName,
                ID = id
            });
        }

        /// <summary>Like Add but allows specifying of a format</summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        /// <param name="id"></param>
        /// <param name="arguments"></param>
        public void AddFormat(string message, string fieldName, string id, params object[] arguments)
        {
            this.Add(string.Format(message, arguments), fieldName, id);
        }

        /// <summary>
        /// Removes the item specified in the index from the Error collection
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            if (index <= this.List.Count - 1 && index >= 0)
                return;
            this.List.RemoveAt(index);
        }

        /// <summary>
        /// Adds a validation error if the condition is true. Otherwise no item is
        /// added.
        /// <seealso>Class ValidationErrorCollection</seealso>
        /// </summary>
        /// <param name="condition">
        /// If true this error is added. Otherwise not.
        /// </param>
        /// <param name="message">The message for this error</param>
        /// <param name="fieldName">
        /// Name of the UI field (optional) that this error relates to. Used optionally
        ///  by the data binding classes.
        /// </param>
        /// <param name="id">An optional Error ID.</param>
        /// <returns>value of condition</returns>
        public bool Assert(bool condition, string message, string fieldName, string id)
        {
            if (condition)
                this.Add(message, fieldName, id);
            return condition;
        }

        /// <summary>
        /// Adds a validation error if the condition is true. Otherwise no item is
        /// added.
        /// <seealso>Class ValidationErrorCollection</seealso>
        /// </summary>
        /// <param name="condition">If true the Validation Error is added.</param>
        /// <param name="message">The Error Message for this error.</param>
        /// <returns>value of condition</returns>
        public bool Assert(bool condition, string message)
        {
            if (condition)
                this.Add(message, "", "");
            return condition;
        }

        /// <summary>
        /// Adds a validation error if the condition is true. Otherwise no item is
        /// added.
        /// <seealso>Class ValidationErrorCollection</seealso>
        /// </summary>
        /// <param name="condition">If true the Validation Error is added.</param>
        /// <param name="message">The Error Message for this error.</param>
        /// <param name="fieldName"></param>
        /// <returns>string</returns>
        public bool Assert(bool condition, string message, string fieldName)
        {
            if (condition)
                this.Add(message, fieldName, "");
            return condition;
        }

        /// <summary>
        /// Asserts a business rule - if condition is true it's added otherwise not.
        /// <seealso>Class ValidationErrorCollection</seealso>
        /// </summary>
        /// <param name="condition">
        /// If this condition evaluates to true the Validation Error is added
        /// </param>
        /// <param name="error">Validation Error Object</param>
        /// <returns>value of condition</returns>
        public bool Assert(bool condition, ValidationError error)
        {
            if (condition)
                this.List.Add((object) error);
            return condition;
        }

        /// <summary>
        /// Returns a string representation of the errors in this collection.
        /// The string is separated by CR LF after each line.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.Count < 1)
                return "";
            StringBuilder stringBuilder = new StringBuilder(128);
            foreach (ValidationError validationError in (CollectionBase) this)
                stringBuilder.AppendLine(validationError.Message);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns an HTML representation of the errors in this collection.
        /// The string is returned as an HTML unordered list.
        /// </summary>
        /// <returns></returns>
        public string ToHtml()
        {
            if (this.Count < 1)
                return "";
            StringBuilder stringBuilder = new StringBuilder(256);
            stringBuilder.Append("<ul>\r\n");
            foreach (ValidationError validationError in (CollectionBase) this)
            {
                stringBuilder.Append("<li>");
                if (!string.IsNullOrEmpty(validationError.ControlID))
                    stringBuilder.AppendFormat("<a href='#' onclick=\"_errorLinkClick('{0}');return false;\" style='text-decoration:none'>{1}</a>", (object) validationError.ControlID.Replace(".", "_"), (object) validationError.Message);
                else
                    stringBuilder.Append(validationError.Message);
                stringBuilder.AppendLine("</li>");
            }
            stringBuilder.Append("</ul>\r\n");
            string str = "    <script>\r\n        function _errorLinkClick(id) {\r\n            var $t = $('#' + id).focus().addClass('errorhighlight');            \r\n            setTimeout(function() {\r\n                $t.removeClass('errorhighlight');\r\n            }, 5000);\r\n        }\r\n    </script>";
            stringBuilder.AppendLine(str);
            return stringBuilder.ToString();
        }
    }
}
