using System.Text.RegularExpressions;
using PostalCodes.GenericPostalCodes;

namespace PostalCodes
{
    internal partial class MEPostalCode : AlphaNumericPostalCode
    {
        public MEPostalCode(string postalCode) : this(postalCode, true) {}

        public MEPostalCode(string postalCode, bool allowConvertToShort) : base(_formats, postalCode, allowConvertToShort) 
        {
            _countryName = "ME";
        }
        
        protected override PostalCode CreatePostalCode(string code, bool allowConvertToShort)
        {
            return new MEPostalCode(code, allowConvertToShort);
        }
        
        public override bool Equals (object obj)
        {
            var other = obj as MEPostalCode;
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
                Name = "5-Digits - 99999",
                RegexDefault = new Regex("^[0-9]{5}$", RegexOptions.Compiled),
                OutputDefault = "xxxxx",
                AutoConvertToShort = false,
                ShortExpansionAsLowestInRange = "0",
                ShortExpansionAsHighestInRange = "9",
                LeftPaddingCharacter = "0",
            }
        };
    }
}
