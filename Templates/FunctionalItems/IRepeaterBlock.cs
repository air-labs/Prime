using OptimusPrime.Templates.FunctionalItems.SourceCollector;

namespace OptimusPrime.Templates.FunctionalItems
{
    public interface IRepeaterBlock<TPublicIn, TPrivateIn, TPublicOut, TPrivateOut>
    {
        TPrivateIn Start(TPublicIn publicIn);
        bool MakeIteration(TPrivateIn privateIn, ISourceDataCollection sourceDatas, out TPrivateOut privateOut);
        //todo: �� ��������� TPrivateOut
        TPublicOut Conclude(TPrivateOut privateOut);
    }
}