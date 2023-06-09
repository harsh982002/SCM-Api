using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Constant
{
    public static class MessageConstant
    {
        public const string RequestSuccessful = "Request successful."; // If api response successfully.

        public const string RequestUnSuccessful = "Request unsuccessful."; // If api response failed.

        public const string RequestnotFound = "Data not found"; // If data not found.

        public const string RequestDuplicateFileFound = "File with same name already exists, do you want to overwrite the file?"; // If same file found.

        public const string CaptchaValidationFail = "Error validating captcha token"; // If captcha validation fail.

        public const string NotReadyRequisitionError = "This step is not in ready state, you cannot modify this requisition."; // If requisition is not in ready state.

        public const string FileNameLongError = "The file name is too long. Rename the file and upload again."; // If Filename is too long.

        public const string DuplicateEntry = "Data already exist."; // If data is already in database
    }
}
