using Utility;

namespace FunctionCreator
{
    [System.Serializable]
    public class FunctionComponent
    {
        public string value;
        private FunctionUtility.FunctionalityType type;
        public float assistiveNumber;

        public FunctionComponent()
        {
            value = FunctionUtility.x;
            type = FunctionUtility.FunctionalityType.X;
            assistiveNumber = 0;
        }
        //CTOR
        public FunctionComponent(string value, FunctionUtility.FunctionalityType type, float assistiveNumber = 0)
        {
            this.value = value;
            this.type = type;
            this.assistiveNumber = assistiveNumber;
        }

        
    }
}
