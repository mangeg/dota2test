namespace Dota2.XmlRpc
{
    using Microsoft.AspNet.Mvc.ModelBinding;

    public class XmlRpcValuesProviderFactory : IValueProviderFactory
    {
        public IValueProvider GetValueProvider( ValueProviderFactoryContext context )
        {
            return new XmlRpcValueProvider( context );
        }
    }
}