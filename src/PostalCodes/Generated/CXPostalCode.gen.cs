using System.Text.RegularExpressions;
using PostalCodes.GenericPostalCodes;

namespace PostalCodes
{
    internal partial class CXPostalCode : AlphaNumericPostalCode
    {
        public CXPostalCode(string postalCode) : this(postalCode, true) {}

        public CXPostalCode(string postalCode, bool allowConvertToShort) : base(_formats, postalCode, allowConvertToShort) 
        {
            _countryName = "CX";
        }
        
        protected override PostalCode CreatePostalCode(string code, bool allowConvertToShort)
        {
            return new CXPostalCode(code, allowConvertToShort);
        }
        
        public override bool Equals (object obj)
        {
            var other = obj as CXPostalCode;
            if (other == null) 
            {
                return false;
            }

            return PostalCodeString.Equals (other.PostalCodeString);
        }

        public override int GetHashCode ()
        {
            return PostalCodeString.GetHashCode ();
        }

        private static PostalCodeFormat[] _formats = {
            new PostalCodeFormat {
                Name = "4-Digits - 9999",
                RegexDefault = new Regex("^[0-9]{4}$", RegexOptions.Compiled),
                OutputDefault = "xxxx",
                AutoConvertToShort = false,
                ShortExpansionAsLowestInRange = "0",
                ShortExpansionAsHighestInRange = "9",
                LeftPaddingCharacter = "0",
            }
        };
    }
}
