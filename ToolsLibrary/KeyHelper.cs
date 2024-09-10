
using System.Windows.Input;

namespace ToolsLibrary
{
    public struct ValidKeysForNumberInRadixSystems
    {
        public Key FirstValidKey;
        public Key SecondValidKey;
        public bool IsKeyALetter;

        public ValidKeysForNumberInRadixSystems(Key FirstValidKey,
                                                Key SecondValidKey,
                                                bool IsKeyALetter)
        {
            this.FirstValidKey = FirstValidKey;
            this.SecondValidKey = SecondValidKey;
            this.IsKeyALetter = IsKeyALetter;
        }
    }
    public class KeyHelper
    {
        public static bool IsKeyPressedValidPositiveInteger(Key ThisKey)
        {
            if ((ThisKey >= Key.D0 && ThisKey <= Key.D9) ||
                (ThisKey >= Key.NumPad0 && ThisKey <= Key.NumPad9))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsKeyPressedValidBinaryInteger(Key ThisKey)
        {
            if ((ThisKey >= Key.D0 && ThisKey <= Key.D1) ||
                (ThisKey >= Key.NumPad0 && ThisKey <= Key.NumPad1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsKeyPressedValidForCurrentNumberSystem(Key ThisKey,
                                                                   ValidKeysForNumberInRadixSystems[] ThisRadixNumberSystemArray,
                                                                   int NumberOfifferentDigitsInRadixSystem) 
        {
            int Counter = 0;

            do
            {
                if (false == ThisRadixNumberSystemArray[Counter].IsKeyALetter)
                {
                    if ( (ThisKey == ThisRadixNumberSystemArray[Counter].FirstValidKey) ||
                         (ThisKey == ThisRadixNumberSystemArray[Counter].SecondValidKey) )
                    {
                        return (true);
                    }
                }
                else
                {
                    if ( (ThisKey == ThisRadixNumberSystemArray[Counter].FirstValidKey) ||
                         ((char)ThisKey == ThisRadixNumberSystemArray[Counter].FirstValidKey.ToString().ToLower()[0]))
                    {
                        return (true);
                    }
                }
                Counter++;
            } while (Counter < NumberOfifferentDigitsInRadixSystem);
            
            return (false);
        }

        public static bool IsKeyPressedValidInSpecifiedKeyArray(Key ThisKey,
                                                                Key[] ThisKeyArray)
        {
            int Counter = 0;

            do
            {
                if (ThisKeyArray[Counter] == ThisKey)
                {  
                    return (true); 
                }
                else
                {
                    Counter++;
                }
            } while (Counter < ThisKeyArray.Length);

            return (false);
        }
    }

}
