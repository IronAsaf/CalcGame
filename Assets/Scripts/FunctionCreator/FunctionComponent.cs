using Utility;

namespace FunctionCreator
{
    [System.Serializable]
    public class FunctionComponent
    {
        public string value;
        private FunctionUtility.FunctionalityType type;
        public float assistiveNumber; //TODO-0002 - Make this not be just a public float, but changeable. Maybe do a interface then we take from that, to NoneAssistive, oper, Normal.

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

        public FunctionUtility.FunctionalityType GetCurrentType() => type;
    }
}