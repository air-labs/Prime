

namespace Prime
{
    public static partial class FactoryExtensions
    {
        public static IChain<TRepeaterBigIn, TRepeaterBigOut> CreateRepeater
            <TRepeaterBigIn, TRepeaterBigOut, TChainSmallIn, TChainSmallOut, TDataCollection>(
            this IPrimeFactory factory,
            IRepeaterBlock<TRepeaterBigIn, TRepeaterBigOut, TChainSmallIn, TChainSmallOut, TDataCollection>
                repeaterBlock,
            IChain<CollectorRequest, TDataCollection> sourceCollector,
            IChain<TChainSmallIn, TChainSmallOut> privateChaine)
        {
            var collectorBlock = sourceCollector.ToFunctionalBlock();
            var functionalBlock = privateChaine.ToFunctionalBlock();

            return factory.CreateChain(new FunctionalBlock<TRepeaterBigIn, TRepeaterBigOut>(
                input =>
                {
                    repeaterBlock.Start(input);
                    TChainSmallIn smallIn;
                    TChainSmallOut smallOut = default(TChainSmallOut);


                    while (repeaterBlock.MakeIteration(collectorBlock.Process(CollectorRequest.Get), smallOut,
                        out smallIn))
                        smallOut = functionalBlock.Process(smallIn);

                    collectorBlock.Process(CollectorRequest.Pushbask);
                    return repeaterBlock.Conclude();
                }));
        }


  
    }
}