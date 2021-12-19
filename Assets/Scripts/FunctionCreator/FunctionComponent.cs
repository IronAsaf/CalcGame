using Utility;

namespace FunctionCreator
{
    [System.Serializable]
    public class FunctionComponent
    {
        public FunctionUtility.FunctionalityType type;
        public float assistiveNumber; //TODO-0002 - Make this not be just a public float, but changeable. Maybe do a interface then we take from that, to NoneAssistive, oper, Normal.
        public FunctionComponent()
        {
            type = FunctionUtility.FunctionalityType.X;
            assistiveNumber = 0;
        }
        //CTOR
        public FunctionComponent(FunctionUtility.FunctionalityType type, float assistiveNumber = 0)
        {
            this.type = type;
            this.assistiveNumber = assistiveNumber;
        }
    }
}