using OtpNet;
using System;


/**
* @author Umair Qayyum
*
* @date - 5/29/2019 11:35:04 AM 
*/

namespace Simple_OTP_Generator
{
    public static class OTP_Generator
    {
        /// <summary>
        /// Generates a 6 digit code based on the secret key provided with maximum 30 seconds validity of the code.
        /// Usually takes upto 28 seconds to generate the code based on the timeline.
        /// </summary>
        /// <param name="key"> secret key</param>
        /// <returns>6 digit OTP code</returns>
        public static string generateOTPwithMaximumValidity(string key)
        {
            string code = "-1";
            try
            {
                var totp = new Totp(Base32Encoding.ToBytes(key));
                while (totp.RemainingSeconds() < 29) { }
                code = totp.ComputeTotp(DateTime.UtcNow).PadLeft(6, '0');
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return code;
        }

        /// <summary>
        /// Generates a 6 digit code based on the secret key provided with random validity time of the code.
        /// instantly generates the code but does not guaranty the code validity in seconds.
        /// </summary>
        /// <param name="key"> secret key</param>
        /// <returns>6 digit OTP code</returns>
        public static string generateinstantOTP(string key)
        {
            string code = "-1";
            try
            {
                var totp = new Totp(Base32Encoding.ToBytes(key));
                code = totp.ComputeTotp(DateTime.UtcNow).PadLeft(6, '0');
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return code;
        }
    }
}
