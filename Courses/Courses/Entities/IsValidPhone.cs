namespace Courses.Entities
{
    [Flags]
    public enum ErrorType
    {
        Ok = 1,
        LengthNotValid = 2,
        NotDigits = 4,
        NotStart_05 = 8

    }
    public class IsValidPhone
    {


        public bool IsValid(string phone, out ErrorType errorType)
        {
            int phoneNumber;


            errorType = 0;

            bool isNumber = int.TryParse(phone, out phoneNumber);

            if (!isNumber)
                errorType = ErrorType.NotDigits;
            else
            {
                if (phone.Length != 10)
                    errorType |= ErrorType.LengthNotValid;

                if (phone[0] != '0' || phone[1] != '5')
                    errorType |= ErrorType.NotStart_05;
            }
            if (errorType == 0)
            {
                errorType = ErrorType.Ok;
                return true;
            }

            return false;


        }

    }
}
